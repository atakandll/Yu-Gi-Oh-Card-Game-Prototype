using Data;
using Patterns.StateMachine;
using UICardHand;
using UnityEngine;

namespace UICardStateMachine.States
{
    public class UICardDragState : UIBaseCardState
    {
        private Vector3 StartEuler { get; set; }
        private Camera myCamera { get; set; }
        public UICardDragState(IUICard handler, Camera camera,UICardParameters parameters, BaseStateMachine fsm) : base(handler, parameters, fsm)
        {
            myCamera = camera;
        }

        private Vector3 WorldPoint()
        {
            var mousePosition = Handler.Input.MousePosition;
            var worldPoint = myCamera.ScreenToWorldPoint(mousePosition);
            return worldPoint;
        }

        private void FollowCursor()
        {
            var myZ = Handler.Transform.position.z;
            Handler.Transform.position = WorldPoint().WithZ(myZ);
        }

        public override void OnUpdate()
        {
            FollowCursor();
        }

        public override void OnEnterState()
        {
            // stop any movement
            Handler.Movement.StopMotion();
            
            //cache old values
            StartEuler = Handler.Transform.eulerAngles;
            
            Handler.RotateTo(Vector3.zero, Parameters.RotationSpeed);
            MakeRenderFirst();
            RemoveAllTransparency();
        }

        public override void OnExitState()
        {
            //reset position and rotation
            if (Handler.Transform)
            {
                Handler.RotateTo(StartEuler,Parameters.RotationSpeed);
                MakeRendererNormal();
            }
            DisableCollision();
        }
    }
}