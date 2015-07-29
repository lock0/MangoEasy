using System.Security.Claims;
using MangoEasy.Web.Models;
using Microsoft.AspNet.Identity;
using MongoDBApi.Web.Models;

namespace MongoDBApi.Web.Infrastructure
{
    public static class UserService
    {
        public static ClaimsIdentity CreateIdentity(UserModel user, string authenticationType)
        {
            var identity = new ClaimsIdentity(DefaultAuthenticationTypes.ApplicationCookie);
            identity.AddClaim(new Claim(ClaimTypes.Name, user.FirstName));
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            identity.AddClaim(new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", "ASP.NET Identity"));
            identity.AddClaim(new Claim("Id", user.Id.ToString()));
            return identity;
        }
    }
}