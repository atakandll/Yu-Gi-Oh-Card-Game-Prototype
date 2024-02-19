using Data;
using Patterns.StateMachine;
using UICardHand;
using UICardStateMachine.States;
using UnityEngine;

namespace UICardStateMachine
{
    public class UICardHandFsm : BaseStateMachine
    {
        #region Properties

        private UICardIdleState IdleState { get; }
        private UICardDrawState DrawState { get; }
        private UICardDisableState DisableState { get; }
        private UICardHoverState HoverState { get; }
        private UICardDragState DragState { get;  }
        private UICardDiscardState DiscardState { get; }
        private UICardParameters CardConfigParameters { get; }

        #endregion
        #region Constructor

        public UICardHandFsm(Camera camera, UICardParameters cardConfigParameters, IUICard handler = null) :
            base(handler)
        {
            CardConfigParameters = cardConfigParameters;
            IdleState = new UICardIdleState(handler, cardConfigParameters, this);
            DrawState = new UICardDrawState(handler, cardConfigParameters, this);
            DisableState = new UICardDisableState(handler, cardConfigParameters, this);
            HoverState = new UICardHoverState(handler, cardConfigParameters, this);
            DragState = new UICardDragState(handler, camera, cardConfigParameters, this);
            DiscardState = new UICardDiscardState(handler, cardConfigParameters, this);
            
            RegisterState(IdleState);
            RegisterState(DrawState);
            RegisterState(DisableState);
            RegisterState(HoverState);
            RegisterState(DragState);
            RegisterState(DiscardState);
            
            Initialize();
            
        }

        #endregion

        #region Operations

        public void Hover()
        {
            PushState<UICardHoverState>();
        }

        public void Disable()
        {
            PushState<UICardDisableState>();
            
        }
        public void Select()
        {
            PushState<UICardDragState>();
        }
        public void Discard()
        {
            PushState<UICardDiscardState>();
        }
        public void Draw()
        {
            PushState<UICardDrawState>();
        }
        public void Enable()
        {
            PushState<UICardIdleState>();
        }
        public void UnSelect()
        {
            Enable();
        }

        #endregion
    }
}