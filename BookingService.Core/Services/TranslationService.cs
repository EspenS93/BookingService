using BookingService.Core.Entities.Translation;
using BookingService.Core.Interfaces;

namespace BookingService.Core.Services
{
    public class TranslationService(ITranslationRepository translationRepository) : ITranslationService
    {
        public async Task<Translation> AddTranslation(Translation translation, CancellationToken cancellationToken)
        {
            return await translationRepository.AddTranslation(translation, cancellationToken);
        }

        public async Task<bool> DeleteTranslation(string resourceKey, string culture, CancellationToken cancellationToken)
        {
            return await translationRepository.DeleteTranslation(resourceKey, culture, cancellationToken);
        }

        public async Task<string> GetTranslation(string resourceKey, string culture, CancellationToken cancellationToken)
        {
            return await translationRepository.GetTranslation(resourceKey, culture, cancellationToken);
        }

        public async Task<Translation> UpdateTranslation(Translation translation, CancellationToken cancellationToken)
        {
            return await translationRepository.UpdateTranslation(translation, cancellationToken);
        }
    }
}
