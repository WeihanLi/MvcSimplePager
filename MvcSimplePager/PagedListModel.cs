using System;
using System.Collections;
using System.Collections.Generic;

namespace MvcSimplePager
{
    /// <summary>
    /// IPagedListModel
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPagedListModel<out T>
    {
        /// <summary>
        /// Data
        /// </summary>
        IEnumerable<T> Data { get; }
        /// <summary>
        /// PagerModel
        /// </summary>
        PagerModel Pager { get; }
    }

    /// <summary>
    /// PagedListModel
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagedListModel<T> : IPagedListModel<T>, IEnumerable<T>
    {
        public IEnumerable<T> Data { get; }

        public PagerModel Pager { get; }

        public PagedListModel(IEnumerable<T> data , PagerModel pager)
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
    }

    /// <summary>
    /// PagedList extensions
    /// </summary>
    public static class Extensions
    {
        public static IPagedListModel<T> ToPagedList<T>(this IEnumerable<T> data , PagerModel pager)
        {
            return new PagedListModel<T>(data , pager);
        }

        public static IPagedListModel<T> ToPagedList<T>(this IEnumerable<T> data , int pageIndex , int pageSize , int totalCount)
        {
            return new PagedListModel<T>(data , new PagerModel(pageIndex , pageSize , totalCount));
        }
    }
}