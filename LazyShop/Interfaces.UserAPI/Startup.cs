using Application;
using Interfaces.UserAPI.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Text;

namespace Interfaces.UserAPI
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            // 添加mvc
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // ioc
            services.AddScoped<IAuthAppService, AuthAppService>();
            services.AddScoped<IUserAppService, UserAppService>();

            // jwt校验
            services.Configure<JwtSetting>(Configuration.GetSection("JwtSetting"));
            var jwtSetting = new JwtSetting();
            Configuration.Bind("JwtSetting", jwtSetting);
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = jwtSetting.Issuer,
                        ValidAudience = jwtSetting.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSetting.SecurityKey)),
                        // 默认允许 300s  的时间偏移量，设置为0
                        ClockSkew = TimeSpan.Zero
                    };
                });


            // 注册swagger生成器
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "user api",
                    Version = "v1",
                    Description = "懒虫商城--user api",
                    TermsOfService = new Uri("http://www.baidu.com"),
                    Contact = new OpenApiContact
                    {
                        Name = "lazy",
                        Email = "邮箱",
                        Url = new Uri("http://www.baidu.com")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "许可证名字",
                        Url = new Uri("http://www.baidu.com")
                    }
                });

                // 为 Swagger JSON and UI设置xml文档注释路径
                var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);
                //获取应用程序所在目录（绝对，不受工作目录影响，建议采用此方法获取路径）
                //添加接口XML的路径
                var xmlPath = Path.Combine(basePath, "Interfaces.UserAPI.xml");
                //如果需要显示控制器注释只需将第二个参数设置为true
                c.IncludeXmlComments(xmlPath, true);
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            // 启用授权校验
            app.UseAuthentication();

            app.UseHttpsRedirection();
            app.UseMvc();

            // 使用swagger
            app.UseSwagger();
            app.UseSwaggerUI((c) =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "USER API V1");
            });
        }
    }
}
