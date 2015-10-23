using Abp.Web.Mvc.Views;

namespace OMum.Web.Views
{
    public abstract class OMumWebViewPageBase : OMumWebViewPageBase<dynamic>
    {

    }

    public abstract class OMumWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected OMumWebViewPageBase()
        {
            LocalizationSourceName = OMumConsts.LocalizationSourceName;
        }
    }
}