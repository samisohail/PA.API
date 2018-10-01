using API.Common;
using API.Common.Contracts;
using API.DataAccess.DataContext;
using API.DataAccess.Repositories;
using API.DataAccess.Repositories.Contracts;
using API.Services.Contracts;
using API.Services.Contracts.Encryption;
using API.Services.Implementations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace PA.API
{
    public class Startup
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfiguration _config;
        private readonly ILoggerFactory _loggerFactory;
        private readonly string _validIssuer;
        private readonly SecurityKey _signingKey;


        const string PlatformConnnectionString = "PlatformConnectionString";

        public Startup(IHostingEnvironment env, IConfiguration config, ILoggerFactory loggerFactory)
        {
            _env = env;
            _config = config;
            _loggerFactory = loggerFactory;
            _validIssuer = config.GetSection("jwt")["pa247authority"];
            _signingKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes("PakGrwiepoxjedLaDiEpGBVxxkpqWYzztbl"));

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            var logger = _loggerFactory.CreateLogger<Startup>();

            if (_env.IsDevelopment())
            {
                logger.LogInformation("Development");
            }
            else
            {
                logger.LogInformation($"Environment: {_env.EnvironmentName }");
            }

            services.AddDbContext<PA24Context>(options => options.UseSqlServer(_config.GetConnectionString(PlatformConnnectionString)));

            services.AddCors();
            services.AddMemoryCache();

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IProjectService, ProjectService>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IPA24Context, PA24Context>();

            services.AddTransient<IOrgService, OrgService>();
            services.AddTransient<IOrganisationRepository, OrganisationRepository>();

            services.AddSingleton<IDateTimeHelper, DateTimeHelper>();
            services.AddSingleton<IGuidFactory, GuidFactory>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IAuthRepository, AuthRepository>();

            services.AddSingleton<IEncryptPBKDF2, EncryptPBKDF2>();

            services.AddAuthentication(Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidAudience = "87614612-181b-4966-8fde-cab9987cfda5",
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        // RequireSignedTokens = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = _validIssuer,
                        IssuerSigningKey = _signingKey
                    };
                }).AddJwtBearer(options =>
                {
                    options.Events = new JwtBearerEvents
                    {
                        OnTokenValidated = context =>
                        {
                            // Check if the user has an OID claim
                            if (!context.Principal.HasClaim(c => c.Type == "http://schemas.microsoft.com/identity/claims/objectidentifier"))
                            {
                                context.Fail($"The claim 'oid' is not present in the token.");
                            }

                            System.Security.Claims.ClaimsPrincipal userPrincipal = context.Principal;
                        }
                    };
                });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();

            var supportedCultures = new[] { new System.Globalization.CultureInfo("en-AU") };
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("en-AU"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });            

            app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());           

        }
    }
}
