using NikkiApi.Models;
using NikkiApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace NikkiApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialsController : ControllerBase
    {
        private readonly MaterialsService _materialsService;

        public MaterialsController(MaterialsService materialsService)
        {
            _materialsService = materialsService;
        }

        [HttpGet]
        public ActionResult<List<Material>> Get() =>
            _materialsService.Get();

        [HttpGet("{id:length(24)}", Name = "GetMaterial")]
        public ActionResult<Material> Get(string id)
        {
            var material = _materialsService.Get(id);
            if (material == null)
            {
                return NotFound();
            }

            return material;
        }

        // [HttpPost]
        // public ActionResult<Material> Create(Material material)
        // {
        //     _materialsService.Create(material);

        //     return CreatedAtRoute("GetMaterial", new { id = material.Id.ToString() }, material);
        // }
        
        [HttpPost]
        public ActionResult<List<Material>> Create(List<Material> materials)
        {
            _materialsService.Create(materials);

            return Created();
        }

        [HttpPut("{id:length(24)}")]
        public ActionResult<Material> Update(string id, Material materialToUpdate)
        {
            var material = _materialsService.Get(id);

            if (material == null)
            {
                return NotFound();
            }

            material.Name = materialToUpdate.Name;
            material.MaterialType = materialToUpdate.MaterialType;
            material.Quality = materialToUpdate.Quality;
            material.SourceId = materialToUpdate.SourceId;
            material.IsEssence = materialToUpdate.IsEssence;
            material.CrystalType = materialToUpdate.CrystalType;

            _materialsService.Update(id, material);

            return material;
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var material = _materialsService.Get(id);

            if (material == null)
            {
                return NotFound();
            }

            _materialsService.Delete(material.Id);

            return NoContent();
        }
    }
}