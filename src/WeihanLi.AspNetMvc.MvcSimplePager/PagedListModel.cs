using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace WeihanLi.AspNetMvc.MvcSimplePager
{
    /// <summary>
    /// PagedListModel
    /// </summary>
    /// <typeparam name="T">Type</typeparam>
    public class PagedListModel<T> : IPagedListModel<T>
    {
        public IList<T> Data { get; }

        public IPagerModel Pager { get; }

        public int Count => Data.Count();

        public PagedListModel(IEnumerable<T> data, IPagerModel pager)
        {
            Data = data?.ToArray() ?? new T[0];
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
                return Data.ElementAt(i);
            }
        }
    }
}
