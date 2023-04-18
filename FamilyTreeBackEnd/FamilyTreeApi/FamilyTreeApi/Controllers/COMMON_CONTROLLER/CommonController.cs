using ENTITIES.BASE_ENTITY;
using Microsoft.AspNetCore.Mvc;
using SHARED.COMMON_REPO;
using System.Threading.Tasks;

namespace FamilyTreeApi.Controllers.COMMON_CONTROLLER
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController<T> : ControllerBase where T:BaseEntity
    {
        private readonly ICommonRepo<T> _repo;

        public CommonController(ICommonRepo<T> repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _repo.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _repo.GetAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(T item)
        {
            return StatusCode(201, await _repo.InsertAsync(item));
        }

        [HttpPut]
        public async Task<IActionResult> Put(T item)
        {
            return StatusCode(202, await _repo.UpdateAsync(item));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return StatusCode(204, await _repo.DeleteAsync(id));
        }
    }
}
