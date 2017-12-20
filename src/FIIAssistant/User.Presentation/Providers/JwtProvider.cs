using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EnsureThat;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using User.Data.Model.Interfaces.Services;

namespace User.Presentation.Providers
{
    public class JwtProvider
    {
        public IConfiguration Configuration { get; }
        
        public static string TokenEndPoint = "/api/login";

        private IAuthenticationService _authenticationService;
        private readonly RequestDelegate _next;

        public JwtProvider(RequestDelegate next, IConfiguration configuration)
        {
            Ensure.That(configuration).IsNotNull();
            Configuration = configuration;

            _next = next;
        }

        public Task Invoke(HttpContext httpContext, IAuthenticationService authenticationService)
        {
            Ensure.That(authenticationService).IsNotNull();
            _authenticationService = authenticationService;

            //Check if the request path matches login path
            if (!httpContext.Request.Path.Equals(TokenEndPoint, StringComparison.Ordinal))
                return _next(httpContext);

            // Check if the current request is a valid POST with the appropriate content type (application/x-www-form-urlencoded)
            if (httpContext.Request.Method.Equals("POST") && httpContext.Request.HasFormContentType)
                return CreateToken(httpContext);

            // Not OK: output a 400 - Bad request HTTP error.
            httpContext.Response.StatusCode = 400;
            return httpContext.Response.WriteAsync("Bad request.");
        }

        private async Task CreateToken(HttpContext httpContext)
        {
            try
            {
                // retrieve the relevant FORM data
                string email = httpContext.Request.Form["email"];
                string password = httpContext.Request.Form["password"];

                // check if there's an user with the given email
                var user = _authenticationService.FindUserByEmail(email);

                var success = user != null && _authenticationService.ValidateUserPassword(user, password);
                if (success)
                {
                    var now = DateTime.UtcNow;

                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Iss, Configuration["Auth:Jwt:Issuer"]),
                        new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, new DateTimeOffset(now).ToUnixTimeSeconds().ToString(),
                            ClaimValueTypes.Integer64)
                        // add additional claims here, if necessary
                    };

                    var tokenExpirationMins =
                        Configuration.GetValue<int>("Auth:Jwt:TokenExpirationInMinutes");
                    var issuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(Configuration["Auth:Jwt:Key"]));

                    // Create the JWT and write it to a string
                    var token = new JwtSecurityToken(
                        issuer: Configuration["Auth:Jwt:Issuer"],
                        audience: Configuration["Auth:Jwt:Audience"],
                        claims: claims,
                        notBefore: now,
                        expires: now.Add(TimeSpan.FromMinutes(tokenExpirationMins)),
                        signingCredentials: new SigningCredentials(
                            issuerSigningKey, SecurityAlgorithms.HmacSha256));
                    var encodedToken = new JwtSecurityTokenHandler().WriteToken(token);

                    // build the json response
                    var jwt = new
                    {
                        accessToken = encodedToken,
                        userId = user.Id,
                        expiration = TimeSpan.FromMinutes(tokenExpirationMins)
                    };

                    // return token
                    httpContext.Response.ContentType = "application/json";
                    await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(jwt));
                    return;
                }
            }
            catch (Exception e)
            {
                //Todo: handle possible errors
                throw e;
            }

            httpContext.Response.StatusCode = 400;
            await httpContext.Response.WriteAsync("Invalid username or password.");
        }
    }


    //Extension method used to add the middleware to the HTTP request pipeline.
    public static class JwtProviderExtensions
    {
        public static IApplicationBuilder UseJwtProvider(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<JwtProvider>();
        }
    }
}