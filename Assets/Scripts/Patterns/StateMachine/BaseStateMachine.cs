using System;
using System.Collections.Generic;

namespace Patterns.StateMachine
{
    public class BaseStateMachine
    {
        #region Properties

        public bool IsInitialized { get; protected set; }
        
        
        // Stack of states
        private readonly Stack<IState> stack = new Stack<IState>();
        
        // This register does not allow the FSM to have two states with same Type
        private readonly Dictionary<Type, IState> register = new Dictionary<Type, IState>();
        
        // Handler for the FSM. Usually the MonoBehaviour which holds this FSM
        public IStateMachineHandler Handler { get; set; }
        
        // Return the state on the top of the stack. Can be null
        public IState Current => PeekState();

        #endregion

        #region Constructors

        protected BaseStateMachine(IStateMachineHandler handler)
        {
            Handler = handler;
        }
        

        #endregion
    }
}