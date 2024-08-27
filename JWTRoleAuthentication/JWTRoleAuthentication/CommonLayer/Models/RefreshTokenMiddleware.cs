using Microsoft.Extensions.Options;
using System.Data.SqlClient;
using System.Data;
using JWTRoleAuthentication.JWTDAL;
using System.Reflection;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.DependencyInjection;

namespace JWTRoleAuthentication.CommonLayer.Models
{ 
    public class RefreshTokenMiddleware
    {

        private readonly RequestDelegate _next;
        private readonly IOptions<JWT> _jwt;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IOptions<ConnectionStrings> _config;

        public RefreshTokenMiddleware
            (
            RequestDelegate next,
            IOptions<JWT> jwt,

            IHttpContextAccessor httpContextAccessor,

                    IOptions<ConnectionStrings> config
                 )
        {
            _next = next;
            _jwt = jwt;
            _httpContextAccessor = httpContextAccessor;
            _config = config;

        }

        //public async Task Invoke(HttpContext context, IServiceProvider serviceProvider)
        //{
        //    using var scope = serviceProvider.CreateScope();

        //    var _repo = scope.ServiceProvider.GetRequiredService<IAuthRepo>();
        //    var _helpers = scope.ServiceProvider.GetRequiredService<Helpers>();
        //    var tokenValidityInMinutes = _jwt.Value.TokenValidityInMinutes;
        //    var refreshTokenValidityInMinutes = _jwt.Value.RefreshTokenValidityInMinutes;

        //    var refreshToken = context.Request.Cookies["RefreshToken"];
        //    var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        //    var tokenCookie = context.Request.Cookies["Token"];
        //    string connection = _config.Value.AuthDBCon.ToString();

        //    if (string.IsNullOrEmpty(tokenCookie) || string.IsNullOrEmpty(token) || string.IsNullOrEmpty(refreshToken))
        //    {
        //        if (IsEnabledUnathourizedRoute(context))
        //        {
        //            await _next(context);
        //        }
        //        else
        //        {
        //            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
        //            context.Response.ContentType = "application/json";
        //            await context.Response.WriteAsJsonAsync(new { message = "Invalid token credentials" });
        //        }
        //        return;
        //    }

        //    if (!string.IsNullOrEmpty(token) && !string.IsNullOrEmpty(refreshToken) && !string.IsNullOrEmpty(tokenCookie) && token == tokenCookie)
        //    {

        //        if (IsRefreshTokenExpired(refreshToken))
        //        {
        //            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
        //            context.Response.ContentType = "application/json";
        //            await context.Response.WriteAsJsonAsync(new { message = "Refresh token is expired. Please login again." });
        //            return;
        //        }

        //        if (IsTokenExpired(token))
        //        {
        //            var principal = _helpers.GetPrincipalFromExpiredToken(token);
        //            if (principal == null)
        //            {
        //                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
        //                context.Response.ContentType = "application/json";
        //                await context.Response.WriteAsJsonAsync(new { message = "Invalid token credentials" });
        //                return;
        //            }

        //            string userName = principal.Identity.Name;
        //            string role = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
        //            var storeId = principal.Claims.FirstOrDefault(c => c.Type == "StoreId")?.Value;

        //            using (SqlConnection conn = new SqlConnection(connection))
        //            {
        //                await conn.OpenAsync();
        //                SqlCommand checkUser = new SqlCommand("Get_UserName", conn);
        //                checkUser.CommandType = System.Data.CommandType.StoredProcedure;
        //                checkUser.Parameters.AddWithValue("@UserName", userName);
        //                string existUser = (string)checkUser.ExecuteScalar();
        //                await conn.CloseAsync();

        //                var user = await _repo.GetUserDetails(existUser);
        //                if (existUser != userName)
        //                {
        //                    context.Response.StatusCode = StatusCodes.Status404NotFound;
        //                    context.Response.ContentType = "application/json";
        //                    await context.Response.WriteAsJsonAsync(new { message = "Invalid token credentials" });
        //                    return;
        //                }
        //                else
        //                {
        //                    var newAccessToken = _helpers.GenerateJwtToken(user.Register.UserName, user.Register.Email, user.Register.StoreID, user.Register.DateOfBirth, user.Register.Role);
        //                    var newRefreshToken = _helpers.GenerateRefreshToken();

        //                    _httpContextAccessor.HttpContext.Response.Cookies.Append("Token", newAccessToken, new CookieOptions
        //                    {
        //                        HttpOnly = true,
        //                        SameSite = SameSiteMode.Strict
        //                    });

        //                    _httpContextAccessor.HttpContext.Response.Cookies.Append("RefreshToken", newRefreshToken, new CookieOptions
        //                    {
        //                      //  Expires = DateTime.Now.AddMinutes(_jwt.Value.RefreshTokenValidityInMinutes),
        //                        HttpOnly = true,
        //                        SameSite = SameSiteMode.Strict
        //                    });

        //                    string userID = user.Register.UserID.ToString().ToUpper();

        //                    var tokenModel = new TokenModel
        //                    {
        //                        Token = newAccessToken,
        //                        RefreshToken = newRefreshToken,
        //                        RefreshTokenExpiresIn = DateTime.Now.AddMinutes(_jwt.Value.RefreshTokenValidityInMinutes),
        //                    };
        //                    var updateToken = await _repo.UpdateTokenToDB(tokenModel, userID);

        //                    //  context.Response.StatusCode = StatusCodes.Status200OK;
        //                    //  context.Response.ContentType = "application/json";
        //                    //  await context.Response.WriteAsJsonAsync(new { message = "Token refreshed successfully..." });

        //                    context.Request.Headers["Authorization"] = $"Bearer {newAccessToken}";
        //                  //  await _next(context);
        //                   // return;

        //                }
        //            }
        //        }
        //    }

        //    await _next(context);
        //}


        //public async Task Invoke(HttpContext context, IServiceProvider serviceProvider)
        //{
        //    // for Account controller
        //    //var path = context.Request.Path;
        //    //if ( path.StartsWithSegments("/api/Account") )
        //    //{
        //    //    await _next(context);
        //    //    return;
        //    //}
        //    using var scope = serviceProvider.CreateScope();

        //    var _repo = scope.ServiceProvider.GetRequiredService<IAuthRepo>();
        //    var _helpers = scope.ServiceProvider.GetRequiredService<Helpers>();
        //    var tokenValidityInMinutes = _jwt.Value.TokenValidityInMinutes;
        //    var refreshTokenValidityInMinutes = _jwt.Value.RefreshTokenValidityInMinutes;

        //    var refreshToken = context.Request.Cookies["RefreshToken"];
        //    var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        //    var tokenCookie = context.Request.Cookies["Token"];
        //    string connection = _config.Value.AuthDBCon.ToString();

        //    if (string.IsNullOrEmpty(tokenCookie) || string.IsNullOrEmpty(token) || string.IsNullOrEmpty(refreshToken))


        //    {
        //        if (IsEnabledUnathourizedRoute(context))
        //        {
        //            await _next(context);
        //        }
        //        else
        //        {

        //            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
        //            context.Response.ContentType = "application/json";
        //            await context.Response.WriteAsJsonAsync(new { message = "Invalid token credentials" });
        //        }


        //        return;
        //    }
        //    if (!string.IsNullOrEmpty(token) && !string.IsNullOrEmpty(refreshToken) && !string.IsNullOrEmpty(tokenCookie) && token == tokenCookie)


        //    {
        //        if (IsTokenExpired(token) || IsTokenExpired(tokenCookie))
        //        {
        //            var principal = _helpers.GetPrincipalFromExpiredToken(token);
        //            if (principal == null)
        //            {
        //                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
        //                context.Response.ContentType = "application/json";
        //                await context.Response.WriteAsJsonAsync(new { message = "Invalid token credentials" });
        //                return;
        //            }
        //            string userName = principal.Identity.Name;
        //            string role = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

        //            var storeId = principal.Claims.FirstOrDefault(c => c.Type == "StoreId")?.Value;


        //            using (SqlConnection conn = new SqlConnection(connection))
        //            {
        //                await conn.OpenAsync();
        //                SqlCommand checkUser = new SqlCommand("Get_UserName", conn);
        //                checkUser.CommandType = System.Data.CommandType.StoredProcedure;
        //                checkUser.Parameters.AddWithValue("@UserName", userName);
        //                string existUser = (string)checkUser.ExecuteScalar();
        //                await conn.CloseAsync();
        //                var user = await _repo.GetUserDetails(existUser);
        //                if (existUser != userName)
        //                {

        //                    context.Response.StatusCode = StatusCodes.Status404NotFound;
        //                    context.Response.ContentType = "application/json";
        //                    await context.Response.WriteAsJsonAsync(new { message = "Invalid token credentials" });
        //                    return;
        //                }
        //                else
        //                {
        //                    var newAccessToken = _helpers.GenerateJwtToken(user.Register.UserName, user.Register.Email, user.Register.StoreID, user.Register.DateOfBirth, user.Register.Role);
        //                    var newRefreshToken = _helpers.GenerateRefreshToken();
        //                    // tokenResponse.TokenModel.Token = newAccessToken;
        //                    //tokenResponse.TokenModel.RefreshToken = newRefreshToken;
        //                    // tokenResponse.TokenModel.RefreshTokenExpiresIn = DateTime.Now.AddMinutes(_jwt.Value.RefreshTokenValidityInMinutes);

        //                    _httpContextAccessor.HttpContext.Response.Cookies.Append("Token", newAccessToken, new CookieOptions
        //                    {

        //                        // Expires = DateTime.UtcNow.AddMinutes(_jwt.Value.TokenValidityInMinutes),

        //                        //Secure = true,
        //                        //IsEssential = true,
        //                        //SameSite = SameSiteMode.None

        //                        HttpOnly = true,
        //                        SameSite = SameSiteMode.Strict
        //                    });
        //                    _httpContextAccessor.HttpContext.Response.Cookies.Append("RefreshToken", newRefreshToken, new CookieOptions
        //                    {

        //                        Expires = DateTime.Now.AddMinutes(_jwt.Value.RefreshTokenValidityInMinutes),

        //                        //Secure = true,
        //                        //IsEssential = true,
        //                        //SameSite = SameSiteMode.None

        //                        HttpOnly = true,
        //                        SameSite = SameSiteMode.Strict
        //                    });
        //                    string userID = user.Register.UserID.ToString().ToUpper();

        //                    var tokenModel = new TokenModel
        //                    {
        //                        Token = newAccessToken,
        //                        RefreshToken = newRefreshToken,
        //                        RefreshTokenExpiresIn = DateTime.Now.AddMinutes(_jwt.Value.RefreshTokenValidityInMinutes),
        //                    };
        //                    var updatetoken = await _repo.UpdateTokenToDB(tokenModel, userID);

        //                    context.Response.StatusCode = StatusCodes.Status200OK;
        //                    context.Response.ContentType = "application/json";
        //                    await context.Response.WriteAsJsonAsync(new { message = "Token refreshed successully..." });
        //                    await _next(context);
        //                    return;

        //                }
        //            }

        //        }


        //    }

        //    await _next(context);
        //}

        private bool IsEnabledUnathourizedRoute(HttpContext context)
        {
            List<string> enableRoutes = new List<string>
            {
                "/api/Account/Login",
                "/api/Account/SignUp",
                "/api/Account/Refresh",
                "/api/Account/GetUserDetails"
            };
            bool isEnableRoutes = false;
            if (context.Request.Path.Value is not null)
            {
                isEnableRoutes = enableRoutes.Contains(context.Request.Path.Value);
            }
            return isEnableRoutes;
        }

        private bool IsTokenExpired(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);
            return jwtToken.ValidTo < DateTime.UtcNow;
        }
        private bool IsRefreshTokenExpired(string refreshToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtRefreshToken = tokenHandler.ReadToken(refreshToken);
            return jwtRefreshToken.ValidTo < DateTime.UtcNow;
        }
        public async Task Invoke(HttpContext context, IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();

            var _repo = scope.ServiceProvider.GetRequiredService<IAuthRepo>();
            var _helpers = scope.ServiceProvider.GetRequiredService<Helpers>();
            
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            int tokenExist = 0;

            string dbRefreshToken = null;

            string dbToken = null;

            if (token != null)
            {
                tokenExist = await _helpers.ValidateDBToken(token);
            }


            if (tokenExist > 0)
            {

                var getTokens = await _helpers.GetDBTokenDetailsByToken(token);

                dbRefreshToken = getTokens.RefreshToken;
                dbToken = getTokens.Token;
            }

            if (string.IsNullOrEmpty(token) || string.IsNullOrEmpty(dbRefreshToken))
            {
                if (IsEnabledUnathourizedRoute(context))
                {
                    await _next(context);
                }
                else
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsJsonAsync(new { message = "Invalid token credentials" });
                }
                return;
            }

            if (!string.IsNullOrEmpty(token) && !string.IsNullOrEmpty(dbRefreshToken) && token == dbToken)
            {
                var principal = _helpers.GetPrincipalFromExpiredToken(token);
                string userName = principal.Identity.Name;
                var user = await _repo.GetUserDetails(userName);

                if (IsRefreshTokenExpired(dbRefreshToken))
                {

               
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsJsonAsync(new { message = "Refresh token is expired. Please login again." });
                return;

            }

                if (IsTokenExpired(token))
                {

                    if (principal == null || userName != user.Register.UserName)
                    {
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        context.Response.ContentType = "application/json";
                        await context.Response.WriteAsJsonAsync(new { message = "Invalid token credentials" });
                        return;
                    }

                    var newAccessToken = _helpers.GenerateJwtToken(user.Register.UserName, user.Register.Email, user.Register.StoreID, user.Register.DateOfBirth, user.Register.Role);
                   
                    // new refreshtoken      if token expired add new refresh token.
                  //  var newRefreshToken = _helpers.GenerateRefreshToken();


                    // still active Refreshtoken not  expired.   so we dont add new refreshtoken:
                     var newRefreshToken = dbRefreshToken;

                    string userID = user.Register.UserID.ToString().ToUpper();

                    var tokenModel = new TokenModel
                    {
                        Token = newAccessToken,
                        RefreshToken = newRefreshToken,

                    };
                    var updateToken = await _repo.UpdateTokenToDB(tokenModel, userID);
                    context.Response.Headers.Add("AccessToken", newAccessToken);

                  //  context.Response.Headers.Add("RefreshToken", newRefreshToken);


                    // await _next(context);
                    //return;




                }

                await _next(context);
            }



            

        }
    }
}