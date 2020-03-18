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
    public class JsonSchemaController : ControllerBase
    {
        private readonly JsonSchemaContext _context;

        public JsonSchemaController(JsonSchemaContext context)
        {
            _context = context;
        }

        // GET: api/JsonSchema
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JsonSchema>>> GetJsonSchema()
        {
           /*  var includableQueryable = await _context.JsonSchema
            .Include(i => i.Schema).Select(i => new Schema { 
                Dependencies = i.Schema.Dependencies, 
                Description = i.Schema.Description,
                Properties = i.Schema.Properties,
                Required = i.Schema.Required,
                Title = i.Schema.Title,
                Type = i.Schema.Type  })
            .Include(j => j.Properties).Select(j => new Properties {
                Country = j.Properties.Country,
                Date_of_birth = j.Properties.Date_of_birth,
                Email = j.Properties.Email,
                Fullname = j.Properties.Fullname,
                Have_children = j.Properties.Have_children
                })
            .Include(k => k.Fullname).Select(k => new Property {
                Title = k.Fullname.Title,
                Type = k.Fullname.Title,
                Title = k.Fullname.Title,
                Title = k.Fullname.Title,
            })
            .ToArrayAsync(); */
            return await _context.JsonSchema
            .Include(j => j.Schema).ThenInclude(p => p.Properties).ThenInclude(f => f.Fullname).ThenInclude(w => w.Widget).ThenInclude(s => s.FormlyConfig).ThenInclude(t => t.TemplateOptions).ThenInclude(o => o.Options)
            .Include(j => j.Schema).ThenInclude(p => p.Properties).ThenInclude(f => f.Email).ThenInclude(w => w.Widget).ThenInclude(s => s.FormlyConfig).ThenInclude(t => t.TemplateOptions).ThenInclude(o => o.Options)
            .Include(j => j.Schema).ThenInclude(p => p.Properties).ThenInclude(f => f.Date_of_birth).ThenInclude(w => w.Widget).ThenInclude(s => s.FormlyConfig).ThenInclude(t => t.TemplateOptions).ThenInclude(o => o.Options)
            .Include(j => j.Schema).ThenInclude(p => p.Properties).ThenInclude(f => f.Country).ThenInclude(w => w.Widget).ThenInclude(s => s.FormlyConfig).ThenInclude(t => t.TemplateOptions).ThenInclude(o => o.Options)
            .Include(j => j.Schema).ThenInclude(p => p.Properties).ThenInclude(f => f.Have_children).ThenInclude(w => w.Widget).ThenInclude(s => s.FormlyConfig).ThenInclude(t => t.TemplateOptions).ThenInclude(o => o.Options)
            .Include(j => j.Schema).ThenInclude(p => p.Dependencies).ThenInclude(h => h.Have_children).ThenInclude(g => g.Properties).ThenInclude(z => z.children).ThenInclude(d => d.Default)
            .Include(j => j.Schema).ThenInclude(p => p.Dependencies).ThenInclude(h => h.Have_children).ThenInclude(g => g.Properties).ThenInclude(z => z.children).ThenInclude(d => d.Items).ThenInclude(k => k.Properties).ThenInclude(y => y.Title)
            .Include(j => j.Schema).ThenInclude(p => p.Dependencies).ThenInclude(h => h.Have_children).ThenInclude(g => g.Properties).ThenInclude(z => z.children).ThenInclude(d => d.Items).ThenInclude(k => k.Properties).ThenInclude(y => y.Details)
            .ToListAsync();
        }

        // GET: api/JsonSchema/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JsonSchema>> GetJsonSchema(int id)
        {
            var jsonSchema = await _context.JsonSchema
            .Include(j => j.Schema).ThenInclude(p => p.Properties).ThenInclude(f => f.Fullname).ThenInclude(w => w.Widget).ThenInclude(s => s.FormlyConfig).ThenInclude(t => t.TemplateOptions).ThenInclude(o => o.Options)
            .Include(j => j.Schema).ThenInclude(p => p.Properties).ThenInclude(f => f.Email).ThenInclude(w => w.Widget).ThenInclude(s => s.FormlyConfig).ThenInclude(t => t.TemplateOptions).ThenInclude(o => o.Options)
            .Include(j => j.Schema).ThenInclude(p => p.Properties).ThenInclude(f => f.Date_of_birth).ThenInclude(w => w.Widget).ThenInclude(s => s.FormlyConfig).ThenInclude(t => t.TemplateOptions).ThenInclude(o => o.Options)
            .Include(j => j.Schema).ThenInclude(p => p.Properties).ThenInclude(f => f.Country).ThenInclude(w => w.Widget).ThenInclude(s => s.FormlyConfig).ThenInclude(t => t.TemplateOptions).ThenInclude(o => o.Options)
            .Include(j => j.Schema).ThenInclude(p => p.Properties).ThenInclude(f => f.Have_children).ThenInclude(w => w.Widget).ThenInclude(s => s.FormlyConfig).ThenInclude(t => t.TemplateOptions).ThenInclude(o => o.Options)
            .Include(j => j.Schema).ThenInclude(p => p.Dependencies).ThenInclude(h => h.Have_children).ThenInclude(g => g.Properties).ThenInclude(z => z.children).ThenInclude(d => d.Default)
            .Include(j => j.Schema).ThenInclude(p => p.Dependencies).ThenInclude(h => h.Have_children).ThenInclude(g => g.Properties).ThenInclude(z => z.children).ThenInclude(d => d.Items).ThenInclude(k => k.Properties).ThenInclude(y => y.Title)
            .Include(j => j.Schema).ThenInclude(p => p.Dependencies).ThenInclude(h => h.Have_children).ThenInclude(g => g.Properties).ThenInclude(z => z.children).ThenInclude(d => d.Items).ThenInclude(k => k.Properties).ThenInclude(y => y.Details)
            .SingleOrDefaultAsync(x => x.Id == id);

            if (jsonSchema == null)
            {
                return NotFound();
            }

            return jsonSchema;
        }

        // PUT: api/JsonSchema/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJsonSchema(int id, JsonSchema jsonSchema)
        {
            if (id != jsonSchema.Id)
            {
                return BadRequest();
            }

            _context.Entry(jsonSchema).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JsonSchemaExists(id))
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

        // POST: api/JsonSchema
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<JsonSchema>> PostJsonSchema(JsonSchema jsonSchema)
        {
            _context.JsonSchema.Add(jsonSchema);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJsonSchema", new { id = jsonSchema.Id }, jsonSchema);
        }

        // DELETE: api/JsonSchema/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<JsonSchema>> DeleteJsonSchema(int id)
        {
            var jsonSchema = await _context.JsonSchema.FindAsync(id);
            if (jsonSchema == null)
            {
                return NotFound();
            }

            _context.JsonSchema.Remove(jsonSchema);
            await _context.SaveChangesAsync();

            return jsonSchema;
        }

        private bool JsonSchemaExists(int id)
        {
            return _context.JsonSchema.Any(e => e.Id == id);
        }
    }
}
