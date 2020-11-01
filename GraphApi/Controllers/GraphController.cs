using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphApi.Models;
using GraphApi.Utility;
using GraphLibrary.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraphApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GraphController : ControllerBase
    {
        [HttpPost]
        public ActionResult<IEnumerable<EdgeDto>> PostGraph(GraphDto graphDto)
        {
            var graph = Mapper.ToGraphModel(graphDto);
            var terminals = graph.Nodes.FindAll(node => node.IsTerminal);
            if (terminals.Count < 2)
            {
                return BadRequest("You must specify at least 2 terminals");
            }

            var nodeSolution = FindPath(terminals[0], terminals[0], graph.Nodes.Count);
            var solution = Mapper.ToEdgeDtos(nodeSolution);
            return Ok(solution);
        }

        private List<NodeModel> FindPath(NodeModel sourceNode, NodeModel currentNode, int maxDepth)
        {
            if (maxDepth < 0)
                return null;

            if (currentNode.IsTerminal && sourceNode != currentNode)
                return new List<NodeModel>() { currentNode };

            List<NodeModel> bestResult = new List<NodeModel>();
            List<NodeModel> tempResult;

            foreach (var node in currentNode.Edges)
            {
                tempResult = FindPath(sourceNode, node, maxDepth - 1);
                if (tempResult != null)
                    if (tempResult.Count < bestResult.Count && tempResult.Count > 0 || bestResult.Count == 0)
                        bestResult = tempResult;
            }
            
            if(bestResult.Count > 0)
                bestResult.Add(currentNode);

            return bestResult;
        }        
    }
}
