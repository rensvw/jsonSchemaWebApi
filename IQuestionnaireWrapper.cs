using System.Collections.Generic;

namespace jsonWebApiProject
{
    public interface IQuestionnaireWrapper
    {
        void SubstituteAnsweredQuestion(int QuestionId, string Answer);
        List<int> GetAllQuestionsID();
        QuestionnaireStoreModel GetStoreModel();
        QuestionnaireViewModel GetViewModel();

        List<AssetQuestionModel> GetAllAnsweredQuestions();
        List<AssetQuestionModel> GetAllUnAnsweredQuestions();

    }
}
