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
    public class FormlySchemaAnswerController : ControllerBase
    {
        private readonly FormlySchemaWithAnswersContext _context;

        public FormlySchemaAnswerController(FormlySchemaWithAnswersContext context)
        {
            _context = context;
        }

        // GET: api/FormlySchemaAnswer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FormlySchemaWithAnswers>>> GetFormlySchemaWithAnswer()
        {
             List<FormlySchemaWithAnswers> listOfFormlySchemaWithAnswers =  await _context.FormlySchemaWithAnswers
            .Include(j => j.Schema).ThenInclude(s => s.TemplateOptions)
            .Include(j => j.Schema).ThenInclude(s => s.Validation).ThenInclude(w => w.Messages)
            .Include(j => j.Schema).ThenInclude(s => s.FieldGroup).ThenInclude(k => k.DefaultValue)
            .Include(j => j.Schema).ThenInclude(s => s.FieldGroup).ThenInclude(k => k.TemplateOptions).ThenInclude(z => z.Options)
            .Include(j => j.Schema).ThenInclude(s => s.FieldGroup).ThenInclude(k => k.FieldArray).ThenInclude(z => z.FieldGroup).ThenInclude(t => t.TemplateOptions).ThenInclude(g => g.Options)
            .Include(j => j.Schema).ThenInclude(s => s.FieldGroup).ThenInclude(k => k.FieldArray).ThenInclude(z => z.FieldGroup).ThenInclude(t => t.Validation).ThenInclude(s => s.Messages)
            .Include(j => j.Response).ThenInclude(s => s.Children)
            .ToListAsync();

            if(listOfFormlySchemaWithAnswers.Count != 0){
                foreach(FormlySchemaWithAnswers x in listOfFormlySchemaWithAnswers){
                    foreach(ChildFormlySchema y in x.Schema){
                        if(y.FieldGroup.Count == 0){
                            y.FieldGroup = null;
                        }
                    }
                }
            }
            
            return listOfFormlySchemaWithAnswers;
        }

        // GET: api/FormlySchemaAnswer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FormlySchemaWithAnswers>> GetFormlySchemaWithAnswers(int id)
        {
            FormlySchemaWithAnswers formlySchemaWithAnswers = await _context.FormlySchemaWithAnswers
                .Include(j => j.Schema).ThenInclude(s => s.TemplateOptions)
                .Include(j => j.Schema).ThenInclude(s => s.Validation).ThenInclude(w => w.Messages)
                .Include(j => j.Schema).ThenInclude(s => s.FieldGroup).ThenInclude(k => k.DefaultValue)
                .Include(j => j.Schema).ThenInclude(s => s.FieldGroup).ThenInclude(k => k.TemplateOptions).ThenInclude(z => z.Options)
                .Include(j => j.Schema).ThenInclude(s => s.FieldGroup).ThenInclude(k => k.FieldArray).ThenInclude(z => z.FieldGroup).ThenInclude(t => t.TemplateOptions).ThenInclude(g => g.Options)
                .Include(j => j.Schema).ThenInclude(s => s.FieldGroup).ThenInclude(k => k.FieldArray).ThenInclude(z => z.FieldGroup).ThenInclude(t => t.Validation).ThenInclude(s => s.Messages)
                .Include(j => j.Response).ThenInclude(s => s.Children)
                .SingleAsync(j => j.Id == id);
            
            if (formlySchemaWithAnswers == null)
            {
                return NotFound();
            }
            foreach(ChildFormlySchema x in formlySchemaWithAnswers.Schema){
                if(x.FieldGroup.Count == 0){
                    x.FieldGroup = null;
                }
            }

            return formlySchemaWithAnswers;
        }

        // PUT: api/FormlySchemaAnswer/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFormlySchemaWithAnswers(int id, FormlySchemaWithAnswers formlySchemaWithAnswers)
        {
            if (id != formlySchemaWithAnswers.Id)
            {
                return BadRequest();
            }

            _context.Entry(formlySchemaWithAnswers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FormlySchemaWithAnswersExists(id))
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

        // POST: api/FormlySchemaAnswer
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<FormlySchemaWithAnswers>> PostFormlySchemaWithAnswers(FormlySchemaWithAnswers formlySchemaWithAnswers)
        {
            _context.FormlySchemaWithAnswers.Add(formlySchemaWithAnswers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFormlySchemaWithAnswers", new { id = formlySchemaWithAnswers.Id }, formlySchemaWithAnswers);
        }

        // DELETE: api/FormlySchemaAnswer/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FormlySchemaWithAnswers>> DeleteFormlySchemaWithAnswers(int id)
        {
            var formlySchemaWithAnswers = await _context.FormlySchemaWithAnswers.FindAsync(id);
            if (formlySchemaWithAnswers == null)
            {
                return NotFound();
            }

            _context.FormlySchemaWithAnswers.Remove(formlySchemaWithAnswers);
            await _context.SaveChangesAsync();

            return formlySchemaWithAnswers;
        }

        private bool FormlySchemaWithAnswersExists(int id)
        {
            return _context.FormlySchemaWithAnswers.Any(e => e.Id == id);
        }
    }
}
