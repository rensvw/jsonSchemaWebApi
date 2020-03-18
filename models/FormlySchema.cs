
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

public class FormlyOption
{
    public int Id {get; set;}

    public int Value { get; set; }
    public string Label { get; set; }
}

public class TemplateOptionsFormlyModel1
{
    public int Id {get; set;}

    public string Label { get; set; }
    public string Placeholder { get; set; }
    public string Description { get; set; }
    public bool Required { get; set; }
    public Collection<FormlyOption> Options { get; set; }
}

public class Messages
{
    public int Id {get; set;}

    public string Required { get; set; }
}

public class Validation
{
    public int Id {get; set;}

    public Messages Messages { get; set; }
}

public class DefaultValue
{
    public int Id {get; set;}

}

public class TemplateOptions3
{
    public int Id {get; set;}

    public string AddText { get; set; }
}

public class TemplateOptions4
{
    public int Id {get; set;}

    public string Label { get; set; }
    public bool Required { get; set; }
    public string Placeholder { get; set; }
    public string Description { get; set; }
}

public class Messages2
{
    public int Id {get; set;}

    public string Required { get; set; }
}

public class Validation2
{
    public int Id {get; set;}

    public Messages2 Messages { get; set; }
}

public class FieldGroup2
{
    public int Id {get; set;}

    public string Type { get; set; }
    public string Key { get; set; }
    public TemplateOptionsFormlyModel1 TemplateOptions { get; set; }
    public Validation2 Validation { get; set; }
}

public class FieldArray
{
    public int Id {get; set;}

    public Collection<FieldGroup2> FieldGroup { get; set; }
}

public class FieldGroup
{
    public int Id { get; set;}
    public string Key { get; set; }
    public string Type { get; set; }
    public Collection<DefaultValue> DefaultValue { get; set; }
    public TemplateOptionsFormlyModel1 TemplateOptions { get; set; }
    public FieldArray FieldArray { get; set; }
}
 
public class ChildFormlySchema
{
    public int Id {get; set;}
    public string Key { get; set; }
    public string Type { get; set; }
    public TemplateOptionsFormlyModel1 TemplateOptions { get; set; }
    public Validation Validation { get; set; }
    public string HideExpression { get; set; }
    public Collection<FieldGroup> FieldGroup { get; set; }

}

public class FormlySchema
{
    public int Id {get; set;}
    public Collection<ChildFormlySchema> Schema {get; set;}
}
