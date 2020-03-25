using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetCorePlayground.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DotnetCorePlayground
{
	/// <summary>
	/// IConfiguration: �����ļ���appsettings.xxx.json��
	/// IServiceCollection: ����ע��
	/// IApplicationBuilder�������м��
	/// IWebHostEnvironment����������
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
			// Ȩ�� AddSingleton��AddTransient��AddScoped
			// ------------------------------
			// AddSingleton���������ڣ�
			// ��Ŀ���� - ��Ŀ�ر�   �൱�ھ�̬�� ֻ����һ��
			// ------------------------------
			// AddScoped���������ڣ�
			// ����ʼ - �������  ����������л�ȡ�Ķ�����ͬһ��
			// ------------------------------
			// AddTransient���������ڣ�
			// �����ȡ -��GC���� - �����ͷţ� ÿһ�λ�ȡ�Ķ��󶼲���ͬһ��

			services.AddControllers();
			services.AddSingleton<IMessage, Message>();
			// services.AddTransient<IMessage, MessagePlus>();
			services.AddScoped<IMessage, MessagePlus>();
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
