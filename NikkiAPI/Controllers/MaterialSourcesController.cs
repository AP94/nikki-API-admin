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

        // [HttpPost]
        // public ActionResult<MaterialSource> Create(MaterialSource materialSource)
        // {
        //     _materialSourcesService.Create(materialSource);

        //     return CreatedAtRoute("GetMaterialSource", new { id = materialSource.Id }, materialSource);
        // }
        
        [HttpPost]
        public ActionResult<List<MaterialSource>> Create(List<MaterialSource> materialSources)
        {
            _materialSourcesService.Create(materialSources);

            return Created();
        }

        [HttpPut("{id:length(24)}")]
        public ActionResult<MaterialSource> Update(string id, MaterialSource materialSourceToUpdate)
        {
            var materialSource = _materialSourcesService.Get(id);

            if (materialSource == null)
            {
                return NotFound();
            }

            materialSource.Name = materialSourceToUpdate.Name;
            materialSource.Regions = materialSourceToUpdate.Regions;
            materialSource.Locations = materialSourceToUpdate.Locations;
            materialSource.HarvestedBy = materialSourceToUpdate.HarvestedBy;

            _materialSourcesService.Update(id, materialSource);

            return materialSource;
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