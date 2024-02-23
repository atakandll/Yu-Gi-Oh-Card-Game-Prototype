using Data;
using Patterns.StateMachine;
using UICardHand;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UICardStateMachine.States
{
    public class UICardIdleState : UIBaseCardState
    {
        private Vector3 DefaultSize { get; }
        public UICardIdleState(IUICard handler, UICardParameters parameters, BaseStateMachine fsm) : base(handler, parameters, fsm)
        {
            DefaultSize = Handler.transform.localScale;
        }

        public override void OnEnterState()
        {
            Handler.Input.OnPointerDown += OnPointerDown;
            Handler.Input.OnPointerEnter += OnPointerEnter;

            if (Handler.Movement.IsOperating)
            {
                DisableCollision();
                Handler.Movement.OnFinishMotion += Enable;
            }
            else
            {
                Enable();
                
            }
            MakeRendererNormal();
            Handler.ScaleTo(DefaultSize, Parameters.ScaleSpeed);
        }

        public override void OnExitState()
        {
            Handler.Input.OnPointerDown -= OnPointerDown;
            Handler.Input.OnPointerEnter -= OnPointerEnter;
            Handler.Movement.OnFinishMotion -= Enable;
        }

        private void OnPointerDown(PointerEventData obj)
        {
            if (Fsm.IsCurrent(this))
                Handler.Select(); // PushState<UiCardDrag>();
        }

        private void OnPointerEnter(PointerEventData obj)
        {
            if (Fsm.IsCurrent(this))
                Handler.Hover(); //  PushState<UiCardHover>();
        }
    }
}