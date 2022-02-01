using WorldClockApp.Models;

namespace WorldClockApp.Services
{
    public interface IWorldClockService
    {
        Task<WorldClockResult?> GetWorldClockTimeAsync();
    }
}
