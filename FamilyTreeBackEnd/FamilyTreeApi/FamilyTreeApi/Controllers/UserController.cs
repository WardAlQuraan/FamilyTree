using DTOs.USER;
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
        public async Task<IActionResult> Login(LoginInfo loginInfo)
        {
            var user = await service.Login(loginInfo.Email, loginInfo.Password);
            if (!string.IsNullOrEmpty(user))
            {
                IDictionary<String, Object> claims = new ExpandoObject();
                foreach(var claimProp in typeof(TreeClaims).GetProperties())
                {
                    var value = claimProp.GetValue(claimProp);
                    if (value != null)
                        claims.Add(claimProp.Name, value);
                }
                return StatusMessage(200,"",claims);
            }
            return StatusMessage(401,"invalid email or password");
        }

        [Authorize(Roles = "ADMIN")]
        public override async Task<IActionResult> GetAll()
        {
            try
            {
                return StatusMessage(200,"",await service.GetUsers());
            }catch(Exception ex)
            {
                return StatusMessage(ex);
            }
        }

        public override async Task<IActionResult> Get(int id)
        {
            try
            {
                return StatusMessage(200,"",await service.GetUser(id));

            }catch(Exception ex)
            {
                return StatusMessage(ex);
            }
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
            return StatusMessage(401,"");
        }

        [Authorize(Roles = "ADMIN")]
        public override async Task<IActionResult> Delete(int id)
        {
            return await base.Delete(id);
        }


    }
}
