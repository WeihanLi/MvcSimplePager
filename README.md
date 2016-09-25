# MvcSimplePager
MvcSimplePager 是为解决分页的而做的一个通用、扩展性良好的轻量级分页扩展，可以自定义分页时调用的方法，自定义分页所用的样式，样式与代码分离，维护方便。

## 使用说明
1. 引用 MvcSimplePager 项目 或 MvcSimplePager.dll 程序集
2. 在项目中创建分页视图
3. 在需要分页的 Action 中构建 PagerModel 和 PagedListModel
4. 在需要分页的视图中引用 `@Html.Pager` 扩展方法，并设置分页信息
5. 详细说明见 MvcSimplePagerDemo 项目

## Contact
如果使用过程中遇到什么问题，您可以随时联系我：<ben121011@126.com>