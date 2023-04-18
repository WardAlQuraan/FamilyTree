using ENTITIES.CORE;
using FamilyTreeApi.Controllers.COMMON_CONTROLLER;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SERVICES.URES_SERVICE;
using SHARED.COMMON_SERVICES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.Controllers
{

    public class UserController : CommonController<User>
    {
        public UserController(IUserService service) : base(service)
        {
        }
    }
}
