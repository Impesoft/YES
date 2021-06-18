using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Web;
using System.Linq;
using Microsoft.OpenApi.Models;
using YES.Api.Data.Database;
using YES.Api.Data.Entities;
using YES.Api.Data.Repos;
using YES.Api.Configuration;
using YES.Api.Business.Services;
using YES.Api.Data.Repos.Interfaces;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace YES.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Yes v1"));
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:5000"));
            //app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:5001"));
            //app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:5002"));
            //app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:5003"));         
            //app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://192.168.0.185:5003"));
            //app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://192.168.0.185:5002"));


            //app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:44316"));
            app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:44317"));

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddCors();
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddMicrosoftIdentityWebApi(Configuration.GetSection("AzureAd"));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["TokenKey"])),
                    };
                });

            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "Yes", Version = "v1" }));

            services.AddDbContext<YesDBContext>(x =>
            {
                x.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString"));
            });

            services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
            
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<ITicketCustomerService, TicketCustomerService>();
            services.AddScoped<ITicketService, TicketService>();
            services.AddScoped<IUserService, UserService>();
            

            services.AddScoped<IEventRepo, EventRepo>();
            services.AddScoped<ITicketCustomerRepo, TicketCustomerRepo>();
            services.AddScoped<ITicketRepo, TicketRepo>();
            services.AddScoped<ITicketProviderRepo, TicketProviderRepo>();

            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ITokenService, TokenService>();

            services.AddControllersWithViews();
            services.AddRazorPages();
        }
    }
}