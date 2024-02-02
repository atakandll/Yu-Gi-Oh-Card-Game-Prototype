using System;

namespace Attributes
{
    [AttributeUsage(AttributeTargets.Method)] // only for methods
    public class ButtonAttribute : Attribute
    {
       
        public ButtonAttribute(string label)
        {
            Label = label;
        }

        public ButtonAttribute()
        {
            
        }
        public string Label { get; }
    }
    
}
