using DATA_LAYER.CORE;
using DATA_LAYER.TREE;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using REPOSITORIES.FAMILY_REPO;
using REPOSITORIES.ROLE_REPO;
using REPOSITORIES.TREE_REPO;
using REPOSITORIES.USER_REPO;
using SERVICES.FAMILY_SERVICE;
using SERVICES.ROLE_SERVICE;
using SERVICES.TREE_SERVICE;
using SERVICES.URES_SERVICE;
using SHARED.COMMON_REPO;
using System.Text;

namespace FamilyTreeApi
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FamilyTreeApi", Version = "v1" });
            });
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey
                    (Encoding.UTF8.GetBytes(Configuration["Jwt:Key"])),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true
                };
            });

            services.AddAuthorization();

            services.AddDbContext<CoreContext>(option => option.UseSqlServer(Configuration.GetConnectionString("CoreConnection")));
            services.AddDbContext<TreeContext>(option => option.UseSqlServer(Configuration.GetConnectionString("TreeConnection")));

            #region Reposiories Injection

            #region Tree Database
            services.AddScoped<IFamilyRepo, FamilyRepo>();
            services.AddScoped<ITreeRepo, TreeRepo>();
            #endregion

            #region Core Database
            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<IRoleRepo, RoleRepo>();
            #endregion

            #endregion

            #region Services Injection
            #region Tree DataBase
            services.AddScoped<ITreeSevice, TreeService>();
            services.AddScoped<IFamilyService, FamilyService>();
            #endregion

            #region Core DataBase
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();
            #endregion
            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FamilyTreeApi v1"));
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
