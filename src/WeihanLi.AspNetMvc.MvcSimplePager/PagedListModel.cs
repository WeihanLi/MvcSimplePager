using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo(@"WeihanLi.AspNetMvc.MvcSimplePager.Test, PublicKey=0024000004800000940000000602000000240000525341310004000001000100b9567ca1495d374ebde24d16e7d47de27ae6c3ded022658f4e9b9dbe0858f1ed9383a4b50360229f2f75d650dc16350e097290c814fb77f5bf3f3dec54a6c6149e815f961a4732ef898e0ff20e15078c2ce64db505922f4766c37014b828123811d7f5cdfabd62fa00a7c3267ef2f1b456d8bf048e2307a51ff43a242249c4bd")]

namespace WeihanLi.AspNetMvc.MvcSimplePager
{
    /// <summary>
    /// PagedListModel
    /// </summary>
    /// <typeparam name="T">Type</typeparam>
    internal class PagedListModel<T> : IPagedListModel<T>
    {
        public IReadOnlyList<T> Data { get; }

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
                    throw new IndexOutOfRangeException($"索引超出限制，索引值为：{i}，最大值为：{Count - 1}");
                }
                return Data.ElementAt(i);
            }
        }
    }
}
