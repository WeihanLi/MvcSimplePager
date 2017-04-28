using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MvcSimplePager.Test
{
    [TestClass]
    public class PagerModelTest
    {
        [TestMethod]
        public void PageIndexAndPageSizeTest()
        {
            var pager = Enumerable.Range(11, 10).ToPagedList(2, 10, 40);
            Assert.AreEqual(2, pager.Pager.PageIndex);
            Assert.AreEqual(10, pager.Pager.PageSize);
            Assert.AreEqual(40,pager.Pager.TotalCount);
        }

        [TestMethod]
        public void PageCountTest()
        {
            var pager = Enumerable.Range(11, 10).ToPagedList(1, 10, 40);
            Assert.AreEqual(4, pager.Pager.PageCount);
            pager = Enumerable.Range(13, 8).ToPagedList(2, 12, 20);
            Assert.AreEqual(2, pager.Pager.PageCount);
            pager = Enumerable.Range(10, 10).ToPagedList(1, 12, 10);
            Assert.AreEqual(1, pager.Pager.PageCount);
        }

        [TestMethod]
        public void PageStartIndexAndPageEndIndexTest()
        {
            var pager = Enumerable.Range(11, 10).ToPagedList(2, 10, 40);
            Assert.AreEqual(11,pager.Pager.FirstItem);
            Assert.AreEqual(20, pager.Pager.LastItem);
            pager = Enumerable.Range(13, 8).ToPagedList(2, 12, 20);
            Assert.AreEqual(13,pager.Pager.FirstItem);
            Assert.AreEqual(20, pager.Pager.LastItem);
        }

        [TestMethod]
        public void HasPrevPageAndNextPageTest()
        {
            var pager = Enumerable.Range(11, 10).ToPagedList(1, 10, 40);
            Assert.IsFalse(pager.Pager.HasPreviousPage);
            Assert.IsTrue(pager.Pager.HasNextPage);
            pager = Enumerable.Range(13, 8).ToPagedList(2, 12, 20);
            Assert.IsFalse(pager.Pager.HasNextPage);
            Assert.IsTrue(pager.Pager.HasPreviousPage);
            pager = Enumerable.Range(10, 10).ToPagedList(2, 10, 28);
            Assert.IsTrue(pager.Pager.HasNextPage);
            Assert.IsTrue(pager.Pager.HasPreviousPage);
            pager = Enumerable.Range(10, 10).ToPagedList(1, 12, 10);
            Assert.IsFalse(pager.Pager.HasNextPage);
            Assert.IsFalse(pager.Pager.HasPreviousPage);
            pager = Enumerable.Range(10, 10).ToPagedList(1, 12, 0);
            Assert.IsFalse(pager.Pager.HasNextPage);
            Assert.IsFalse(pager.Pager.HasPreviousPage);
        }

        [TestMethod]
        public void FirstPageAndLastPageTest()
        {
            var pager = Enumerable.Range(11, 10).ToPagedList(1, 10, 40);
            Assert.IsFalse(pager.Pager.IsLastPage);
            Assert.IsTrue(pager.Pager.IsFirstPage);
            pager = Enumerable.Range(13, 8).ToPagedList(2, 12, 20);
            Assert.IsFalse(pager.Pager.IsFirstPage);
            Assert.IsTrue(pager.Pager.IsLastPage);
            pager = Enumerable.Range(10, 10).ToPagedList(2, 10, 28);
            Assert.IsFalse(pager.Pager.IsFirstPage);
            Assert.IsFalse(pager.Pager.IsLastPage);
            pager = Enumerable.Range(10, 10).ToPagedList(1, 12, 10);
            Assert.IsTrue(pager.Pager.IsFirstPage);
            Assert.IsTrue(pager.Pager.IsLastPage);
            pager = Enumerable.Range(10, 10).ToPagedList(1, 12, 0);
            Assert.IsTrue(pager.Pager.IsFirstPage);
            Assert.IsTrue(pager.Pager.IsLastPage);
        }

        [TestMethod]
        public void PageDataTest()
        {
            var pager = Enumerable.Range(11, 10).ToPagedList(2, 10, 26);
            Assert.AreEqual(14,pager[3]);
        }
    }
}