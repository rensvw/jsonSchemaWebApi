using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using jsonWebApiProject;

namespace jsonWebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StepperSchemaController : ControllerBase
    {
        private readonly StepperSchemaContext _context;

        public StepperSchemaController(StepperSchemaContext context)
        {
            _context = context;
        }

        // GET: api/StepperScema
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StepperSchema>>> GetJsonSchema()
        {
            return await _context.JsonSchema.ToListAsync();
        }

        // GET: api/StepperScema/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StepperSchema>> GetStepperSchema(int id)
        {
            var stepperSchema = await _context.JsonSchema.FindAsync(id);

            if (stepperSchema == null)
            {
                return NotFound();
            }

            return stepperSchema;
        }

        // PUT: api/StepperScema/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStepperSchema(int id, StepperSchema stepperSchema)
        {
            if (id != stepperSchema.Id)
            {
                return BadRequest();
            }

            _context.Entry(stepperSchema).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StepperSchemaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/StepperScema
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<StepperSchema>> PostStepperSchema(StepperSchema stepperSchema)
        {
            _context.JsonSchema.Add(stepperSchema);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStepperSchema", new { id = stepperSchema.Id }, stepperSchema);
        }

        // DELETE: api/StepperScema/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StepperSchema>> DeleteStepperSchema(int id)
        {
            var stepperSchema = await _context.JsonSchema.FindAsync(id);
            if (stepperSchema == null)
            {
                return NotFound();
            }

            _context.JsonSchema.Remove(stepperSchema);
            await _context.SaveChangesAsync();

            return stepperSchema;
        }

        private bool StepperSchemaExists(int id)
        {
            return _context.JsonSchema.Any(e => e.Id == id);
        }
    }
}
