using ENTITIES.TREE;
using FamilyTreeApi.Controllers.COMMON_CONTROLLER;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SERVICES.TREE_SERVICE;
using SHARED.COMMON_SERVICES;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.Controllers
{

    public class TreeController : CommonController<Tree>
    {
        private readonly ITreeSevice sevice;
        private readonly IWebHostEnvironment _hostEnvironment;

        public TreeController(ITreeSevice service, IWebHostEnvironment hostEnvironment) : base(service)
        {
            this.sevice = service;
            _hostEnvironment = hostEnvironment;
        }
        [HttpPost]
        public override async Task<IActionResult> Post([FromForm] Tree item)
        {
            if(item.ImageFile != null || item.ImageFile.Length > 0)
            {
                var file = item.ImageFile;
                if (!file.ContentType.StartsWith("image/"))
                    return BadRequest("Please select an image file");

                var fileName = Path.GetRandomFileName();
                var extension = Path.GetExtension(file.FileName);
                fileName = Path.ChangeExtension(fileName, extension);

                // Save the uploaded image to the server using the generated file name
                var filePath = Path.Combine("wwwroot/TreeImages", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                item.ImageName = fileName;
            }
            return await base.Post(item);
        }

        [HttpGet(nameof(GetSmallFamily)+"/{parentId}")]
        public async Task<IActionResult> GetSmallFamily(int parentId)
        {
            var tree = await sevice.GetSmallFamily(parentId);
            if (!string.IsNullOrEmpty(tree.Parent.ImageName))
            {
                
                tree.Parent.ImageName = await GetImageUrl(tree.Parent.ImageName);
            }

            foreach(var child in tree.Children)
            {
                if (!string.IsNullOrEmpty(child.ImageName))
                {
                    child.ImageName = await GetImageUrl(child.ImageName);
                }
            }
            return Ok(tree);
        }
        [HttpGet(nameof(GetFirstFamily)+"/{familyId}")]
        public async Task<IActionResult> GetFirstFamily(int familyId)
        {
            var tree = await sevice.GetFirstFamily(familyId);
            if (!string.IsNullOrEmpty(tree.Parent.ImageName))
            {
                tree.Parent.ImageName = await GetImageUrl(tree.Parent.ImageName);
            }

            foreach (var child in tree.Children)
            {
                if (!string.IsNullOrEmpty(child.ImageName))
                {
                    child.ImageName = await GetImageUrl(child.ImageName);
                }
            }
            return Ok(tree);
        }

        private async Task<string> GetImageUrl(string imageNamee)
        {
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "wwwroot\\TreeImages", imageNamee);
            var imageBytes = await System.IO.File.ReadAllBytesAsync(imagePath);
            var base64String = Convert.ToBase64String(imageBytes);
            return base64String;
        }
    }
}
