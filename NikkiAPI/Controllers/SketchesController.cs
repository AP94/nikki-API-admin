using NikkiApi.Models;
using NikkiApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace NikkiApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SketchesController : ControllerBase
    {
        private readonly SketchesService _sketchesService;

        public SketchesController(SketchesService sketchesService)
        {
            _sketchesService = sketchesService;
        }

        [HttpGet]
        public ActionResult<List<Sketch>> Get() =>
            _sketchesService.Get();

        [HttpGet("{id:length(24)}", Name = "Getsketch")]
        public ActionResult<Sketch> Get(string id)
        {
            var sketch = _sketchesService.Get(id);

            if (sketch == null)
            {
                return NotFound();
            }

            return sketch;
        }

        // [HttpPost]
        // public ActionResult<Sketch> Create(Sketch sketch)
        // {
        //     _sketchesService.Create(sketch);

        //     return CreatedAtRoute("GetSketch", new { id = sketch.Id.ToString() }, sketch);
        // }

        [HttpPost]
        public ActionResult<List<Sketch>> Create(List<Sketch> sketches)
        {
            _sketchesService.Create(sketches);

            return Created();
        }

        [HttpPut("{id:length(24)}")]
        public ActionResult<Sketch> Update(string id, Sketch sketchToUpdate)
        {
            var sketch = _sketchesService.Get(id);

            if (sketch == null)
            {
                return NotFound();
            }

            sketch.Name = sketchToUpdate.Name;
            sketch.Quality = sketchToUpdate.Quality;
            sketch.ThreadCost = sketchToUpdate.ThreadCost;
            sketch.BlingsCost = sketchToUpdate.BlingsCost;
            sketch.SketchSource = sketchToUpdate.SketchSource;
            sketch.SketchCategory = sketchToUpdate.SketchCategory;
            sketch.MaterialsCost = sketchToUpdate.MaterialsCost;
            sketch.WardrobeCategory = sketchToUpdate.WardrobeCategory;
            sketch.ClothingStyle = sketchToUpdate.ClothingStyle;
            sketch.Labels = sketchToUpdate.Labels;
            sketch.OutfitSet = sketchToUpdate.OutfitSet;
            sketch.FragranceType = sketchToUpdate.FragranceType;
            
            _sketchesService.Update(id, sketch);

            return sketch;
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var sketch = _sketchesService.Get(id);

            if (sketch == null)
            {
                return NotFound();
            }

            _sketchesService.Delete(sketch.Id);

            return NoContent();
        }
    }
}