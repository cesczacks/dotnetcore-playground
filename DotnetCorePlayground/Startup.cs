using DotnetCorePlayground.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DotnetCorePlayground
{
	/// <summary>
	/// IConfiguration: 配置文件（appsettings.xxx.json）
	/// IServiceCollection: 依赖注入
	/// IApplicationBuilder：配置中间件
	/// IWebHostEnvironment：环境配置
	/// </summary>
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			// 权重 AddSingleton→AddTransient→AddScoped
			// ------------------------------
			// AddSingleton的生命周期：
			// 项目启动 - 项目关闭   相当于静态类 只会有一个
			// ------------------------------
			// AddScoped的生命周期：
			// 请求开始 - 请求结束  在这次请求中获取的对象都是同一个
			// ------------------------------
			// AddTransient的生命周期：
			// 请求获取 -（GC回收 - 主动释放） 每一次获取的对象都不是同一个

			services.AddControllers();
			services.AddSingleton<IMessage, Message>();
			// services.AddTransient<IMessage, MessagePlus>();
			// services.AddScoped<IMessage, MessagePlus>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
