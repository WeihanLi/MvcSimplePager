using System;

namespace MvcSimplePager
{
    public interface IPagerModel
    {
        PagingDisplayMode PagingDisplayMode { get; set; }
        int PageIndex { get; set; }
        int PageSize { get; set; }

        int PageCount { get; set; }

        int TotalCount { get; set; }

        int FirstItem { get; }

        int LastItem { get; }

        bool IsFirstPage { get; }

        bool IsLastPage { get; }

        bool HasPreviousPage { get; }

        bool HasNextPage { get; }

        Func<int, string> OnPageChange { get; set; }
    }

    public enum PagingDisplayMode
    {
        Always = 0,
        IfNeeded = 1
    }
}