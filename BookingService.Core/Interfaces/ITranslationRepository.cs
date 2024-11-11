using BookingService.Core.Entities.Translation;

namespace BookingService.Core.Interfaces
{
    public interface ITranslationRepository
    {
        public Task<string> GetTranslation(string resourceKey, string culture, CancellationToken cancellationToken);
        public Task<Translation> AddTranslation(Translation translation, CancellationToken cancellationToken);
        public Task<bool> DeleteTranslation(string resourceKey, string culture, CancellationToken cancellationToken);
        public Task<Translation> UpdateTranslation(Translation translation, CancellationToken cancellationToken);
    }
}
