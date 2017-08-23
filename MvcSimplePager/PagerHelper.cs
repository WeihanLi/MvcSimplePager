using System;
using System.Text;
#if NET45
using System.Web.Mvc;
using System.Web.Mvc.Html;
#else
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
#endif

namespace MvcSimplePager
{
    /// <summary>
    /// PagerHelper 分页帮助类
    /// </summary>
    public static class PagerHelper
    {
#if NET45
        /// <summary>
        /// HtmlHelper Pager - 扩展方法
        /// </summary>
        /// <param name="helper">HtmlHelper</param>
        /// <param name="pagerModel">分页信息</param>
        /// <param name="onPageChange">翻页地址或事件</param>
        /// <returns></returns>
        public static MvcHtmlString Pager(this HtmlHelper helper , IPagerModel pagerModel , Func<int , string> onPageChange)
        {
            return Pager(helper,pagerModel,onPageChange,"_PagerPartial");
        }

        /// <summary>
        /// HtmlHelper Pager - 扩展方法
        /// </summary>
        /// <param name="helper">HtmlHelper</param>
        /// <param name="pagerModel">分页信息</param>
        /// <param name="onPageChange">翻页地址或事件</param>
        /// <param name="pagerViewName">分页分部视图名称，默认值为【_PagerPartial】</param>
        /// <returns></returns>
        public static MvcHtmlString Pager(this HtmlHelper helper , IPagerModel pagerModel , Func<int , string> onPageChange , string pagerViewName)
        {
            return Pager(helper,pagerModel,onPageChange,pagerViewName,PagingDisplayMode.Always);
        }

        /// <summary>
        /// HtmlHelper Pager - 扩展方法
        /// </summary>
        /// <param name="helper">HtmlHelper</param>
        /// <param name="pagerModel">分页信息</param>
        /// <param name="onPageChange">翻页地址或事件</param>
        /// <param name="pagerViewName">分页分部视图名称，默认值为【_PagerPartial】</param>
        /// <param name="displayMode">分页显示模式</param>
        /// <returns></returns>
        public static MvcHtmlString Pager(this HtmlHelper helper , IPagerModel pagerModel , Func<int , string> onPageChange , string pagerViewName, PagingDisplayMode displayMode)
        {
            pagerModel.OnPageChange = onPageChange;
            pagerModel.PagingDisplayMode = displayMode;
            return MvcHtmlString.Create(helper.Partial(pagerViewName , pagerModel).ToHtmlString());
        }
#else
        /// <summary>
        /// HtmlHelper Pager - 扩展方法
        /// </summary>
        /// <param name="helper">HtmlHelper</param>
        /// <param name="pagerModel">分页信息</param>
        /// <param name="onPageChange">翻页地址或事件</param>
        /// <returns></returns>
        public static IHtmlContent Pager(this IHtmlHelper helper, IPagerModel pagerModel, Func<int, string> onPageChange)
        {
            return Pager(helper, pagerModel, onPageChange, "_PagerPartial");
        }

        /// <summary>
        /// HtmlHelper Pager - 扩展方法
        /// </summary>
        /// <param name="helper">HtmlHelper</param>
        /// <param name="pagerModel">分页信息</param>
        /// <param name="onPageChange">翻页地址或事件</param>
        /// <param name="pagerViewName">分页分部视图名称，默认值为【_PagerPartial】</param>
        /// <returns></returns>
        public static IHtmlContent Pager(this IHtmlHelper helper, IPagerModel pagerModel, Func<int, string> onPageChange, string pagerViewName)
        {
            return Pager(helper, pagerModel, onPageChange, pagerViewName, PagingDisplayMode.Always);
        }

        /// <summary>
        /// HtmlHelper Pager - 扩展方法
        /// </summary>
        /// <param name="helper">HtmlHelper</param>
        /// <param name="pagerModel">分页信息</param>
        /// <param name="onPageChange">翻页地址或事件</param>
        /// <param name="pagerViewName">分页分部视图名称，默认值为【_PagerPartial】</param>
        /// <param name="displayMode">分页显示模式</param>
        /// <returns></returns>
        public static IHtmlContent Pager(this IHtmlHelper helper, IPagerModel pagerModel, Func<int, string> onPageChange, string pagerViewName, PagingDisplayMode displayMode)
        {
            pagerModel.OnPageChange = onPageChange;
            pagerModel.PagingDisplayMode = displayMode;
            return helper.Partial(pagerViewName, pagerModel);
        }
#endif
    }
}