using System.Collections.Generic;
using System.Linq;

namespace jsonWebApiProject
{
    public class QuestionnaireWrapper: IQuestionnaireWrapper
    {
        private QuestionnaireStoreModel _questionnaireStoreModel = new QuestionnaireStoreModel();
        private QuestionnaireViewModel _questionnaireViewModel = new QuestionnaireViewModel();

        public QuestionnaireWrapper(QuestionnaireViewModel questionnaireViewModel){
            this._questionnaireStoreModel = new QuestionnaireWrapper(questionnaireViewModel).GetStoreModel();
        }

        public QuestionnaireWrapper(QuestionnaireStoreModel questionnaireStoreModel){
            this._questionnaireStoreModel = questionnaireStoreModel;
        }

        public List<AssetQuestionModel> GetAllAnsweredQuestions()
        {
            var answeredQuestions = new List<AssetQuestionModel>();
            var assetQuestionModel = new AssetQuestionModel();


            foreach(QuestionGroup questionGroup in _questionnaireStoreModel.fieldGroup){
                foreach(Question question in questionGroup.fieldGroup){
                    if(question.templateOptions.Answer != null){
                        assetQuestionModel.Id = question.Id;
                        assetQuestionModel.Name = question.key;
                        assetQuestionModel.OriginalQuestion = question.templateOptions.label;
                        assetQuestionModel.OriginalAnswer = question.templateOptions.Answer;
                        answeredQuestions.Add(assetQuestionModel);
                    }
                }
            }

            return answeredQuestions;
        }

        public List<int> GetAllQuestionsID()
        {
            var questionIdList = new List<int>();

            foreach(QuestionGroup questionGroup in _questionnaireStoreModel.fieldGroup){
                foreach(Question question in questionGroup.fieldGroup){
                    questionIdList.Add(question.templateOptions.Id);
                }
            }

            return questionIdList;
        }

        public List<AssetQuestionModel> GetAllUnAnsweredQuestions()
        {
            var unansweredQuestions = new List<AssetQuestionModel>();
            var assetQuestionModel = new AssetQuestionModel();

            foreach(QuestionGroup questionGroup in _questionnaireStoreModel.fieldGroup){
                foreach(Question question in questionGroup.fieldGroup){
                    if(question.templateOptions.Answer == null){
                        assetQuestionModel.Id = question.Id;
                        assetQuestionModel.Name = question.key;
                        assetQuestionModel.OriginalQuestion = question.templateOptions.label;
                        assetQuestionModel.OriginalAnswer = question.templateOptions.Answer;
                        unansweredQuestions.Add(assetQuestionModel);
                    }
                }
            }

            return unansweredQuestions;
        }

        public QuestionnaireStoreModel GetStoreModel()
        {
            var model = _questionnaireViewModel;

            // TODO: Check what the view model is and transform to the store model.

            QuestionnaireStoreModel schema = new QuestionnaireStoreModel();
            schema.type = model.type;
            schema.fieldGroup = new List<QuestionGroup>();

            foreach(QuestionGroupViewModel data in model.fieldGroup){
                
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

        public QuestionnaireViewModel GetViewModel()
        {
            //TODO Diferent View Models

            var model = _questionnaireStoreModel;

            QuestionnaireViewModel schema = new QuestionnaireViewModel();
            schema.type = model.type;
            schema.fieldGroup = new List<QuestionGroupViewModel>();

            foreach(QuestionGroup data in model.fieldGroup){
                
                QuestionGroupViewModel questionGroup = new QuestionGroupViewModel();
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

        public void SubstituteAnsweredQuestion(int QuestionId, string Answer)
        {
            foreach(QuestionGroup questionGroup in _questionnaireStoreModel.fieldGroup){
                foreach(Question question in questionGroup.fieldGroup){
                    if(question.Id == QuestionId){
                        question.templateOptions.Answer = Answer;
                    }
                }
            }
        }
    }
}
