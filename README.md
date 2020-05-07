# ASP NET CORE

**官方文档: **

https://docs.microsoft.com/zh-cn/aspnet/core/fundamentals/?view=aspnetcore-3.1&tabs=windows



## 1.项目结构

| 目录/文件    | 说明 |
| :---------- | ----------- |
| 依赖项      | ASP.NET Core 开发、构建和运行过程中的依赖项       |
| appsettings.json | 项目配置文件    |
| Properties/launchSettings.json | 启动配置文件，为一个 ASP.NET Core 应用保存特有的配置标准，用于应用的启动准备工作，包括环境变量，开发端口等 |
| Program.cs   | 包含了 ASP.NET Core 应用的 Main 方法，负责配置和启动应用程序 |
| Startup.cs   | Startup.cs 文件是 ASP.NET Core 的项目的入口启动文件       |



## 2.appsettings.xxx.json

项目配置文件。根据需求可以设置不同环境的配置文件 (appsettings.Local.json, appsettings.Development.json, appsettings.Production.json....)。

- 数据库连接字符串
- 日志配置
- 常量 (SMTP信息..)
- ...



## 3.中间件

- 处理流程

  https://docs.microsoft.com/zh-cn/aspnet/core/fundamentals/middleware/?view=aspnetcore-3.1

- 例子

  ```csharp
  public class Startup
  {
      public void Configure(IApplicationBuilder app)
      {
          app.Use(async (context, next) =>
              {
                  await context.Response.WriteAsync("进入第一个委托 执行下一个委托之前\r\n");
                  //调用管道中的下一个委托
                  await next.Invoke();
                  await context.Response.WriteAsync("结束第一个委托 执行下一个委托之后\r\n");
              });
          
          app.Run(async context =>
              {
                   await context.Response.WriteAsync("进入第二个委托\r\n");
                   await context.Response.WriteAsync("Hello from 2nd delegate.\r\n");
                   await context.Response.WriteAsync("结束第二个委托\r\n");
               });
      }
  }
  // -------结果--------
  // 进入第一个委托 执行下一个委托之前
  // 进入第二个委托
  // Hello from 2nd delegate.
  // 结束第二个委托
  // 结束第一个委托 执行下一个委托之后
  ```



## 4.依赖注入

- 依赖注入三种方式

  - AddSingleton: 项目启动 - 项目关闭   相当于静态类 只会有一个
  - AddScoped: 请求开始 - 请求结束  在这次请求中获取的对象都是同一个
  - AddTransient: 请求获取 -（GC回收 - 主动释放） 每一次获取的对象都不是同一个

- 注入方法

  ```csharp
  services.AddTransient<IMessage, MessagePlus>(); // 接口，实现类
  ```

- 运用

  ```csharp
  public class MessageController : ControllerBase
  {
  
      private readonly IMessage _messageService;
  
      // 使用构造器，注入IMessage
      public MessageController(IMessage messageService)
      {
          _messageService = messageService;
      }
  
      public string GetMessage()
      {
          return _messageService.PrintMessage();
      }
  }
  ```

  

# EF Core

**官方文档：**

https://docs.microsoft.com/zh-cn/ef/core/managing-schemas/migrations/?tabs=vs



## 一些基本的EF命令

| 命令             | 例子                                                         | 说明                   |
| ---------------- | :----------------------------------------------------------- | ---------------------- |
| Add-Migration    | Add-Migration SprintX_Add{TableName}<br />Add-Migration SprintX_Modify{TableName}<br />Add-Migration SprintX_Remove{TableName} | 生成新的迁移文件       |
| Update-Database  | -                                                            | 根据迁移文件更新数据库 |
| Script-Migration | Script-Migration 20200429053218_Sprint1_TableInit 20200429053529_Sprint1_AddPermission | 生成 SQL 脚本          |

## Migrations

- EF Core 中的迁移功能能够以递增方式更新数据库架构，使其与应用程序的数据模型保持同步，同时保留数据库中的现有数据。

## OnModelCreating

通过Fluent API配置实体

- 设置主外键关系

  ```csharp
  public void Configure(EntityTypeBuilder<Permission> builder)
  {
      // 主键
  	builder.HasKey(x => x.Id);
      // 联合主键
      builder.HasAlternateKey(x => new
      {
          x.Id,
          x.Name
      });
  }
  ```

- 基础数据

  ```csharp
  public void Configure(EntityTypeBuilder<Permission> builder)
  {
      builder.HasData(new List<Team>
                      {
                          new Team
                          {
                              Id = 1,
                              Name = "Arsenal"
                          },
                          new Team
                          {
                              Id = 2,
                              Name = "Liverpool"
                          }
                      });
  }
  ```

- 设置索引

  ```csharp
  public void Configure(EntityTypeBuilder<Permission> builder)
  {
      builder.HasIndex(x => x.Id);
  }
  ```

- 设置Property

  ```csharp
  public void Configure(EntityTypeBuilder<Permission> builder)
  {
      builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
  }
  ```





















