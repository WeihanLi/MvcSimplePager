using System;
using System.Linq;
using Xunit;

namespace WeihanLi.AspNetMvc.MvcSimplePager.Test
{
    public class PagerTest
    {
        [Fact]
        public void PageCountTest()
        {
            var pager = Enumerable.Range(11, 10).ToPagedList(1, 10, 40);
            Assert.Equal(4, pager.Pager.PageCount);
            pager = Enumerable.Range(13, 8).ToPagedList(2, 12, 20);
            Assert.Equal(2, pager.Pager.PageCount);
            pager = Enumerable.Range(10, 10).ToPagedList(1, 12, 10);
            Assert.Equal(1, pager.Pager.PageCount);
        }

        [Fact]
        public void PageStartIndexAndPageEndIndexTest()
        {
            var pager = Enumerable.Range(11, 10).ToPagedList(2, 10, 40);
            Assert.Equal(11, pager.Pager.FirstItem);
            Assert.Equal(20, pager.Pager.LastItem);
            pager = Enumerable.Range(13, 8).ToPagedList(2, 12, 20);
            Assert.Equal(13, pager.Pager.FirstItem);
            Assert.Equal(20, pager.Pager.LastItem);
        }

        [Fact]
        public void HasPrevPageAndNextPageTest()
        {
            var pager = Enumerable.Range(11, 10).ToPagedList(1, 10, 40);
            Assert.False(pager.Pager.HasPreviousPage);
            Assert.True(pager.Pager.HasNextPage);
            pager = Enumerable.Range(13, 8).ToPagedList(2, 12, 20);
            Assert.False(pager.Pager.HasNextPage);
            Assert.True(pager.Pager.HasPreviousPage);
            pager = Enumerable.Range(10, 10).ToPagedList(2, 10, 28);
            Assert.True(pager.Pager.HasNextPage);
            Assert.True(pager.Pager.HasPreviousPage);
            pager = Enumerable.Range(10, 10).ToPagedList(1, 12, 10);
            Assert.False(pager.Pager.HasNextPage);
            Assert.False(pager.Pager.HasPreviousPage);
            pager = Enumerable.Range(10, 10).ToPagedList(1, 12, 0);
            Assert.False(pager.Pager.HasNextPage);
            Assert.False(pager.Pager.HasPreviousPage);
        }

        [Fact]
        public void FirstPageAndLastPageTest()
        {
            var pager = Enumerable.Range(11, 10).ToPagedList(1, 10, 40);
            Assert.False(pager.Pager.IsLastPage);
            Assert.True(pager.Pager.IsFirstPage);
            pager = Enumerable.Range(13, 8).ToPagedList(2, 12, 20);
            Assert.False(pager.Pager.IsFirstPage);
            Assert.True(pager.Pager.IsLastPage);
            pager = Enumerable.Range(10, 10).ToPagedList(2, 10, 28);
            Assert.False(pager.Pager.IsFirstPage);
            Assert.False(pager.Pager.IsLastPage);
            pager = Enumerable.Range(10, 10).ToPagedList(1, 12, 10);
            Assert.True(pager.Pager.IsFirstPage);
            Assert.True(pager.Pager.IsLastPage);
            pager = Enumerable.Range(10, 10).ToPagedList(1, 12, 0);
            Assert.True(pager.Pager.IsFirstPage);
            Assert.True(pager.Pager.IsLastPage);
        }

        [Fact]
        public void PageDataTest()
        {
            var pager = Enumerable.Range(11, 10).ToPagedList(2, 10, 26);
            Assert.Equal(14, pager[3]);
        }
    }
}
