using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using YES.Api.Data.Database;
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
                x.UseSqlServer(Configuration.GetConnectionString("OnlineConnectionString"));
            });

            services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
            
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<ITicketService, TicketService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITicketCustomerService, TicketCustomerService>();
            services.AddScoped<ITicketProviderService, TicketProviderService>();

            services.AddScoped<IEventRepo, EventRepo>();
            services.AddScoped<ITicketRepo, TicketRepo>();
            services.AddScoped<ITicketCustomerRepo, TicketCustomerRepo>();
            services.AddScoped<ITicketProviderRepo, TicketProviderRepo>();

            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ITokenService, TokenService>();

            services.AddControllersWithViews();
            services.AddRazorPages();
        }
    }
}