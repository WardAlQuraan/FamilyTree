using DTOs.API_HELPERS;
using ENTITIES.BASE_ENTITY;
using Microsoft.AspNetCore.Mvc;
using SHARED.COMMON_SERVICES;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.Controllers.COMMON_CONTROLLER
{
    public class CommonController<T> : StatusesController where T:BaseEntity
    {
        private readonly ICommonService<T> _service;

        public CommonController(ICommonService<T> service)
        {
            _service = service;
        }

        [HttpGet]
        public virtual async Task<IActionResult> GetAll()
        {
            try
            {
                var res = await _service.GetAllAsync();
                if (res.Any())
                {
                    return StatusMessage(200, data: res , message:"");
                }
                else
                {
                    return StatusMessage(204, message: "There is no data");
                }
            }catch(Exception ex)
            {
                return StatusMessage(ex);
            }
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get(int id)
        {
            try
            {
                bool isExist = await _service.CheckExist(id);
                if (isExist)
                {
                    return StatusMessage(404, $"There is no content with id = {id}");
                }
                var res = await _service.GetAsync(id);
                return StatusMessage(200, "", res);
            }catch(Exception ex)
            {
                return StatusMessage(ex);
            }
            
        }

        [HttpPost]
        public virtual async Task<IActionResult> Post(T item)
        {
            try
            {
                var res = await _service.InsertAsync(item);
                return StatusMessage(201, "Created Successfully", res);
            }catch(Exception ex)
            {
                return StatusMessage(ex);
            }

        }

        [HttpPut]
        public virtual async Task<IActionResult> Put(T item)
        {
            try
            {
                var isExist = await _service.CheckExist(item.Id);
                if (isExist)
                {
                    var res = await _service.UpdateAsync(item);
                    return StatusMessage(202, "Updated Successfully", item);
                }
                return StatusMessage(404, $"There is no content with id = {item.Id}");
                
            }catch(Exception ex)
            {
                return StatusMessage(ex);

            }
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            try
            {
                var isExist = await _service.CheckExist(id);
                if (isExist)
                {
                    var res = await _service.DeleteAsync(id);
                    return StatusMessage(204, "Deleted Successfully", res);
                }
                return StatusMessage(404, $"There is no content with id = {id}");

            }
            catch (Exception ex)
            {
                return StatusMessage(ex);

            }
        }
    }
}
