using GraphLibrary.Dtos;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GUI.Connector
{
    class GraphApiConnector
    {
        private static readonly HttpClient _client = new HttpClient()
        {
            BaseAddress = new Uri("http://localhost:6969"),
            Timeout = new TimeSpan(0, 0, 10)
        };

        public static async Task<List<EdgeDto>> PostGraphAsync(GraphDto graph)
        {
            // пиздец хуйня какая-то с этими await'ами

            var content = new StringContent(JsonSerializer.Serialize(graph));
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await _client.PostAsync("/api/graph", content);
            var result = await response.Content.ReadAsStringAsync();
            try
            {
                return JsonSerializer.Deserialize<List<EdgeDto>>(result, new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
            }
            catch
            {
                throw new Exception(result);
            }
            
        }
    }
}
