# WeihanLi.AspNetMvc.MvcSimplePager

 Type  | Status
------ | ------------
lincense | [![license](https://img.shields.io/github/license/WeihanLi/MvcSimplePager.svg)](https://github.com/WeihanLi/MvcSimplePager) |
travis | [![Build Status](https://travis-ci.org/WeihanLi/MvcSimplePager.svg?branch=netstandard)](https://travis-ci.org/WeihanLi/MvcSimplePager) |
appveyor | [![Build status](https://ci.appveyor.com/api/projects/status/f3oagcolf02ttyfe?svg=true)](https://ci.appveyor.com/project/WeihanLi/mvcsimplepager) |
nuget | [![WeihanLi.AspNetMvc.MvcSimplePager](https://img.shields.io/nuget/v/WeihanLi.AspNetMvc.MvcSimplePager.svg)](http://www.nuget.org/packages/WeihanLi.AspNetMvc.MvcSimplePager/) |
codecov | [![codecov](https://codecov.io/gh/WeihanLi/MvcSimplePager/branch/master/graph/badge.svg)](https://codecov.io/gh/WeihanLi/MvcSimplePager) |

## Intro

MvcSimplePager 是为解决分页的而做的一个通用、扩展性良好的轻量级分页扩展，可以自定义分页时调用的方法，自定义分页所用的样式，样式与代码分离，维护方便。

同时支持 asp.net mvc与 asp.net core

网上有许多分页都是查询所有数据再从中查询某一页的数据，但是个人感觉数据很少时还可以，如果数据比较多这样根本是不可行的，需要哪一页数据再查询哪一页的数据才是正确的做法，才能一定程度上提高查询的效率。

在网上看了几个分页组件，感觉分页的 html 代码和 CSharp 代码都有不同程度上的耦合，都不是特别满意， 于是自己封装了一个分页组件，基本可以实现 html 代码与 CSharp 代码的完全分离。

## GetStarted

1. 引用 MvcSimplePager 程序集（可通过Nuget安装包：`Install-Package WeihanLi.AspNetMvc.MvcSimplePager`，也可从 [Nuget.org](https://www.nuget.org/packages/WeihanLi.AspNetMvc.MvcSimplePager/) 下载)
1. 在项目中Shared目录下创建自己的分页视图，可以根据 MvcSimplePagerDemo 项目下 Views 下的 Shared 目录中的 _PagerPartial 、 PagerPartial 和 PagerPartial1 三个分页视图进行修改
1. 编写Controller 代码，在需要分页的 Action 中构建 PagerModel 和 PagedListModel，并根据需要设置每组分页显示页码数量
1. 在需要分页的视图中引用 `@Html.Pager` 扩展方法，并设置必要的分页信息参数
1. 建议在 Views 引用的命名空间中加入 `WeihanLi.AspNetMvc.MvcSimplePager` 以更方便的使用，添加命名空间方法如下：

    - asp.net mvc

    在 Views 目录下面的 web.config 文件中的 `system.web.webPages.razor` 节点下 `paged` 下 `namespaces` 节点下增加 `WeihanLi.AspNetMvc.MvcSimplePager` 命名空间
    效果如下：

    ``` xml
    <system.web.webPages.razor>
        <host factoryType="System.Web.Mvc.MvcWebRazorHostFactory, System.Web.Mvc, Version=5.2.3.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" />
        <pages pageBaseType="System.Web.Mvc.WebViewPage">
            <namespaces>
                <add namespace="System.Web.Mvc" />
                <add namespace="System.Web.Mvc.Ajax" />
                <add namespace="System.Web.Mvc.Html" />
                <add namespace="System.Web.Optimization"/>
                <add namespace="System.Web.Routing" />
                <add namespace="ActivityReservation" />
                <add namespace="WeihanLi.AspNetMvc.MvcSimplePager" />
            </namespaces>
        </pages>
    </system.web.webPages.razor>
    ```

    - asp.net core

    在 Views 目录下面的 _ViewImports.cshtml 文件中增加对命名空间 `WeihanLi.AspNetMvc.MvcSimplePager` 的引用，效果如下：

    ``` csharp
    @using AccountingApp
    @using WeihanLi.AspNetMvc.MvcSimplePager
    @addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
    ```
1. 更多使用可参考下面的 Samples

## Samples

asp.net project sample：
<https://github.com/WeihanLi/ActivityReservation>

asp.net core project sample：
<https://github.com/WeihanLi/AccountingApp>

## **Notice**

> 注：原 `MvcSimplePager` 包已不再维护，以后只维护 `WeihanLi.AspNetMvc.MvcSimplePager` 这个包，如果您是新用户请直接使用 `WeihanLi.AspNetMvc.MvcSimplePager` ，如果您是 `MvcSimplePager` 的用户请尽快迁移到 `WeihanLi.AspNetMvc.MvcSimplePager` ，对您造成的不便还请谅解。

## Contact

如果您在使用过程中遇到什么问题，您可以随时联系我：<weihanli@outlook.com>
