using System;
using System.Text;
#if NET462
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
#if NET462
        /// <summary>
        /// HtmlHelper Pager - 扩展方法
        /// </summary>
        /// <param name="helper">HtmlHelper</param>
        /// <param name="pager">分页信息</param>
        /// <param name="onPageChange">翻页地址或事件</param>
        /// <param name="pagerViewName">分页分部视图名称，默认值为【_PagerPartial】</param>
        /// <param name="displayMode">分页显示模式</param>
        /// <returns></returns>
        public static MvcHtmlString Pager(this HtmlHelper helper , IPagerModel pager , Func<int , string> onPageChange , string pagerViewName = "_PagerPartial", PagingDisplayMode displayMode = PagingDisplayMode.Always)
        {
            pager.OnPageChange = onPageChange;
            pager.PagingDisplayMode = displayMode;
            return MvcHtmlString.Create(helper.Partial(pagerViewName , pager).ToHtmlString());
        }
#else
        /// <summary>
        /// HtmlHelper Pager - 扩展方法
        /// </summary>
        /// <param name="helper">HtmlHelper</param>
        /// <param name="pager">分页信息</param>
        /// <param name="onPageChange">翻页地址或事件</param>
        /// <param name="pagerViewName">分页分部视图名称，默认值为【_PagerPartial】</param>
        /// <param name="displayMode">分页显示模式</param>
        /// <returns></returns>
        public static IHtmlContent Pager(this IHtmlHelper helper, IPagerModel pager, Func<int, string> onPageChange, string pagerViewName = "_PagerPartial", PagingDisplayMode displayMode = PagingDisplayMode.Always)
        {
            pager.OnPageChange = onPageChange;
            pager.PagingDisplayMode = displayMode;
            return helper.Partial(pagerViewName, pager);
        }
#endif
    }
}