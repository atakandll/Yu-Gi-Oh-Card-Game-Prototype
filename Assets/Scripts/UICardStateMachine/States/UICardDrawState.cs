using Data;
using Patterns.StateMachine;
using UICardHand;
using UICardTransform;
using UnityEngine;

namespace UICardStateMachine.States
{
    // This state draw the collider of the card
    public class UICardDrawState : UIBaseCardState
    {
        private Vector3 startScale { get; set; }
        public UICardDrawState(IUICard handler, UICardParameters parameters, BaseStateMachine fsm) : base(handler, parameters, fsm)
        {
        }

        public override void OnEnterState()
        {
            CachePreviousScale();
            DisableCollision();
            SetScale();
            Handler.Movement.OnFinishMotion += GoToIdle;
        }

        public override void OnExitState()
        {
            Handler.Movement.OnFinishMotion -= GoToIdle;
        }

        private void GoToIdle()
        {
            Handler.Enable();  // PushState<UiCardIdle>();
        }

        private void CachePreviousScale()
        {
            var localScale = Handler.Transform.localScale;
            startScale = localScale;
            localScale *= Parameters.StartSizeWhenDraw;
            Handler.Transform.localScale = localScale;
        }

        private void SetScale()
        {
            Handler.ScaleTo(startScale,Parameters.ScaleSpeed);
        }
    }
}