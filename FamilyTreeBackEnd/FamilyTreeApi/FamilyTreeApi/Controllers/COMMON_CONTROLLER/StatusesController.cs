using DTOs.API_HELPERS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.Controllers.COMMON_CONTROLLER
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusesController : ControllerBase
    {
        [NonAction]
        public virtual IActionResult StatusMessage(int statusCode , string message , dynamic data = null)
        {
            return StatusCode(statusCode, new ApiResponse(statusCode, message, data));
        }

        [NonAction]
        public virtual IActionResult StatusMessage(Exception ex)
        {
            if(ex.GetType() == typeof(ResponseException))
            {
                ResponseException resEx = ex as ResponseException;
                return StatusCode(resEx.StatusCode, new ApiResponse(resEx.StatusCode, resEx.ErrorMessage, resEx.Data));

            }
            return StatusCode(500, new ApiResponse(500, ex.Message));
        }
    }
}
