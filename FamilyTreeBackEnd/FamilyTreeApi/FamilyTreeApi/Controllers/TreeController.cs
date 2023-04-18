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
        public TreeController(ITreeSevice service) : base(service)
        {
        }
    }
}
