using Abp.Application.Navigation;
using Abp.Localization;

namespace OMum.Web
{
    /// <summary>
    /// This class defines menus for the application.
    /// It uses ABP's menu system.
    /// When you add menu items here, they are automatically appear in angular application.
    /// See .cshtml and .js files under App/Main/views/layout/header to know how to render menu.
    /// </summary>
    public class OMumNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        "Home",
                        new LocalizableString("HomePage", OMumConsts.LocalizationSourceName),
                        url: "#/",
                        icon: "fa fa-home"
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "About",
                        new LocalizableString("About", OMumConsts.LocalizationSourceName),
                        url: "#/about",
                        icon: "fa fa-info"
                        )
                ).AddItem(
                   new MenuItemDefinition(
                       "Animal",
                       new LocalizableString("Animal", OMumConsts.LocalizationSourceName),
                       url: "#/animal",
                       icon: "fa fa-paw"
                       )
                       .AddItem(
                         new MenuItemDefinition(
                             "AnimalDetail",
                             new LocalizableString("AnimalDetail", OMumConsts.LocalizationSourceName),
                             url: "#/animaldetail",
                             icon: "fa fa-paw"
                       )
                   )
                );
        }
    }
}
