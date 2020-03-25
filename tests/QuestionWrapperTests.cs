using System.Collections.Generic;
using NUnit.Framework;


namespace jsonWebApiProject
{
    public class GetQuestionnaireViewModel
    {
        private QuestionnaireWrapper _questionnaireWrapperWithStoreModel;
        private QuestionnaireWrapper _questionnaireWrapperWithViewModel;
        private QuestionnaireStoreModel _questionnaireStoreModel = new QuestionnaireStoreModel();
        private QuestionnaireViewModel _questionnaireViewModel = new QuestionnaireViewModel();
       

        [SetUp]
        public void SetUp()
        {
            _questionnaireStoreModel = createStoreModel();
            _questionnaireViewModel = createViewModel();

            _questionnaireWrapperWithStoreModel = new QuestionnaireWrapper(_questionnaireStoreModel);
            _questionnaireWrapperWithViewModel = new QuestionnaireWrapper(_questionnaireViewModel);
        }

        public void canConvertToViewModelFromStoreModel(){
            var result = new QuestionnaireWrapper(_questionnaireStoreModel).GetViewModel();
            Assert.AreEqual(result, _questionnaireViewModel, "The models are equal");
        }


        public QuestionnaireStoreModel createStoreModel(){

            // QuestionnaireStoreModel
            QuestionnaireStoreModel model = new QuestionnaireStoreModel();

            model.type = "type";
            model.fieldGroup = new List<QuestionGroup>();
            model.Id = 1;

            // QuestionGroup
            var questionGroup = new QuestionGroup();

            questionGroup.fieldGroup = new List<Question>();
            questionGroup.expressionProperties = new List<ExpressionModel>();
            questionGroup.hideExpression = "hideExpressionCondition";
            questionGroup.Id = 1;
            questionGroup.templateOptions.label = "questionGroup 1";

            // ExpressionModel
            var expressionModel = new ExpressionModel();

            expressionModel.Expression = "expression";
            expressionModel.Key = "key";

            // Question
            var questionModel = new Question();

            questionModel.Id = 1;
            questionModel.key = "questionModelKey";
            questionModel.templateOptions.Answer = "answer";
            questionModel.templateOptions.Answer = "question";
            questionModel.type = "inputfield";
            questionModel.templateOptions.Id = 1;

            // Add to store model
            model.fieldGroup.Add(questionGroup);
            questionGroup.expressionProperties.Add(expressionModel);
            questionGroup.fieldGroup.Add(questionModel);
            
            return model;
        }

        public QuestionnaireViewModel createViewModel(){

            QuestionnaireViewModel model = new QuestionnaireViewModel();
            model.type = "type";
            model.fieldGroup = new List<QuestionGroupViewModel>();
            model.Id = 1;

            // QuestionGroup
            var questionGroup = new QuestionGroupViewModel();

            questionGroup.fieldGroup = new List<Question>();
            questionGroup.expressionProperties = new Dictionary<string, string>();
            questionGroup.hideExpression = "hideExpressionCondition";
            questionGroup.Id = 1;
            questionGroup.templateOptions.label = "questionGroup 1";


            // Question
            var questionModel = new Question();

            questionModel.Id = 1;
            questionModel.key = "questionModelKey";
            questionModel.templateOptions.Answer = "answer";
            questionModel.templateOptions.Answer = "question";
            questionModel.type = "inputfield";
            questionModel.templateOptions.Id = 1;

            // Add to store model
            model.fieldGroup.Add(questionGroup);
            questionGroup.expressionProperties.Add("key","Expression");
            questionGroup.fieldGroup.Add(questionModel);

            return model;
        }

    }
}