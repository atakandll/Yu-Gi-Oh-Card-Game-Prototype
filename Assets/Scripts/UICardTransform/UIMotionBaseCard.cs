using System;
using System.Collections;
using UICardHand;
using UnityEngine;

namespace UICardTransform
{
    public abstract class UIMotionBaseCard
    {
        // Dispatches when the motion ends
        public Action OnFinishMotion = () => { };

        protected UIMotionBaseCard(IUICard handler)
        {
            Handler = handler;
        }
        
        // Whether the component is still operating or not
        public bool IsOperating { get; protected set; }
        
        //Limit magnitude until the reaches the target completely
        protected virtual float Threshold => 0.01f;
        
        // Target of the motion
        protected Vector3 Target { get; set; }
        
        // Reference for the card
        protected IUICard Handler { get; }
        
        // Speed which the it moves towards the Target
        protected float Speed { get; set; }

        public void Update()
        {
            if (!IsOperating)
                return;

            if (CheckFinalState())
                OnMotionEnds();
            else
                KeepMotion();
        }
        // Check if it is reach the Threshold
        protected abstract bool CheckFinalState();
        
        // Ends the motion and dispatch motion ends
        protected virtual void OnMotionEnds()
        {
            OnFinishMotion?.Invoke();
        }
        
        // Keep the motion on update
        protected abstract void KeepMotion();
        
        // Execute the motion with the parametres
        public virtual void Execute(Vector3 vector, float speed, float delay = 0, bool withZAxis = false)
        {
            Speed = speed;
            Target = vector;
            
            if(delay ==0)
                IsOperating = true;
            //else
                //Handler operation
            
        }
        
        // Used to delay the Motion
        private IEnumerator AllowMotion(float delay)
        {
            yield return new WaitForSeconds(delay);
            IsOperating = true;
        }
        
        //Stop the motion
        public virtual void StopMotion()
        {
            IsOperating = false;
            
        }
    }
}