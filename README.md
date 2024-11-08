
<h1 align="center">
  <br>
  <a href="http://www.amitmerchant.com/electron-markdownify"><img src="https://raw.githubusercontent.com/amitmerchant1990/electron-markdownify/master/app/img/markdownify.png" alt="Markdownify" width="200"></a>
  <br>
  Chatty.Blogs
  <br>
</h1>

<h4 align="center">Chatty.Blgos 基于.Net8 MVC打造， 是一款专为科技商务领域打造的现代化博客内容管理系统。它不仅提供了丰富的前端页面展示选项，如首页、博客列表、专栏文章等，还拥有强大的后台管理功能，包括文章编辑、分类管理、AI辅助写作等，旨在帮助个人或企业轻松搭建专业的在线知识分享平台。</h4>



<p align="center">
  <a href="#关键特性">关键特性</a> •
  <a href="#准备工作">准备工作</a> •
  <a href="#如何使用">如何使用</a> •
  <a href="#我的邮箱">我的邮箱</a> •
  <a href="#感谢这些项目">感谢这些项目</a> •
  <a href="#license">License</a>
</p>

![screenshot](https://raw.githubusercontent.com/amitmerchant1990/electron-markdownify/master/app/img/markdownify.gif)

## 关键特性

* 现代化设计
  - 采用最新的前端技术栈，提供响应式布局，确保在不同设备上都能获得优秀的阅读体验.
* 全面的内容管理
  - 从文章创建到分类管理，再到专栏设置，一应俱全的功能让内容管理变得简单高效.
* AI辅助写作  
  - 集成先进的人工智能技术，支持文章的改进、续写与丰富，帮助作者提高创作效率
* 灵活的定制选项
  - 通过后台设置，用户可以根据自身需求对网站进行个性化配置
* 易用的后台界面
  - 简洁直观的操作界面，使得即使是非技术人员也能快速上手。
* 强大的SEO支持
  - 内置SEO优化工具，帮助提升网站搜索引擎排名，吸引更多流量
* 跨平台部署
  - Windows, macOS and Linux ready.

## 准备工作

1、安装 Visual Studio 2022 开发工具  
2、安装MySQL 8.0 数据库

## 如何使用



1、使用git克隆仓库:

```bash
# 克隆仓库
$ git clone https://github.com/chatty-go/Chatty.Blogs.git

```

2、创建数据库  

在根目录下面找到database文件夹，里面有数据库脚本，使用数据库管理工具创建数据库并导入脚本。



3、配置数据库连接字符串

在Web项目下找到appsettings.json，配置数据库连接字符串
```
server=localhost;Database=chatty_blogs;Uid=;Pwd=
```


4、启动项目
在根目录下面找到解决方案文件 Chatty.Blogs.sln，右键使用 Visual Studio 2022 打开项目，然后按F5启动项目。

5、访问 http://localhost:5000 即可访问前台网站。

6、访问 http://localhost:5000/admin 即可访问后台管理。

默认用户名：admin  
默认密码：123456


## 如何部署  

### Windows IIS

1、发布项目: 右键点击项目，选择发布，选择发布到文件系统，选择发布路径，然后点击发布。
2、在服务器中安装.netcore 8 运行时  
3、在服务器创建一个目录，例如：D:\chatty，把打包后的项目放到这个目录下面  
4、在IIS中创建一个网站，指向这个目录，然后重启IIS即可。  


### Linux Ubuntu  

On My Way !!   
HH  



## 我的邮箱

如果您喜欢这个项目并且帮助到你，欢迎给我发邮件，我会很乐意收到您的反馈。邮箱地址：[chatty-go@outlook.com](chatty-go@outlook.com)

## 感谢这些项目

本项目使用了以下开源项目包:

- [.net8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [sqlsugar](https://www.donet5.com/Doc/1)
- [bootstrap](https://getbootstrap.com/)
- [aieditor.js](https://aieditor.dev/zh/getting-started.html)
- [masonry](https://masonry.desandro.com/)
- [dayjs](https://dayjs.fenxianglu.cn/)
- [ztree](https://docs.caacle.com/zTree_v3/index.html)
- [waypoints.js](http://imakewebthings.com/waypoints/)
- [highlight.js](https://highlightjs.org/)


## License

MIT

---

> GitHub [@chatty-go](https://github.com/chatty-go) &nbsp;&middot;&nbsp;

