using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using jsonWebApiProject;
using Newtonsoft.Json;

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
        public async Task<ActionResult<IEnumerable<QuestionnaireViewModel>>> GetJsonSchema()
        {
            IEnumerable<QuestionnaireStoreModel> stepperSchemaList = await _context.JsonSchema
                .Include(j => j.fieldGroup).ThenInclude(j => j.templateOptions)
                .Include(j => j.fieldGroup).ThenInclude(j => j.fieldGroup).ThenInclude(j => j.templateOptions)
                .Include(j => j.fieldGroup).ThenInclude(j => j.fieldGroup).ThenInclude(j => j.templateOptions).ThenInclude(j => j.options)
                .Include(j => j.fieldGroup).ThenInclude(j => j.expressionProperties)
                .ToListAsync();

            var list = new List<QuestionnaireViewModel>();

            foreach(QuestionnaireStoreModel item in stepperSchemaList){
                list.Add(new QuestionnaireWrapper(item).GetViewModel());
            }

            return list;
        }

        // GET: api/StepperScema/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QuestionnaireViewModel>> GetStepperSchema(int id)
        {
            
            QuestionnaireStoreModel stepperSchema = await _context.JsonSchema
                .Include(j => j.fieldGroup).ThenInclude(j => j.templateOptions)
                .Include(j => j.fieldGroup).ThenInclude(j => j.fieldGroup).ThenInclude(j => j.templateOptions)
                .Include(j => j.fieldGroup).ThenInclude(j => j.fieldGroup).ThenInclude(j => j.templateOptions).ThenInclude(j => j.options)
                .Include(j => j.fieldGroup).ThenInclude(j => j.expressionProperties)
                .SingleOrDefaultAsync(x => x.Id == id);
        
            
            QuestionnaireViewModel schema = new QuestionnaireWrapper(stepperSchema).GetViewModel();

            

            if (stepperSchema == null)
            {
                return NotFound();
            }

            return schema;
        }

        // PUT: api/StepperScema/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStepperSchema(int id, QuestionnaireStoreModel stepperSchema)
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
        public async Task<ActionResult<QuestionnaireStoreModel>> PostStepperSchema(QuestionnaireViewModel model)
        {
            QuestionnaireStoreModel schema = new QuestionnaireWrapper(model).GetStoreModel();
            
            _context.JsonSchema.Add(schema);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStepperSchema", new { id = schema.Id }, schema);
        }

        // DELETE: api/StepperScema/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<QuestionnaireStoreModel>> DeleteStepperSchema(int id)
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
