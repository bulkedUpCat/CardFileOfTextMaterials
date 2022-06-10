using BLL.Services;
using BLL.Validation;
using CardFile.Logging;
using Core.DTOs;
using Core.Models;
using Core.RequestFeatures;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CardFile.Controllers
{
    [ApiController]
    [Route("api/textMaterials")]
    public class TextMaterialController : ControllerBase
    {
        private readonly TextMaterialService _textMaterialService;
        private readonly ILoggerManager _logger;
        private readonly TextMaterialCategoryService _textMaterialCategoryService;

        public TextMaterialController(TextMaterialService textMaterialService,
            TextMaterialCategoryService textMaterialCategoryService,
            ILoggerManager logger)
        {
            _textMaterialService = textMaterialService;
            _logger = logger;
            _textMaterialCategoryService = textMaterialCategoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TextMaterialDTO>>> Get([FromQuery]TextMaterialParameters parameters)
        {
            var textMaterials = await _textMaterialService.GetTextMaterials(parameters);

            if (textMaterials == null)
            {
                _logger.LogInfo("No text materials were found");
                return NotFound("No text materials were found");
            }

            return Ok(textMaterials);
        }


        [HttpGet("{id}", Name = "GetTextMaterialById")]
        public async Task<ActionResult<TextMaterialDTO>> Get(int id)
        {
            var textMaterial = await _textMaterialService.GetTextMaterialById(id);

            if (textMaterial == null)
            {
                _logger.LogInfo($"Text material with id {id} does not exist");
                return NotFound($"Text material with id {id} does not exist");
            }

            return Ok(textMaterial);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateTextMaterialDTO textMaterialDTO)
        {
            try
            {
                var textMaterial = await _textMaterialService.CreateTextMaterial(textMaterialDTO);

                return CreatedAtRoute("GetTextMaterialById", new { id = textMaterial.Id }, textMaterial);
            }
            catch (CardFileException e)
            {
                _logger.LogInfo($"Failed to create a text material: {e.Message}");
                return BadRequest(e.Message);
            }
        }

        [HttpGet("categories")]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _textMaterialCategoryService.GetTextMaterialCategoriesAsync();

            if (categories == null)
            {
                _logger.LogInfo("No categories were found");
                return NotFound("No categories were found");
            }

            return Ok(categories);
        }

        [HttpGet("categories/{id}", Name = "GetCategoryById")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await _textMaterialCategoryService.GetTextMaterialCategoryById(id);

            if (category == null)
            {
                _logger.LogInfo($"Failed to find a category with id {id}");
                return NotFound($"Failed to find a category with id {id}");
            }

            return Ok(category);
        }

        [HttpPost("categories")]
        public async Task<IActionResult> PostCategory(CreateTextMaterialCategoryDTO categoryDTO)
        {
            try
            {
                var category = await _textMaterialCategoryService.CreateTextMaterialCategoryAsync(categoryDTO);

                return CreatedAtRoute("GetCategoryById", new { id = category.Id }, category);
            }
            catch (CardFileException e)
            {
                _logger.LogInfo($"Failed to create a category: {e.Message}");
                return BadRequest(e.Message);
            }
        }
    }
}
