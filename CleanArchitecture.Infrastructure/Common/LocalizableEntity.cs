using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Common;

public class LocalizableEntity
{
    public string NameAr { get; set; }
    public string NameEn { get; set; }

    public string GetLocalized()
    { 
        CultureInfo culture=Thread.CurrentThread.CurrentCulture;
        if (culture.TwoLetterISOLanguageName.ToLower().Equals("ar"))
            return NameAr;
        return NameEn;
    }
}
