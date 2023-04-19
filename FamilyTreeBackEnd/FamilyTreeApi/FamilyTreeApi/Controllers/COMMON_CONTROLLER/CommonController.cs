using ENTITIES.BASE_ENTITY;
using Microsoft.AspNetCore.Mvc;
using SHARED.COMMON_REPO;
using SHARED.COMMON_SERVICES;
using System.Threading.Tasks;

namespace FamilyTreeApi.Controllers.COMMON_CONTROLLER
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController<T> : ControllerBase where T:BaseEntity
    {
        private readonly ICommonService<T> _service;

        public CommonController(ICommonService<T> service)
        {
            _service = service;
        }

        [HttpGet]
        public virtual async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get(int id)
        {
            return Ok(await _service.GetAsync(id));
        }

        [HttpPost]
        public virtual async Task<IActionResult> Post(T item)
        {
            return StatusCode(201, await _service.InsertAsync(item));
        }

        [HttpPut]
        public virtual async Task<IActionResult> Put(T item)
        {
            return StatusCode(202, await _service.UpdateAsync(item));
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            return StatusCode(204, await _service.DeleteAsync(id));
        }
    }
}
