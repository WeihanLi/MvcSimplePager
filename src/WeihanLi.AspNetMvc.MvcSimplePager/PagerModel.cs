using System;

namespace WeihanLi.AspNetMvc.MvcSimplePager
{
    /// <summary>
    /// 分页模型
    /// </summary>
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

        public bool IsFirstPage => PageIndex <= 1;

        public bool IsLastPage => PageIndex >= PageCount;

        public bool HasPreviousPage => PageIndex > 1;

        public bool HasNextPage => PageIndex < PageCount;

        public int FirstItem => (PageIndex - 1) * PageSize + 1;

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

        private int groupSize = 12;

        public int GroupSize
        {
            get { return groupSize; }
            set
            {
                if (value > 1)
                {
                    groupSize = value;
                }
            }
        }

        public bool ShowJumpButton { get; set; }
    }
}