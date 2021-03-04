using Innoactive.Creator.Core.Internationalization;

namespace Innoactive.Creator.UX
{
    public interface ILocalizationProvider
    {
        /// <summary>
        /// Returns the localization config which should be used.
        /// </summary>
        LocalizationConfig LocalizationConfig { get; }
    }
}