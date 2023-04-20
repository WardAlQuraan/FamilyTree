﻿using ENTITIES.CORE;
using FamilyTreeApi.Controllers.COMMON_CONTROLLER;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SERVICES.URES_SERVICE;
using System.Threading.Tasks;

namespace FamilyTreeApi.Controllers
{
    [Authorize]
    public class UserController : CommonController<User>
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
            return Ok(user);
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

        [Authorize(Roles = "ADMIN")]
        public override async Task<IActionResult> Delete(int id)
        {
            return await base.Delete(id);
        }


    }
}
