using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalleryProject.Data;
using GalleryProject.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace GalleryProject
{
    public class Startup
    {
        private const string SECRETKEY = "mykeyjwtmykeyjwtmykeyjwtmykeyjwtmykeyjwtmykeyjwtmykeyjwtmykeyjwt";
        public static readonly SymmetricSecurityKey SIGNINGKEY = new
            SymmetricSecurityKey(Encoding.UTF8.GetBytes(SECRETKEY));
        private readonly IConfiguration _config;
        public Startup(IConfiguration configuration)
        {
            _config = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped<AlbumRepository>();
            services.AddScoped<UserRepository>();
            services.AddScoped<PictureRepository>();
            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = "JwtBearer";
                options.DefaultChallengeScheme = "JwtBearer";
            }).AddJwtBearer("JwtBearer",jwtOptions=>
            {
                jwtOptions.TokenValidationParameters = new TokenValidationParameters()
                {
                    IssuerSigningKey = SIGNINGKEY,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = "https://localhost:44301",
                    ValidAudience = "https://localhost:44301",
                    ValidateLifetime = true
                };
            }) ;
            services.AddDbContext<GalleryContext>(
        options => options.UseSqlServer(_config.GetConnectionString("DefaultConnection")));
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
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
