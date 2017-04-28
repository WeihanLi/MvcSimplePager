# MvcSimplePager

Build Status | Package 
------------ | ------------
[![Build Status](https://travis-ci.org/WeihanLi/MvcSimplePager.svg?branch=master)](https://travis-ci.org/WeihanLi/MvcSimplePager) | [![MvcSimplePager](https://img.shields.io/nuget/v/mvcsimplepager.svg)](http://www.nuget.org/packages/MvcSimplePager/)

## Intro
MvcSimplePager 是为解决分页的而做的一个通用、扩展性良好的轻量级分页扩展，可以自定义分页时调用的方法，自定义分页所用的样式，样式与代码分离，维护方便。

网上有许多分页都是查询所有数据再从中查询某一页的数据，但是个人感觉数据很少时还可以，如果数据比较多这样根本是不可行的，需要哪一页数据再查询哪一页的数据才是正确的做法，才能一定程度上提高查询的效率。

在网上看了几个分页组件，感觉分页的 html 代码和 CSharp 代码都有不同程度上的耦合，都不是特别满意， 于是自己封装了一个分页组件，基本可以实现 html 代码与 CSharp 代码的完全分离。

## GetStarted
1. 引用 MvcSimplePager 程序集（可通过Nuget安装包：`Install-Package MvcSimplePager`，也可从 [Nuget.org](http://www.nuget.org/packages/MvcSimplePager/) 下载)
2. 在项目中Shared目录下创建自己的分页视图，可以根据 MvcSimplePagerDemo 项目下 Views 下的 Shared 目录中的 _PagerPartial 、 PagerPartial 和 PagerPartial1 三个分页视图进行修改
3. 编写Controller 代码，在需要分页的 Action 中构建 PagerModel 和 PagedListModel，并根据需要设置每组分页显示页码数量
4. 在需要分页的视图中引用 `@Html.Pager` 扩展方法，并设置必要的分页信息参数
5. 详细使用可参考 MvcSimplePagerDemo 项目以及这里的 [使用指南](http://www.cnblogs.com/weihanli/p/mvcSimplePager.html#pagerInUse)

## Contact
如果您在使用过程中遇到什么问题，您可以随时联系我：<ben121011@126.com>