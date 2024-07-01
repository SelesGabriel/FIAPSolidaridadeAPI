using Microsoft.AspNetCore.Mvc;
using FIAPSolidaridadeAPI.DTOs;
using FIAPSolidaridadeAPI.Services;

namespace FIAPSolidaridadeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ModalitiesController : ControllerBase
    {
        private readonly IModalityService _modalityService;

        public ModalitiesController(IModalityService modalityService)
        {
            _modalityService = modalityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllModalities()
        {
            var modalities = await _modalityService.GetAllModalitiesAsync();
            return Ok(modalities);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetModalityById(int id)
        {
            var modality = await _modalityService.GetModalityByIdAsync(id);
            if (modality == null)
                return NotFound();
            return Ok(modality);
        }

        [HttpPost]
        public async Task<IActionResult> CreateModality([FromBody] ModalityDTO modalityDto)
        {
            var createdModality = await _modalityService.CreateModalityAsync(modalityDto);
            return CreatedAtAction(nameof(GetModalityById), new { id = createdModality.Id }, createdModality);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateModality(int id, [FromBody] ModalityDTO modalityDto)
        {
            var updatedModality = await _modalityService.UpdateModalityAsync(id, modalityDto);
            if (updatedModality == null)
                return NotFound();
            return Ok(updatedModality);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteModality(int id)
        {
            var isDeleted = await _modalityService.DeleteModalityAsync(id);
            if (!isDeleted)
                return NotFound();
            return NoContent();
        }
    }
}
