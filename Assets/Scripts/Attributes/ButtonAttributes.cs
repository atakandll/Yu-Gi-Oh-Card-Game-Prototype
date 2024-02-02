using System;

namespace Attributes
{
    [AttributeUsage(AttributeTargets.Method)] // only for methods
    public class ButtonAttribute : Attribute
    {
        public string Label { get; }
       
        public ButtonAttribute(string label)
        {
            Label = label;
        }

        public ButtonAttribute()
        {
            
        }
       
    }
    
}
