using System;
using System.Collections.Generic;

public class StepperSchema
{
    public int Id { get; set;}
    public string type { get; set; }
    public List<QuestionGroup> fieldGroup { get; set; }
}

public class StepperSchemaFrontendMatch
{
    public int Id { get; set;}
    public string type { get; set; }
    public List<QuestionGroupFrontendMatch> fieldGroup { get; set; }
}

public class QuestionGroup
{
    public int Id { get; set;}
    public QuestionGroupTemplate templateOptions { get; set; }
    public List<Question> fieldGroup { get; set; }
    public string hideExpression { get; set; }
    public List<ExpressionModel> expressionProperties { get; set; }
}

public class QuestionGroupFrontendMatch
{
    public int Id { get; set;}
    public QuestionGroupTemplate templateOptions { get; set; }
    public List<Question> fieldGroup { get; set; }
    public string hideExpression { get; set; }
    public Dictionary<string,string> expressionProperties { get; set; }
}


public class QuestionGroupTemplate
{
    public int Id { get; set;}
    public string label { get; set; }
}

public class OptionStepper
{
    public int Id { get; set;}
    public int value { get; set; }
    public string label { get; set; }
}

public class QuestionTemplate
{
    public int Id { get; set;}
    public string type { get; set; }
    public string label { get; set; }
    public List<OptionStepper> options { get; set; }
    public bool required { get; set; }
    public string placeholder { get; set; }
    public string description { get; set; }
    public bool? multiple { get; set; }
    public string selectAllOption { get; set; }
}

public class Question
{
    public int Id { get; set;}
    public string key { get; set; }
    public string type { get; set; }
    public QuestionTemplate templateOptions { get; set; }
}


public class ExpressionModel {
    public int Id {get; set;}
    public string Expression {get; set;}
    public string Key {get; set;}
}