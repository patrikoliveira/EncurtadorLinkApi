using AutoMapper;
using EncurtadorLinkApi.Domain.Repositories;
using EncurtadorLinkApi.Domain.Services;
using EncurtadorLinkApi.Infrastructure.Repositories;
using EncurtadorLinkApi.Presentation.ViewModel;
using EncurtadorLinkApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ServiceStack.Redis;

namespace EncurtadorLinkApi
{
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "EncurtadorLinkApi", Version = "v1"});
            });

            services.AddSingleton<RedisClient>(new RedisClient(Configuration["Cache:Redis:Endpoint"]));

            services.AddScoped<IMongoContext, MongoContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ILinkEncurtadoRepository, LinkEncurtadoRepository>();
            services.AddSingleton<IRedisRepository, RedisRepository>();
            services.AddScoped<IRedisService, RedisService>();
            services.AddScoped<ILinkService, LinkService>();
            services.AddScoped<ILinkEncurtadoService, LinkEncurtadoService>();

            var mapperConfig = new MapperConfiguration(mc => mc.AddProfile(new MappingProfile()));
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EncurtadorLinkApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}