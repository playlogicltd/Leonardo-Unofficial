

using Newtonsoft.Json;

namespace Leonardo.Generation.Models
{
    public class GetSingleGenerationResponse
    {
        [JsonProperty("generations_by_pk")]
        public Generations Generations { get; set; }
    }
}
