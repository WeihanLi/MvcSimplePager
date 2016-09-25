using MvcSimplePager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MvcSimplePagerDemo.Controllers
{
    public class HomeController : Controller
    {
        private List<Models.Notice> noticeSourceList = new List<Models.Notice>();

        public HomeController()
        {
            InitData();
        }

        private void InitData()
        {
            if (noticeSourceList == null || noticeSourceList.Count == 0)
            {
                Models.Notice n = null;
                for (int i = 0; i < 50; i++)
                {
                    n = new Models.Notice();
                    n.Title = "test" + i.ToString("000");
                    n.Content = n.Title;
                    n.Path = n.Title + ".html";
                    n.PublishTime = DateTime.Now;
                    //
                    noticeSourceList.Add(n);
                }
            }
        }

        public ActionResult Index() => View();

        public ActionResult NoticeList(string title, int pageIndex = 1, int pageSize = 10)
        {
            int offset = (pageIndex - 1) * pageSize, count = 0;
            IEnumerable<Models.Notice> noticeList = null;
            try
            {
                if (!String.IsNullOrEmpty(title))
                {
                    noticeList = (from notice in noticeSourceList where notice.Title.Contains(title) orderby notice.PublishTime select notice);
                }
                else
                {
                    noticeList = (from notice in noticeSourceList select notice);
                }
                count = noticeList.Count();
                noticeList = noticeList.Skip(offset).Take(pageSize);
                PagerModel pager = new PagerModel(pageIndex, pageSize, count);
                PagedListModel<Models.Notice> data = noticeList.ToPagedList(pager);
                return View(data);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}