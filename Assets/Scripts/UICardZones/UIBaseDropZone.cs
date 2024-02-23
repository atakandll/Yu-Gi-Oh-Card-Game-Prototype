using Tools.Input;
using UICardHand;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UICardZones
{
    [RequireComponent(typeof(IMouseInput))]
    public abstract class UIBaseDropZone : MonoBehaviour
    {
        protected IUICardHand CardHand { get; set; }
        protected IMouseInput Input { get; set; }
        
        protected virtual void Awake()
        {
            Input = GetComponent<IMouseInput>();
            CardHand = transform.parent.GetComponentInChildren<IUICardHand>();
            Input.OnPointerUp += OnPointerUp;
        }
        protected virtual void OnPointerUp(PointerEventData eventData)
        {
        }
        
        
    }
}