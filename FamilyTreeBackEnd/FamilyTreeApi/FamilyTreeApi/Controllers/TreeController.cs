using ENTITIES.TREE;
using FamilyTreeApi.Controllers.COMMON_CONTROLLER;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SERVICES.TREE_SERVICE;
using SHARED.COMMON_SERVICES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.Controllers
{

    public class TreeController : CommonController<Tree>
    {
        private readonly ITreeSevice sevice;
        public TreeController(ITreeSevice service) : base(service)
        {
            this.sevice = service;
        }

        [HttpGet(nameof(GetSmallFamily)+"{parentId}")]
        public async Task<IActionResult> GetSmallFamily(int parentId)
        {
            return Ok(await sevice.GetSmallFamily(parentId));
        }
        [HttpGet(nameof(GetFirstFamily)+"{familyId}")]
        public async Task<IActionResult> GetFirstFamily(int familyId)
        {
            return Ok(await sevice.GetFirstFamily(familyId));
        }

    }
}
