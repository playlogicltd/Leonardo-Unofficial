

using Leonardo.Generation.Interfaces;
using Leonardo.Generation.Models;
using System;
using System.Threading.Tasks;

namespace Leonardo.Generation
{
    public sealed class GenerationEndPoint : EndPointBase, IGenerationEndPoint
    {
        protected override string Endpoint { get { return "generations"; } }
        internal GenerationEndPoint(LeonardoAPI Api) : base(Api) { }

        public async Task<string> Image(string prompt)
        {
            var request = new CreateGenerationRequest(prompt);
            return await Image(request);
        }

        public async Task<string> Image(CreateGenerationRequest request)
        {
            try
            {
                request.Validate();
                var response = await HttpPost<CreateGenerationResponse>(postData: request);
                return response.SdGenerationJob.GenerationId;
            }
            catch(ArgumentException e)
            {
                throw new ArgumentException(e.Message, nameof(e));
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Generations> GetGeneratedImages(string id)
        {
            var response = await HttpGet<GetSingleGenerationResponse>($"{this.Url}/{id}");
            return response.Generations;
        }

        public async Task<UserGenerations> GetGeneratedImagesByUserId(string id, int offset = 0, int limit = 10)
        {
            return await HttpGet<UserGenerations>($"{this.Url}/users/{id}?offset={offset}&limit={limit}");
        }

        public async Task<string> DeleteGeneration(string id)
        {
            var response = await HttpDelete<GenerationDeletionResponse>($"{this.Url}/{id}");
            return response.SdGenerationJob.Id;
        }
    }
}
