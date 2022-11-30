using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using PolicyProject.Data;
using PolicyProject.Services.PolicyServices;
using PolicyProject.Services.PolicyTypeServices;

namespace PolicyProject
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

            // To Ignore the loop while fetchin policies
            services.AddControllers().AddNewtonsoftJson(x =>
            {

                x.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
                x.SerializerSettings.MaxDepth = 1;
                x.SerializerSettings.ContractResolver = new DefaultContractResolver();
                x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            services.AddAutoMapper(typeof(Startup));


            services.AddDbContext<PolicyProjectContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("PolicyProjectContext")));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(oprions =>
            {
                oprions.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });


            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IPolicyTypeService, PolicyTypeService>();
            services.AddScoped<IPolicyservice, PolicyService>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //cors for frontend
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());


            app.UseRouting();
            //Authentication should be above authorization
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
