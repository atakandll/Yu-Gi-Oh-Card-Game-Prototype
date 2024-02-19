using Data;
using Patterns.StateMachine;
using UICardHand;
using UnityEngine;

namespace UICardStateMachine.States
{
    public class UICardDiscardState : UIBaseCardState
    {
        private Vector3 startScale { get; set; }

        public UICardDiscardState(IUICard handler, UICardParameters parameters, BaseStateMachine fsm) : base(handler, parameters, fsm)
        {
        }
        
        

        public override void OnEnterState()
        {
            Disable();
            SetScale();
            SetRotation();
        }

        private void SetScale()
        {
            var finalScale = Handler.Transform.localScale * Parameters.DiscardedSize;
            Handler.ScaleTo(finalScale,Parameters.ScaleSpeed);
        }

        private void SetRotation()
        {
            var speed = Handler.IsPlayer ? Parameters.RotationSpeed : Parameters.RotationSpeedP2;
            Handler.RotateTo(Vector3.zero, speed);
        }
    }
}