using System.Collections.Generic;

public class TemplateOptionsStepper
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

public class TemplateOptionsStepper2
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

public class FieldGroupStepper2
{
    public int Id { get; set;}
    public string key { get; set; }
    public string type { get; set; }
    public TemplateOptionsStepper2 templateOptions { get; set; }
}

public class ExpressionProperties
{
    public int id {get; set;}
    public List<Model> model { get; set; }
}
public class Model {
    public int Id {get; set;}
    public string Expression {get; set;}
    public string Key {get; set;}
}
public class FieldGroupStepper
{
    public int Id { get; set;}
    public TemplateOptionsStepper templateOptions { get; set; }
    public List<FieldGroupStepper2> fieldGroup { get; set; }
    public string hideExpression { get; set; }
    public ExpressionProperties expressionProperties { get; set; }
}

public class StepperSchema
{
    public int Id { get; set;}
    public string type { get; set; }
    public List<FieldGroupStepper> fieldGroup { get; set; }
}