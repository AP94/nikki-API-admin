using NikkiApi.Models;
using NikkiApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace NikkiApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialSourcesController : ControllerBase
    {
        private readonly MaterialSourcesService _materialSourcesService;

        public MaterialSourcesController(MaterialSourcesService materialSourcesService)
        {
            _materialSourcesService = materialSourcesService;
        }

        [HttpGet]
        public ActionResult<List<MaterialSource>> Get() =>
            _materialSourcesService.Get();

        [HttpGet("{id:length(24)}", Name = "GetMaterialSource")]
        public ActionResult<MaterialSource> Get(string id)
        {
            var materialSource = _materialSourcesService.Get(id);
            if (materialSource == null)
            {
                return NotFound();
            }

            return materialSource;
        }

        [HttpPost]
        public ActionResult<MaterialSource> Create(MaterialSource materialSource)
        {
            _materialSourcesService.Create(materialSource);

            return CreatedAtRoute("GetMaterial", new { id = materialSource.Id.ToString() }, materialSource);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, MaterialSource materialSourceToUpdate)
        {
            var materialSource = _materialSourcesService.Get(id);

            if (materialSource == null)
            {
                return NotFound();
            }

            _materialSourcesService.Update(id, materialSourceToUpdate);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var materialSource = _materialSourcesService.Get(id);

            if (materialSource == null)
            {
                return NotFound();
            }

            _materialSourcesService.Delete(materialSource.Id);

            return NoContent();
        }
    }
}