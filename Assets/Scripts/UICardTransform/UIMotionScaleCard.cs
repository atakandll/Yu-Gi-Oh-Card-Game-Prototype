using System;
using UICardHand;
using UnityEngine;

namespace UICardTransform
{
    public class UIMotionScaleCard : UIMotionBaseCard
    {
        public UIMotionScaleCard(IUICard handler) : base(handler)
        {
        }
        protected override void OnMotionEnds()
        {
            Handler.Transform.localScale = Target;
            IsOperating = false;
            

        }

        protected override bool CheckFinalState()
        {
            var delta = Target - Handler.Transform.localScale;
            return delta.magnitude <= Threshold;
        }

        protected override void KeepMotion()
        {
            var current = Handler.Transform.localScale;
            var amount = Speed * Time.deltaTime;
            Handler.Transform.localScale = Vector3.Lerp(current, Target, amount);
        }
    }
}