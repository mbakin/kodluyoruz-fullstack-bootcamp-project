using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Redis;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Movies.Business;
using Movies.Business.Extensions;
using Movies.DataAccess.Data;
using Movies.DataAccess.Repositories;

namespace MoviesAPI
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
            services.AddControllers(opt =>
            {
                opt.CacheProfiles.Add("List", new CacheProfile{Duration = 300});
            });
                    
            services.AddResponseCaching();
            services.AddMemoryCache();
            // You can deploy the cache mechanism on the server:
            services.AddDistributedRedisCache(opt =>
            {
                opt.Configuration = "genre_list:6666";
            });
            // Redis Dependency Injection:
            services.Add(ServiceDescriptor.Singleton<IDistributedCache, RedisCache>());

            services.AddMapperConfiguration();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IGenreRepository, EFGenreRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, FakeUserRepository>();
            var connectionString = Configuration.GetConnectionString("db");
            services.AddDbContext<MoviesDbContext>(option => option.UseSqlServer(connectionString));
            services.AddSwaggerGen(option => option.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Docs Header",
                Contact = new OpenApiContact
                {
                    Email = "mehmetberkakinn@gmail.com",
                    Name = "Mehmet Berk"
                },
                Version = "v1"
            }));

            var issuer = Configuration.GetSection("Bearer")["Issuer"];
            var audience = Configuration.GetSection("Bearer")["Audience"];
            var securityKey = Configuration.GetSection("Bearer")["SecurityKey"];

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateActor = true,
                        ValidateAudience = true,
                        ValidateIssuer = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = issuer,
                        ValidAudience = audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey))
                    };
                });
            // Cross origin request
            /*
             * Same Origin === origin:domain
             * https://www.turkayurkmez.com/index.html
             * https://www.turkayurkmez.com/index.php
             *
             *  Different Origin
             * https://www.turkayurkmez.com/index.html
             * https://info.turkayurkmez.com
             * https://www.turkayurkmez.com:1444/index.html
             *
             */
            services.AddCors(opt =>
            {
                opt.AddPolicy("Allow", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(opt => opt.SwaggerEndpoint("/swagger/v1/swagger.JSON", "Movies.API"));
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("Allow");
            
            app.UseAuthentication();
            
            app.UseAuthorization();

            app.UseResponseCaching();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
