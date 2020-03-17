
using System.Collections.ObjectModel;

public class Option2
{
    public int Id {get; set;}

    public int value { get; set; }
    public string label { get; set; }
}

public class TemplateOptions2
{
    public int Id {get; set;}

    public string label { get; set; }
    public string placeholder { get; set; }
    public string description { get; set; }
    public bool required { get; set; }
    public Collection<Option2> Options { get; set; }
}

public class Messages
{
    public int Id {get; set;}

    public string required { get; set; }
}

public class ValIdation
{
    public int Id {get; set;}

    public Messages messages { get; set; }
}

public class DefaultValue
{
    public int Id {get; set;}

}

public class TemplateOptions3
{
    public int Id {get; set;}

    public string addText { get; set; }
}

public class TemplateOptions4
{
    public int Id {get; set;}

    public string label { get; set; }
    public bool required { get; set; }
    public string placeholder { get; set; }
    public string description { get; set; }
}

public class Messages2
{
    public int Id {get; set;}

    public string required { get; set; }
}

public class ValIdation2
{
    public int Id {get; set;}

    public Messages2 messages { get; set; }
}

public class FieldGroup2
{
    public int Id {get; set;}

    public string type { get; set; }
    public string key { get; set; }
    public TemplateOptions2 TemplateOptions { get; set; }
    public ValIdation2 valIdation { get; set; }
}

public class FieldArray
{
    public int Id {get; set;}

    public Collection<FieldGroup2> fieldGroup { get; set; }
}

public class FieldGroup
{
    public int Id {get; set;}

    public string key { get; set; }
    public string type { get; set; }
    public Collection<DefaultValue> defaultValue { get; set; }
    public TemplateOptions2 TemplateOptions { get; set; }
    public FieldArray fieldArray { get; set; }
}

public class ChildFormlySchema
{
    public int Id {get; set;}
    public string key { get; set; }
    public string type { get; set; }
    public TemplateOptions2 TemplateOptions { get; set; }
    public ValIdation valIdation { get; set; }
    public string hIdeExpression { get; set; }
    public Collection<FieldGroup> fieldGroup { get; set; }
}

public class FormlySchema
{
    public int Id {get; set;}
    public Collection<ChildFormlySchema> Schema {get; set;}
}
