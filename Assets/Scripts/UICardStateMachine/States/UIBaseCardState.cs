using Data;
using Patterns.StateMachine;
using UICardHand;

namespace UICardStateMachine.States
{
    public class UIBaseCardState : IState
    {
        private const int LayerToRenderNormal = 0;
        private const int LayerToRenderTop = 1;

        protected IUICard Handler { get; }
        protected UICardParameters Parameters { get; }
        protected BaseStateMachine Fsm { get; }
        public bool IsInitialized { get; }
        
        #region Constructors
        
        protected UIBaseCardState(IUICard handler, UICardParameters parameters, BaseStateMachine fsm)
        {
            Handler = handler;
            Parameters = parameters;
            Fsm = fsm;
            IsInitialized = true;
        }
        
        #endregion

        #region  Operations

        // Renders the textures in the first layer. Each card state is responsible to handle its own layer activity.
        protected virtual void MakeRenderFirst()
        {
            for (var i = 0; i < Handler.Renderers.Length; i++)
                Handler.Renderers[i].sortingOrder = LayerToRenderTop;
        }
        
        //Renders the textures in the regular layer, each card state is responsible to handle its own layer activity
        protected virtual void MakeRendererNormal()
        {
            for (var i = 0; i < Handler.Renderers.Length; i++)
                if (Handler.Renderers[i])
                    Handler.Renderers[i].sortingOrder = LayerToRenderNormal;
        }
        
        // Enable the card entirely, Collision, Rigidbody and adds Alpha
        protected void Enable()
        {
            if (Handler.Collider)
                EnableCollision();
            if(Handler.Rigidbody)
                Handler.Rigidbody.Sleep();

            MakeRendererNormal();
            RemoveAllTransparency();

        }
        
        // Disable the card entirely. Collision, Rigidbody and adds Alpha
        protected virtual void Disable()
        {
            DisableCollision();
            Handler.Rigidbody.Sleep();
            MakeRendererNormal();

            foreach (var renderer in Handler.Renderers)
            {
                var myColor = renderer.color;
                myColor.a = Parameters.DisabledAlpha;
                renderer.color = myColor;
            }
        }
        
        // Disables the collision with this card
        protected void DisableCollision()
        {
            Handler.Collider.enabled = false;
        }
        
        // Enabled the collision with this card
        protected void EnableCollision()
        {
            Handler.Collider.enabled = true;
        }
        protected void RemoveAllTransparency()
        {
            foreach(var renderer in Handler.Renderers)
                if (renderer)
                {
                    var myColor = renderer.color;
                    myColor.a = 1;
                    renderer.color = myColor;
                }
                   
            
        }

        #endregion

        #region Finite State Machine

        void IState.OnInitialize()
        {
        }

        public virtual void OnEnterState()
        {
        }

        public virtual void OnExitState()
        {
        }

        public virtual void OnUpdate()
        {
        }

        public virtual void OnClear()
        {
        }

        public virtual void OnNextState(IState nextState)
        {
        }


        #endregion
    }
}