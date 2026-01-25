using Shared.Data.Models;

namespace DC.Services
{
    public interface ISavedService
    {
        Task SaveAsync(SavedRate rate);
    }

}
