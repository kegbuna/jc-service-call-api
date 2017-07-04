using System;
using System.Net;
using System.Threading.Tasks;
using jc_service_call_api.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace jc_service_call_api
{
    public class Startup
    {
        private IConfigurationRoot Configuration { get; set; }
        
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            builder.AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            // di
            services.AddTransient<IShiftRepository, ShiftRepository>();
            services.AddTransient<ICallCodeRepository, CallCodeRepository>();

            // config
            services.Configure<DBInfo>(info => {
                IConfigurationSection dbInfo = Configuration.GetSection("DBInfo");
                var connectionString = dbInfo.GetValue<string>("ConnectionString");
                info.ConnectionString = connectionString;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<HttpExceptionMiddleware>();
        }
    }

    internal class HttpExceptionMiddleware
    {
        private readonly RequestDelegate next;

        public HttpExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await this.next.Invoke(context);
            }
            catch (HttpException httpException)
            {
                context.Response.StatusCode = httpException.StatusCode;
                var responseFeature = context.Features.Get<IHttpResponseFeature>();
                responseFeature.ReasonPhrase = httpException.Message;
            }
        }
    }

    public class HttpException : Exception
    {
        private readonly int _httpStatusCode;

        public HttpException(int httpStatusCode)
        {
            this._httpStatusCode = httpStatusCode;
        }

        public HttpException(HttpStatusCode httpStatusCode)
        {
            this._httpStatusCode = (int)httpStatusCode;
        }

        public HttpException(int httpStatusCode, string message) : base(message)
        {
            this._httpStatusCode = httpStatusCode;
        }

        public HttpException(HttpStatusCode httpStatusCode, string message) : base(message)
        {
            this._httpStatusCode = (int)httpStatusCode;
        }

        public HttpException(int httpStatusCode, string message, Exception inner) : base(message, inner)
        {
            this._httpStatusCode = httpStatusCode;
        }

        public HttpException(HttpStatusCode httpStatusCode, string message, Exception inner) : base(message, inner)
        {
            this._httpStatusCode = (int)httpStatusCode;
        }

        public int StatusCode { get { return this._httpStatusCode; } }
    }

}
