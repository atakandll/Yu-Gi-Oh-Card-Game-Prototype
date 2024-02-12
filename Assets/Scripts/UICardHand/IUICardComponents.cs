using Data;
using Tools.Input;
using UnityEngine;

namespace UICardHand
{
    // Interface for all used in UI card components
    public interface IUICardComponents
    {
        UICardParameters CardConFigParameters { get; }
        Camera MainCamera { get; }
        //IUICardHand Hand { get; }
        SpriteRenderer[] Renderers { get; }
        SpriteRenderer MyRenderer { get; }
        Collider Collider { get; }
        Rigidbody Rigidbody { get; }
        IMouseInput Input { get; }
        GameObject GameObject { get; }
        Transform Transform { get; }
        MonoBehaviour MonoBehaviour { get; }

    }
}