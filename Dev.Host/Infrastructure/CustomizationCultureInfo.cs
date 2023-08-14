using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace Dev.Host.Infrastructure
{
    public class CustomizationCultureInfo
    {
        public class CustomizationCulture
        {
            public static void ConfigureCultureInfo(WebApplication app)
            {
                CultureInfo cultureInfo = new CultureInfo("en-US");
                cultureInfo.NumberFormat.CurrencyGroupSeparator = ".";
                CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
                CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

                app.UseRequestLocalization(new RequestLocalizationOptions
                {
                    DefaultRequestCulture = new RequestCulture(cultureInfo),
                    SupportedCultures = new List<CultureInfo> { cultureInfo },
                    SupportedUICultures = new List<CultureInfo> { cultureInfo }
                });
            }
        }
    }
}