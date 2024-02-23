using Tools.Input;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UICardHand
{
    [RequireComponent(typeof(IMouseInput))]
    public class UICardDrawerClick : MonoBehaviour
    {
        private UICardUtils CardDrawer { get; set; }
        private IMouseInput Input { get; set; }

        private void Awake()
        {
            CardDrawer = transform.parent.GetComponentInChildren<UICardUtils>();
            Input = GetComponent<IMouseInput>();
            Input.OnPointerClick += DrawCard;
        }

        private void DrawCard(PointerEventData obj)
        {
            CardDrawer.DrawCard();
            Debug.Log("Draw Card");
        }
    }
}