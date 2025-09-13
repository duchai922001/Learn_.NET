using Learn_Net.DTOs;
using Learn_Net.Services;
using Microsoft.AspNetCore.Mvc;

namespace Learn_Net.Controllers
{
    [ApiController]
    [Route("api/user-write")]
    public class UserWriteController: ControllerBase
    {
        private readonly IUserWriteService _service;
        public UserWriteController(IUserWriteService service)
        {
            _service = service;
        }

        [HttpPost("submit")]
        public async Task<IActionResult> Submit([FromBody] SubmitWriteRequest req)
        {
            var result = await _service.SubmitAsync(req);
            return StatusCode(201, new
            {
                status = 201,
                ok = true,
                data = new
                {
                    result.Id,
                    result.UserId,
                    result.WriteId,
                    result.Score,
                    result.TranslatedContent,
                    result.IsCompleted,
                    result.CompletedAt
                }
            });
        }
    }
}
