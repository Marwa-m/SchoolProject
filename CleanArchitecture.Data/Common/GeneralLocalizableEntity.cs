using System.Globalization;

namespace CleanArchitecture.Data.Common;

public class GeneralLocalizableEntity
{
    public string Localize(string textAr, string textEn)
    {
        CultureInfo culture = Thread.CurrentThread.CurrentCulture;
        if (culture.TwoLetterISOLanguageName.ToLower().Equals("en"))
            return textEn;
        return textAr;
    }
}
