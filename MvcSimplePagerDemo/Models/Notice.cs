namespace MvcSimplePagerDemo.Models
{
    public class Notice
    {
        /// <summary>
        /// 公告标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 公告内容
        /// </summary>
        [System.Web.Mvc.AllowHtml]
        public string Content { get; set; }

        /// <summary>
        /// 路径
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public System.DateTime PublishTime { get; set; }
    }
}