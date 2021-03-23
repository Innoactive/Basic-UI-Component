using System.Collections.Generic;
using Innoactive.Creator.Core;
using Innoactive.Creator.Core.Internationalization;
using UnityEngine;

namespace Innoactive.Creator.UX
{
    public abstract class BaseCourseControllerMenu : MonoBehaviour
    {
        protected List<string> localizationFileNames = null;
        
        protected virtual List<string> FetchAvailableLocalizationsForTraining()
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add(LocalizationReader.KeyCourseName, CourseRunner.Current.Data.Name);
            return LocalizationUtils.FindAvailableLanguagesForConfig(GetLocalizationConfig(), parameters);
        }
        
        protected virtual string GetSelectedLanguage()
        {
            if (string.IsNullOrEmpty(LanguageSettings.Instance.ActiveLanguage) == false)
            {
                return LanguageSettings.Instance.ActiveLanguage;
            }

            if (localizationFileNames == null)
            {
                localizationFileNames = FetchAvailableLocalizationsForTraining();
            }
            
            if (localizationFileNames.Contains(LocalizationUtils.GetSystemLanguageAsTwoLetterIsoCode().ToLower()))
            {
                return LocalizationUtils.GetSystemLanguageAsTwoLetterIsoCode();
            }
            return LanguageSettings.Instance.DefaultLanguage;
        }
        
        protected virtual LocalizationConfig GetLocalizationConfig()
        {
            ICourseController controller = FindObjectOfType<CourseControllerSetup>().CurrentCourseController;
            if (controller is ILocalizationProvider localizationProvider)
            {
                return localizationProvider.LocalizationConfig;
            }
            
            return Resources.Load<LocalizationConfig>(LocalizationConfig.DefaultLocalizationConfig);
        }
    }
}