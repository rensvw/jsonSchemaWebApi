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
        public async Task<ActionResult<IEnumerable<StepperSchemaFrontendMatch>>> GetJsonSchema()
        {
            IEnumerable<StepperSchema> stepperSchemaList = await _context.JsonSchema
                .Include(j => j.fieldGroup).ThenInclude(j => j.templateOptions)
                .Include(j => j.fieldGroup).ThenInclude(j => j.fieldGroup).ThenInclude(j => j.templateOptions)
                .Include(j => j.fieldGroup).ThenInclude(j => j.expressionProperties)
                .ToListAsync();

            var list = new List<StepperSchemaFrontendMatch>();

            foreach(StepperSchema item in stepperSchemaList){
                list.Add(TransformForFrontend(item));
            }

            return list;
        }

        // GET: api/StepperScema/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StepperSchemaFrontendMatch>> GetStepperSchema(int id)
        {
            
            StepperSchema stepperSchema = await _context.JsonSchema
                .Include(j => j.fieldGroup).ThenInclude(j => j.templateOptions)
                .Include(j => j.fieldGroup).ThenInclude(j => j.fieldGroup).ThenInclude(j => j.templateOptions)
                .Include(j => j.fieldGroup).ThenInclude(j => j.expressionProperties)
                .SingleOrDefaultAsync(x => x.Id == id);
            StepperSchemaFrontendMatch schema = TransformForFrontend(stepperSchema);

            

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
        public async Task<ActionResult<StepperSchema>> PostStepperSchema(StepperSchemaFrontendMatch model)
        {
            StepperSchema schema = TransformForBackend(model);
            
            _context.JsonSchema.Add(schema);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStepperSchema", new { id = schema.Id }, schema);
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
        
        public StepperSchema TransformForBackend(StepperSchemaFrontendMatch model){
            StepperSchema schema = new StepperSchema();
            schema.type = model.type;
            schema.fieldGroup = new List<QuestionGroup>();

            foreach(QuestionGroupFrontendMatch data in model.fieldGroup){
                
                QuestionGroup questionGroup = new QuestionGroup();
                questionGroup.fieldGroup = data.fieldGroup;
                questionGroup.hideExpression = data.hideExpression;
                questionGroup.templateOptions = data.templateOptions;
                questionGroup.expressionProperties = new List<ExpressionModel>();

                if(data.expressionProperties != null){

                    foreach(var y in data.expressionProperties){
                        ExpressionModel epressionModel = new ExpressionModel();
                        epressionModel.Key = y.Key;
                        epressionModel.Expression = y.Value;
                        questionGroup.expressionProperties.Add(epressionModel);

                    }

                }
                
                schema.fieldGroup.Add(questionGroup);
            }
            return schema;
        }

        public StepperSchemaFrontendMatch TransformForFrontend(StepperSchema model){
            StepperSchemaFrontendMatch schema = new StepperSchemaFrontendMatch();
            schema.type = model.type;
            schema.fieldGroup = new List<QuestionGroupFrontendMatch>();

            foreach(QuestionGroup data in model.fieldGroup){
                
                QuestionGroupFrontendMatch questionGroup = new QuestionGroupFrontendMatch();
                questionGroup.fieldGroup = data.fieldGroup;
                questionGroup.hideExpression = data.hideExpression;
                questionGroup.templateOptions = data.templateOptions;
                questionGroup.expressionProperties = new Dictionary<string, string>();

                if(data.expressionProperties.Count() != 0){

                    foreach(var y in data.expressionProperties){
                        questionGroup.expressionProperties.Add(y.Key,y.Expression);
                    }

                }
                
                schema.fieldGroup.Add(questionGroup);
            }
            return schema;
        }


    }
}
