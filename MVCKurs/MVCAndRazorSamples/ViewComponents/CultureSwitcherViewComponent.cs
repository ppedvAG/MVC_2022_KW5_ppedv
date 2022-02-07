using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MVCAndRazorSamples.Models;

namespace MVCAndRazorSamples.ViewComponents
{

    //ViewComponents können auf den IOC Containerr zugreifen -> Konstruktor-Injection 
    //ViewComponents verwenden Models
    //ViewComponents besitzen ihre eigene View (Aufpassen Konventionen) 
    public class CultureSwitcherViewComponent : ViewComponent
    {
        private IOptions<RequestLocalizationOptions> _localizationOptions;

        public CultureSwitcherViewComponent(IOptions<RequestLocalizationOptions> localizationOptions)
        {
            _localizationOptions = localizationOptions;
        } 


        //Invoke wird automatisch aufgerufen
        public IViewComponentResult Invoke()
        {
            IRequestCultureFeature cultureFeature = HttpContext.Features.Get<IRequestCultureFeature>();

            CultureSwitcherModel model = new CultureSwitcherModel()
            {
                SupportedCultures = _localizationOptions.Value.SupportedCultures.ToList(),
                CurrentUICulture = cultureFeature.RequestCulture.UICulture
            };

            return View(model);
        }
    }
}
