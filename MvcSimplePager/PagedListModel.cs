using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MvcSimplePager
{
    /// <summary>
    /// IPagedListModel 
    /// </summary>
    /// <typeparam name="T">Type</typeparam>
    public interface IPagedListModel<out T> : IEnumerable<T>, IEnumerable
    {
        /// <summary>
        /// Data 
        /// </summary>
        IEnumerable<T> Data { get; }

        /// <summary>
        /// PagerModel 
        /// </summary>
        IPagerModel Pager { get; }

        /// <summary>
        /// Indexer 
        /// </summary>
        /// <param name="i"> index </param>
        /// <returns></returns>
        T this[int i] { get; }

        /// <summary>
        /// Data.Count 
        /// </summary>
        int Count { get; }
    }

    /// <summary>
    /// PagedListModel 
    /// </summary>
    /// <typeparam name="T">Type</typeparam>
    public class PagedListModel<T> : IPagedListModel<T>
    {
        public IEnumerable<T> Data { get; }

        public IPagerModel Pager { get; }

        public int Count
        {
            get { return Data.Count(); }
        }

        public PagedListModel(IEnumerable<T> data, IPagerModel pager)
        {
            Data = data;
            Pager = pager;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return Data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Data.GetEnumerator();
        }

        public T this[int i]
        {
            get
            {
                if (i < 0)
                {
                    throw new IndexOutOfRangeException("索引不能为负数");
                }
                if (i >= Count)
                {
                    throw new IndexOutOfRangeException(String.Format("索引超出限制，索引值为：{0}，最大值为：{1}", i, Count - 1));
                }
                return Data.ToArray()[i];
            }
        }
    }

    /// <summary>
    /// PagedList extensions 
    /// </summary>
    public static class Extensions
    {
        [Obsolete("请使用 ToPagedList<T>(this IEnumerable<T> data, int pageIndex, int pageSize, int totalCount)")]
        public static IPagedListModel<T> ToPagedList<T>(this IEnumerable<T> data, IPagerModel pager)
        {
            return new PagedListModel<T>(data, pager);
        }

        public static IPagedListModel<T> ToPagedList<T>(this IEnumerable<T> data, int pageIndex, int pageSize, int totalCount)
        {
            return new PagedListModel<T>(data, new PagerModel(pageIndex, pageSize, totalCount));
        }
    }
}