using System.Collections.Generic;

namespace MvcSimplePager
{
    public static class PagedListModelExtension
    {
        public static IPagedListModel<T> ToPagedList<T>(this IEnumerable<T> data, int pageIndex, int pageSize, int totalCount)
        {
            return new PagedListModel<T>(data, new PagerModel(pageIndex, pageSize, totalCount));
        }
    }
}