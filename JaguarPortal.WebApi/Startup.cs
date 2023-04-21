using AutoMapper;
using JaguarPortal.Core.Repositories;
using JaguarPortal.Infrastructure.ServiceExtensions;
using JaguarPortal.Services;
using JaguarPortal.Services.Interfaces;
using JaguarPortal.WebApi.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace JaguarPortal.WebApi
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
            ////Configuration Database Mongo
            //services.Configure<MongoDatabaseSettings>(Configuration.GetSection("MongoDatabaseSettings"));

            //ApiKeyAttribute.ApiKey = Configuration.GetSection("Security:APIKey").Value;

            //services.AddProblemDetails();

            // Auto Mapper Configurations
            IMapper mapper = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            }).CreateMapper();

            services.AddHttpContextAccessor();

            services.AddSingleton(mapper);

            services.AddDIServices(Configuration);

            #region Services
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISecurityService, SecurityService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAnalysisService, AnalysisService>();
            services.AddScoped<ISpectrumService, SpectrumService>();
            #endregion

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Jaguar Portal Web Api", Version = "v1" });
            });

            services.AddAuthorization();
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                var sp = services.BuildServiceProvider();
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(sp.GetRequiredService<ISecurityService>().GetSaltPassword()),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseProblemDetails();

            app.UseProblemDetailsExceptionHandler(loggerFactory);

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Jaguar Portal Web Api v1"));

            app.UseRouting();


            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}
