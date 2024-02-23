using System;
using Tools.Input;
using UICardHand;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UICardPile.UICardGraveyard
{
    [RequireComponent(typeof(IMouseInput))]
    public class UICardDiscardClick : MonoBehaviour
    {
        private UICardUtils Utils { get; set; }
        private IMouseInput Input { get; set; }

        private void Awake()
        {
            Input = GetComponent<IMouseInput>();
            Utils = transform.parent.GetComponentInChildren<UICardUtils>();
            Input.OnPointerClick += PlayRandom;
        }

        private void PlayRandom(PointerEventData obj)
        {
            Utils.PlayCard();
            Debug.Log("Discard Card");
        }
    }
}