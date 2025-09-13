using Learn_Net.DTOs;
using Learn_Net.Services;
using Microsoft.AspNetCore.Mvc;

namespace Learn_Net.Controllers
{
    [ApiController]
    [Route("/api/write")]
    public class WriteController: ControllerBase
    {
        private readonly IWriteService _writeService;
        
        public WriteController(IWriteService writeService)
        {
            _writeService = writeService;
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateWrite([FromBody] CreateWriteRequest req)
        {
            var write = await _writeService.CreateAsync(req.Title, req.Content, req.Difficulty, req.Category, req.Image, req.Point, req.IsPublished);
            var resp = new WriteResponse 
            { 
              Id = write.Id, 
              Title = write.Title, 
              Content = write.Content, 
              Difficulty = write.Difficulty, 
              Category = write.Category, 
              Image = write.Image, 
              Point = write.Point, 
              IsPublished = write.IsPublished 
            };
            return StatusCode(201, new
            {
                status = 201,
                ok = true,
                data = resp
            });
        }


        [HttpGet]
        public async Task<IActionResult> GetAllWrites()
        {
            var writes = await _writeService.GetAllAsync();
            return Ok(new
            {
                status = 200,
                ok = true,
                data = writes
            });
        }
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetWritesByUser(int userId)
        {
            var groupedWrites = await _writeService.GetGroupedByCategoryAsync(userId);
            var response = new
            {
                status = 200,
                ok = true,
                data = groupedWrites
            };

            return Ok(response);
        }
    }
}
