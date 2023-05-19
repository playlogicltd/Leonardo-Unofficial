

using Leonardo.Generation.Models;
using System.Threading.Tasks;

namespace Leonardo.Generation.Interfaces
{
    public interface IGenerationEndPoint
    {
        Task<string> Image(string prompt);
        Task<string> Image(CreateGenerationRequest request);
        Task<Generations> GetGeneratedImages(string id);
        Task<UserGenerations> GetGeneratedImagesByUserId(string id, int offset = 0, int limit = 10);
        Task<string> DeleteGeneration(string id);
    }
}
