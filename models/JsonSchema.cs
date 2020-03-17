using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

public class JsonSchema
    {
        public int Id { get; set;}

        public Schema Schema {get; set;}
    }

    public class Schema 
    {

        public int SchemaId {get; set;}

        public string Title { get; set; }
            
        public string Description { get; set; }
            
        public string Type { get; set; }
    

        public string[] Required {get; set;}
       
    
        public Properties Properties { get; set; }
            
            
        public Dependencies Dependencies { get; set; } 

    }

    public class Properties 
    {
        public int PropertiesId { get; set;}
        public Property Fullname { get; set; }
    
        public Property Email { get; set; }
    
        public Property Date_of_birth { get; set; }
    
        public Property Country { get; set; }
    
        public PropertyWithBool Have_children { get; set; }
    
    }

    public class Property 
    {
    
        public int PropertyId { get; set;}
        public string Type { get; set; }
    
        public string Title { get; set; }
    
        public Widget Widget { get; set; } 
    }

    public class PropertyWithBool 
    {
        [Key]
    
        public int PropertyId { get; set;}
        public string Type { get; set; }
    
        public string Title { get; set; }
    
        public WidgetWithBool Widget { get; set; } 
    }

    public class Widget 
    {

        public int WidgetId { get; set;}
        public FormlyConfig FormlyConfig { get; set; }
    }

     public class WidgetWithBool 
    {
        [Key]

        public int WidgetId { get; set;}
        public FormlyConfigWithBool FormlyConfig { get; set; }
    }

    public class FormlyConfig 
    {
    

        public int FormlyConfigId { get; set;}
        public TemplateOptions TemplateOptions { get; set; }
    }

    public class FormlyConfigWithBool 
    {
        [Key]
        public int FormlyConfigId { get; set;}
        public TemplateOptionsWithBool TemplateOptions { get; set; }
    }

    public class TemplateOptions 
    {
       
   
        public int TemplateOptionsId { get; set;}
        public bool Required { get; set; }

        public string Description { get; set; }
    
        public string Placeholder { get; set; }

        public Collection<Option> Options {get; set;}
    }

    public class TemplateOptionsWithBool 
    {
       
        [Key]
   
        public int TemplateOptionsId { get; set;}
        public bool Required { get; set; }

        public string Description { get; set; }
    
        public bool Placeholder { get; set; }

        public Collection<Option> Options {get; set;}
    }

    public partial class Option 
    {
       
        public int OptionId { get; set;}
        public int Value { get; set; }
    
        public string Label { get; set; }
    }

    public class Dependencies
    {
      
        public int DependenciesId { get; set;}
        public HaveChildren Have_children {get; set;}
    }

    public class HaveChildren
    {
        
   
        public int HaveChildrenId { get; set;}
        public HaveProperties Properties {get; set;}
    }

    public class HaveProperties
    {
       
  
        public int HavePropertiesId { get; set;}
        public Children children {get; set;}
    }

    public class Children 
    {
        
  
        public int ChildrenId {get; set;}
        
        public string Title { get; set; }
    
        public Collection<Default> Default { get; set; }
    
        public string Type { get; set; }
    
        public DependenciesSchema Items { get; set; }

    }

    public class Default 
    {
    
        public int DefaultId {get; set;}
    }

    public class DependenciesSchema 
    {
       
        public int DependenciesSchemaId { get; set;}
        public string Type { get; set; }

        public DependencyProperties Properties { get; set; }
    }

    public class DependencyProperties
    {
      
        public int DependencyPropertiesId { get; set;}
        public Property Title { get; set; }
    
        public Property Details { get; set; }
    }
