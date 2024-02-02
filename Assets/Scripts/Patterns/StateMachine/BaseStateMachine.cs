using System;
using System.Collections.Generic;
using UnityEngine;

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

        #region Initialization

        // Register a state into the State Machine

        public void RegisterState(IState state)
        {
            if(state == null)
                throw new ArgumentNullException("Null is not a valid state");
            
            var type = state.GetType();
            register.Add(type,state);
            // logger operation
        }

        public void Initialize()
        {
            // Creates states
            OnBeforeInitialize();

            foreach (var state in register.Values)
                state.OnInitialize();
            
            IsInitialized = true;
            
            OnInitialize();
            // logger operation
                
            
            
        }
        // Create and register the states overriding this method. It happens before the initialization
        protected virtual void OnBeforeInitialize()
        {
        }
        
        // If you need to do something after the initialization, override this method
        protected virtual void OnInitialize()
        {
            
        }

        #endregion

        #region Operations

        // Update the FSM, consequently, updating the state on the top of the stack
        public void Update()
        { 
            Current?.OnUpdate();
            
        }
        
        // Check whether a Type is the same as the Type as the current state
        public bool IsCurrent<T>() where T : IState
        {
            return Current?.GetType() == typeof(T);
        }
        
        // Check if a StateType is the current state.
        public bool IsCurrent(IState state)
        {
            if(state == null)
                throw new ArgumentNullException("Null is not a valid state");
            
            return Current?.GetType() == state.GetType();
        }
        
        // Pushes a state by Type triggering OnEnterState for the pushed
        // State and OnExitState for the previous state in the stack.
        public void PushState<T>(bool isSilent = false) where T : IState
        {
           var stateType = typeof(T);
           var state = register[stateType];
           PushState(state, isSilent);
        }
        
        // Pushes state by instance of the class triggering OnEnterState for the pushed
        // state and if not silent OnExitState for the previous state in the stack. 
        private void PushState(IState state, bool isSilent = false)
        {
            var type = state.GetType();
            if (!register.ContainsKey(type))
                throw new ArgumentException("State " + state + " not registered yet.");

            // logger operation
            if (stack.Count > 0 && !isSilent)
                Current?.OnExitState();

            stack.Push(state);
            state.OnEnterState();
        }
        
        //Peek a state from the stack. A peek returns null if the stack is empty. It doesn't trigger any call
        public IState PeekState()
        {
            return stack.Count > 0 ? stack.Peek() : null;
        }
        
        // Pops a state from the stack. It triggers OnExitState 
        // for the popped state and if not silent OnEnterState for the subsequent stacked state
        public void PopState(bool isSilent = false)
        {
            if (Current == null)
                return;

            var state = stack.Pop();
            // logger operation
            state.OnExitState();

            if (!isSilent)
                Current?.OnEnterState();
            
        }
        // Clears and restart the states register
        public virtual void Clear()
        {
            foreach (var state in register.Values)
                state.OnClear();
            
            stack.Clear();
            register.Clear();
        }

        #endregion
    }
}