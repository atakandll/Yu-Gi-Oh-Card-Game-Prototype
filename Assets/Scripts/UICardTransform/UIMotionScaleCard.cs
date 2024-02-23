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
            Handler.transform.localScale = Target;
            IsOperating = false;
            

        }

        protected override bool CheckFinalState()
        {
            var delta = Target - Handler.transform.localScale;
            return delta.magnitude <= Threshold;
        }

        protected override void KeepMotion()
        {
            var current = Handler.transform.localScale;
            var amount = Speed * Time.deltaTime;
            Handler.transform.localScale = Vector3.Lerp(current, Target, amount);
        }
    }
}