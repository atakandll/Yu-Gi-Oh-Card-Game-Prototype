using Patterns.StateMachine;
using UICardTransform;

namespace UICardHand
{
    public interface IUICard : IStateMachineHandler, IUICardComponents, IUICardTransform
    {
        bool IsDragging { get; }
        bool IsHovering { get; }
        bool IsDisabled { get; }
        bool IsPlayer { get; }
        void Disable ();
        void Enable ();
        void Select ();
        void Unselect ();
        void Hover ();
        void Draw ();
        void Discard ();
    }
}