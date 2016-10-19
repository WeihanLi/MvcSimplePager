﻿using System;

namespace MvcSimplePager
{
    /// <summary>
    /// 分页信息模型接口
    /// IPagerModel
    /// </summary>
    public interface IPagerModel
    {
        /// <summary>
        /// 分页显示模式
        /// </summary>
        PagingDisplayMode PagingDisplayMode { get; set; }
        /// <summary>
        /// 页码索引
        /// </summary>
        int PageIndex { get; set; }
        /// <summary>
        /// 页码容量，每页数据量
        /// </summary>
        int PageSize { get; set; }
        /// <summary>
        /// 数据总页数
        /// </summary>
        int PageCount { get; set; }
        /// <summary>
        /// 数据总数量
        /// </summary>
        int TotalCount { get; set; }
        /// <summary>
        /// 本页第一个元素索引
        /// </summary>
        int FirstItem { get; }
        /// <summary>
        /// 本页最后一个元素索引
        /// </summary>
        int LastItem { get; }
        /// <summary>
        /// 是否是第一页
        /// </summary>
        bool IsFirstPage { get; }
        /// <summary>
        /// 是否是最后一页
        /// </summary>
        bool IsLastPage { get; }
        /// <summary>
        /// 是否有上一页
        /// </summary>
        bool HasPreviousPage { get; }
        /// <summary>
        /// 是否有下一页
        /// </summary>
        bool HasNextPage { get; }

        int GroupSize { get; set; }
        /// <summary>
        /// 翻页路径或翻页处理事件
        /// </summary>
        Func<int , string> OnPageChange { get; set; }
    }

    /// <summary>
    /// PagingDisplayMode
    /// </summary>
    public enum PagingDisplayMode
    {
        /// <summary>
        /// always show the pager
        /// </summary>
        Always = 0,
        /// <summary>
        /// show pager only when pageSize > 1
        /// </summary>
        IfNeeded = 1
    }
}