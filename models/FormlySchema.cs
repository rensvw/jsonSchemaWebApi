
using System.Collections.ObjectModel;

public class Option2
{
    public int Id {get; set;}

    public int Value { get; set; }
    public string Label { get; set; }
}

public class TemplateOptions2
{
    public int Id {get; set;}

    public string Label { get; set; }
    public string Placeholder { get; set; }
    public string Description { get; set; }
    public bool Required { get; set; }
    public Collection<Option2> Options { get; set; }
}

public class Messages
{
    public int Id {get; set;}

    public string Required { get; set; }
}

public class ValIdation
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

public class ValIdation2
{
    public int Id {get; set;}

    public Messages2 Messages { get; set; }
}

public class FieldGroup2
{
    public int Id {get; set;}

    public string Type { get; set; }
    public string Key { get; set; }
    public TemplateOptions2 TemplateOptions { get; set; }
    public ValIdation2 Validation { get; set; }
}

public class FieldArray
{
    public int Id {get; set;}

    public Collection<FieldGroup2> FieldGroup { get; set; }
}

public class FieldGroup
{
    public int Id {get; set;}

    public string Key { get; set; }
    public string Type { get; set; }
    public Collection<DefaultValue> DefaultValue { get; set; }
    public TemplateOptions2 TemplateOptions { get; set; }
    public FieldArray FieldArray { get; set; }
}
 
public class ChildFormlySchema
{
    public int Id {get; set;}
    public string Key { get; set; }
    public string Type { get; set; }
    public TemplateOptions2 TemplateOptions { get; set; }
    public ValIdation ValIdation { get; set; }
    public string HideExpression { get; set; }
    public Collection<FieldGroup> FieldGroup { get; set; }
}

public class FormlySchema
{
    public int Id {get; set;}
    public Collection<ChildFormlySchema> Schema {get; set;}
}
