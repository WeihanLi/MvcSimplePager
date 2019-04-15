using System.Collections.Generic;

namespace WeihanLi.AspNetMvc.MvcSimplePager
{
    /// <summary>
    /// IPagedListModel
    /// </summary>
    /// <typeparam name="T">Type</typeparam>
    public interface IPagedListModel<T> : IEnumerable<T>
    {
        /// <summary>
        /// Data
        /// </summary>
        IList<T> Data { get; }

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
}
