using BookingService.Core.Interfaces;
using System.ComponentModel;

namespace AspireApp1.Web
{
    public class LocalizedDisplayNameAttribute(string resourceKey) : DisplayNameAttribute
    {
        public override string DisplayName
        {
            get
            {
                var culture = Thread.CurrentThread.CurrentCulture.Name;
                var translationService = ServiceLocator.ServiceProvider?.GetService(typeof(ITranslationService)) as ITranslationService;
                CancellationToken cancellationToken = new();
                return translationService?.GetTranslation(resourceKey, culture, cancellationToken).GetAwaiter().GetResult() ?? resourceKey;
            }
        }
    }
}
