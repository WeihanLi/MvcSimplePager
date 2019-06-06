using System.Collections.Generic;

namespace WeihanLi.AspNetMvc.MvcSimplePager
{
    public static class PagedListModelExtension
    {
        public static IPagedListModel<T> ToPagedList<T>(this IEnumerable<T> data, int pageNumber, int pageSize, int totalCount)
        {
            return new PagedListModel<T>(data, new PagerModel(pageNumber, pageSize, totalCount));
        }

        public static IPagedListModel<T> ToPagedList<T>(this WeihanLi.Common.Models.IPagedListModel<T> data)
        {
            return new PagedListModel<T>(data.Data, new PagerModel(data.PageNumber, data.PageSize, data.TotalCount));
        }
    }
}
