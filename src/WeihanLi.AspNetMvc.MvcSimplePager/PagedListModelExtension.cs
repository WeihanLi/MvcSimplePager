﻿using System.Collections.Generic;

namespace WeihanLi.AspNetMvc.MvcSimplePager
{
    public static class PagedListModelExtension
    {
        public static IPagedListModel<T> ToPagedList<T>(this IEnumerable<T> data, int pageNumber, int pageSize, int totalCount)
        {
            return new PagedListModel<T>(data, new PagerModel(pageNumber, pageSize, totalCount));
        }
    }
}