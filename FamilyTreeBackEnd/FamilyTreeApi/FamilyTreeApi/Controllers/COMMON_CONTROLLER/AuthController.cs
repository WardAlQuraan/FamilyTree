using ENTITIES.BASE_ENTITY;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using SHARED.CLAIM_HELPER;
using SHARED.COMMON_SERVICES;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace FamilyTreeApi.Controllers.COMMON_CONTROLLER
{

    [Authorize]
    public class AuthController<T> : CommonController<T> where T : BaseEntity
    {
        public AuthController(ICommonService<T> service ) : base(service)
        {
            
        }

        [NonAction]
        protected virtual string GetToken()
        {
            string token = "";
            string bearerPrefix = "Bearer ";
            if(Request.Headers.TryGetValue("Authorization",out StringValues headerValues))
            {
                token = headerValues;
                if(!string.IsNullOrEmpty(token) && token.StartsWith(bearerPrefix))
                {
                    token = token.Substring(bearerPrefix.Length);
                }
            }
            return token;
        }
        [NonAction]
        public bool CheckSelfUser(int id)
        {

            return id == TreeClaims.UserId;
        }
    }
}
