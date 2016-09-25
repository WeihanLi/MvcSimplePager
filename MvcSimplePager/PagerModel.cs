using System;

namespace MvcSimplePager
{
    public class PagerModel : IPagerModel
    {
        public PagingDisplayMode PagingDisplayMode { get; set; }
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int PageCount { get; set; }

        public int TotalCount { get; set; }

        public PagerModel(int pageIndex, int pageSize, int totalCount)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalCount = totalCount;
            PageCount = Convert.ToInt32(Math.Ceiling(TotalCount * 1.0 / PageSize));
        }

        public bool IsFirstPage { get { return PageIndex <= 1; } }

        public bool IsLastPage { get { return PageIndex >= PageCount; } }

        public bool HasPreviousPage { get { return PageIndex > 1; } }

        public bool HasNextPage { get { return PageIndex < PageCount; } }

        public int FirstItem { get { return (PageIndex - 1) * PageSize + 1; } }

        public int LastItem
        {
            get
            {
                if (IsLastPage)
                {
                    return FirstItem + (TotalCount - 1) % PageSize;
                }
                else
                {
                    return PageIndex * PageSize;
                }
            }
        }

        public Func<int, string> OnPageChange { get; set; }
    }
}