using UICardHand;
using UnityEngine;

namespace UICardTransform
{
    public class UIMotionMovementCard : UIMotionBaseCard
    {
        public UIMotionMovementCard(IUICard handler) : base(handler)
        {
        }
        private  bool WithZ { get; set; }

        public override void Execute(Vector3 position, float speed, float delay, bool withZ)
        {
            WithZ = withZ;
            base.Execute(position, speed, delay, withZ);
        }

        protected override void OnMotionEnds()
        {
            WithZ = false;
            IsOperating = false;
            var target = Target;
            target.z = Handler.Transform.position.z;
            Handler.Transform.position = target;
            base.OnMotionEnds();
        }

        protected override void KeepMotion()
        {
            var current = Handler.Transform.position;
            var amount = Speed * Time.deltaTime;
            var delta = Vector3.Lerp(current, Target, amount);
            if(!WithZ)
                delta.z = Handler.Transform.position.z; // same z position with the current's z position
            
            Handler.Transform.position = delta;
        }
        protected override bool CheckFinalState()
        {
            var distance = Target - Handler.Transform.position;
           if(!WithZ)
               distance.z = 0;
           return distance.magnitude <= Threshold;
        }

    }
}