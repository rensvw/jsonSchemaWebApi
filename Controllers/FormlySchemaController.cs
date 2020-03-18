using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using jsonWebApiProject;
using System.Collections.ObjectModel;

namespace jsonWebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormlySchemaController : ControllerBase
    {
        private readonly FormlySchemaContext _context;

        public FormlySchemaController(FormlySchemaContext context)
        {
            _context = context;
        }

        // GET: api/FormlySchema
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FormlySchema>>> GetFormlySchema()
        {
            return await _context.FormlySchema
            .Include(j => j.Schema).ThenInclude(s => s.TemplateOptions)
            .Include(j => j.Schema).ThenInclude(s => s.ValIdation).ThenInclude(w => w.Messages)
            .Include(j => j.Schema).ThenInclude(s => s.FieldGroup).ThenInclude(k => k.DefaultValue)
            .Include(j => j.Schema).ThenInclude(s => s.FieldGroup).ThenInclude(k => k.TemplateOptions).ThenInclude(z => z.Options)
            .Include(j => j.Schema).ThenInclude(s => s.FieldGroup).ThenInclude(k => k.FieldArray).ThenInclude(z => z.FieldGroup).ThenInclude(t => t.TemplateOptions).ThenInclude(g => g.Options)
            .Include(j => j.Schema).ThenInclude(s => s.FieldGroup).ThenInclude(k => k.FieldArray).ThenInclude(z => z.FieldGroup).ThenInclude(t => t.Validation).ThenInclude(s => s.Messages)
            .ToListAsync();
        }

        // GET: api/FormlySchema/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FormlySchema>> GetFormlySchema(int id)
        {
            var formlySchema = await _context.FormlySchema
                      .Include(j => j.Schema).ThenInclude(s => s.TemplateOptions)
            .Include(j => j.Schema).ThenInclude(s => s.ValIdation).ThenInclude(w => w.Messages)
            .Include(j => j.Schema).ThenInclude(s => s.FieldGroup).ThenInclude(k => k.DefaultValue)
            .Include(j => j.Schema).ThenInclude(s => s.FieldGroup).ThenInclude(k => k.TemplateOptions).ThenInclude(z => z.Options)
            .Include(j => j.Schema).ThenInclude(s => s.FieldGroup).ThenInclude(k => k.FieldArray).ThenInclude(z => z.FieldGroup).ThenInclude(t => t.TemplateOptions).ThenInclude(g => g.Options)
            .Include(j => j.Schema).ThenInclude(s => s.FieldGroup).ThenInclude(k => k.FieldArray).ThenInclude(z => z.FieldGroup).ThenInclude(t => t.Validation).ThenInclude(s => s.Messages)
            .SingleAsync(j => j.Id == id);

            if (formlySchema == null)
            {
                return NotFound();
            }

            return formlySchema;
        }

        // PUT: api/FormlySchema/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFormlySchema(int id, FormlySchema formlySchema)
        {
            if (id != formlySchema.Id)
            {
                return BadRequest();
            }

            _context.Entry(formlySchema).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FormlySchemaExists(id))
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

        // POST: api/FormlySchema
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<FormlySchema>> PostFormlySchema(ChildFormlySchema[] formlySchemaArray)
        {
            FormlySchema formlySchema = new FormlySchema();
            Collection<ChildFormlySchema> list = new Collection<ChildFormlySchema>();
            formlySchema.Schema = list;
            foreach (ChildFormlySchema item in formlySchemaArray)
            {
                formlySchema.Schema.Add(item);
            }
            _context.FormlySchema.Add(formlySchema);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFormlySchema", new { id = formlySchema.Id }, formlySchema);
        }

        // DELETE: api/FormlySchema/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FormlySchema>> DeleteFormlySchema(int id)
        {
            var formlySchema = await _context.FormlySchema.FindAsync(id);
            if (formlySchema == null)
            {
                return NotFound();
            }

            _context.FormlySchema.Remove(formlySchema);
            await _context.SaveChangesAsync();

            return formlySchema;
        }

        private bool FormlySchemaExists(int id)
        {
            return _context.FormlySchema.Any(e => e.Id == id);
        }
    }
}
