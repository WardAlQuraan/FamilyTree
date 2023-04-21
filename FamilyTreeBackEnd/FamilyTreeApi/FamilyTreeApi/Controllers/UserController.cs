using ENTITIES.CORE;
using FamilyTreeApi.Controllers.COMMON_CONTROLLER;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SERVICES.URES_SERVICE;
using SHARED.CLAIM_HELPER;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;

namespace FamilyTreeApi.Controllers
{
    public class UserController : AuthController<User>
    {
        private readonly IUserService service; 
        public UserController(IUserService service) : base(service)
        {
            this.service = service;
        }
        [AllowAnonymous]
        [HttpPost(nameof(Login))]
        public async Task<IActionResult> Login(string email, string password)
        {
            var user = await service.Login(email, password);
            if (!string.IsNullOrEmpty(user))
            {
                IDictionary<String, Object> claims = new ExpandoObject();
                foreach(var claimProp in typeof(TreeClaims).GetProperties())
                {
                    var value = claimProp.GetValue(claimProp);
                    if (value != null)
                        claims.Add(claimProp.Name, value);
                }
                return Ok(claims);
            }
            return Unauthorized();
        }

        [Authorize(Roles = "ADMIN")]
        public override async Task<IActionResult> GetAll()
        {
            return Ok(await service.GetUsers());
        }

        public override async Task<IActionResult> Get(int id)
        {
            return Ok(await service.GetUser(id));
        }

        [Authorize(Roles = "ADMIN")]
        public override async Task<IActionResult> Post(User item)
        {
            return await base.Post(item);
        }

        public override async Task<IActionResult> Put(User item)
        {

            if (CheckSelfUser(item.Id))
                return await base.Put(item);
            return Unauthorized();
        }

        [Authorize(Roles = "ADMIN")]
        public override async Task<IActionResult> Delete(int id)
        {
            return await base.Delete(id);
        }


    }
}
