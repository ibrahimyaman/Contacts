using AutoMapper;
using Contact.API.Services;
using Contact.API.Utilities;
using Contact.API.Utilities.Mapper.AutoMapperProfiles;
using Contact.Bussiness.Abstract;
using Contact.Bussiness.Concrete;
using Contact.DataAccess.Abstract;
using Contact.DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Contact.API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson(o => o.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IContactInfoService, ContactInfoService>();
            services.AddScoped<IReportService, ReportService>();
            services.AddScoped<IMessageQueueService, RabbitMQService>();
            services.AddScoped<IPersonDal, EfPersonDal>();
            services.AddScoped<IContactInfoDal, EfContactInfoDal>();
            services.AddScoped<IReportDal, EfReportDal>();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new PersonProfile());
                mc.AddProfile(new ContactInfoProfile());
            });

            services.AddSingleton(mapperConfig.CreateMapper());

            services.AddHostedService<ReportCreatorService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            StaticServiceProvider.Provider = app.ApplicationServices;

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseExceptionHandler("/error");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
