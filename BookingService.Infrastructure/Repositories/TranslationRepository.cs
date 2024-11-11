using BookingService.Core.Entities.Translation;
using BookingService.Core.Interfaces;
using BookingService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookingService.Infrastructure.Repositories
{
    public class TranslationRepository(BookingServiceDbContext ctx) : ITranslationRepository
    {
        public async Task<bool> DeleteTranslation(string resourceKey, string culture, CancellationToken cancellationToken)
        {
            return await ctx.Translations.Where(t => t.ResourceKey == resourceKey && t.Culture == culture).ExecuteDeleteAsync(cancellationToken) == 1;
        }

        public async Task<string> GetTranslation(string resourceKey, string culture, CancellationToken cancellationToken)
        {
            var translation = await ctx.Translations.FirstOrDefaultAsync(t => t.ResourceKey == resourceKey && t.Culture == culture, cancellationToken);
            return translation?.TranslatedValue ?? resourceKey;
        }

        public async Task<Translation> AddTranslation(Translation translation, CancellationToken cancellationToken)
        {
            ctx.Translations.Add(translation);
            await ctx.SaveChangesAsync(cancellationToken);
            return translation;
        }

        public async Task<Translation> UpdateTranslation(Translation translation, CancellationToken cancellationToken)
        {
            ctx.Translations.Update(translation);
            await ctx.SaveChangesAsync(cancellationToken);
            return translation;
        }
    }
}
