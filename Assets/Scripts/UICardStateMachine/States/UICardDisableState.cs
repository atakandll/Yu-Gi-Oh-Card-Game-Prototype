using Data;
using Patterns.StateMachine;
using UICardHand;

namespace UICardStateMachine.States
{
    public class UICardDisableState : UIBaseCardState
    {
        public UICardDisableState(IUICard handler, UICardParameters parameters, BaseStateMachine fsm) : base(handler, parameters, fsm)
        {
        }

        public override void OnEnterState()
        {
            Disable();
        }
    }
}