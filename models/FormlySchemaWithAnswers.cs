using System;
using System.Collections.ObjectModel;

public class FormlySchemaWithAnswers : FormlySchema
{
    public Collection<FormlySchemaAnswers> Response {get ; set;}
}

public class FormlySchemaAnswers
{
    public int Id {get; set;}
    public Collection<ChildrenOfAnswers> Children { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime Date_of_birth { get; set; }
    public int Country { get; set; }
    public bool Have_children { get; set; }
}

public class ChildrenOfAnswers
{
    public int Id {get; set;}
    public string Child_name { get; set; }
    public DateTime Birthdate_of_child { get; set; }
}