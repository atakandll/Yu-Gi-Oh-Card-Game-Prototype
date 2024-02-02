using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace Attributes.Editor
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(Object), true)]
    public class ButtonAttributeInspectors : UnityEditor.Editor // to customize the editing behavior of the object
    {
        private MethodInfo[] Methods => target.GetType() // for the reach the methods any object type (etc.Monobehaviour)
            .GetMethods(BindingFlags.Instance | 
                        BindingFlags.Static| 
                        BindingFlags.Public | 
                        BindingFlags.NonPublic);
        public override void OnInspectorGUI() // for the expend the inspector interface 
        {
            base.OnInspectorGUI();
            DrawMethods();
        }
        
        //reflection means we can get all information about objects in runtime
        private void DrawMethods() // for the reach the methods and draw the methods with ButtonAttribute feature
        {
            if (Methods.Length < 1) return;

            foreach (var method in Methods)
            {
                var buttonAttribute = (ButtonAttribute) method.GetCustomAttribute(typeof(ButtonAttribute));
                
                if(buttonAttribute != null)
                    DrawButton(buttonAttribute, method);
                    

            }
        }
        public void DrawButton(ButtonAttribute buttonAttribute, MethodInfo method) // when the button is pressed which method is called
        {
            var label = buttonAttribute.Label ?? method.Name;
            
            if (GUILayout.Button(label)) // draw the button
            {
                method.Invoke(target, null);
            }

        }
        // In short,
        // DrawButton() draw a method with Button
        // DrawMethod() select method with Attribute


    }
}