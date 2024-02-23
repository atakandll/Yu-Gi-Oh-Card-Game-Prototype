using Data;
using Extensions;
using Tools.Input;
using UICardStateMachine;
using UICardStateMachine.States;
using UICardTransform;
using UnityEngine;
using UnityEngine.XR;

namespace UICardHand
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(IMouseInput))]
    public class UICardHandComponent : MonoBehaviour, IUICard
    {
        #region Components

        SpriteRenderer[] IUICardComponents.Renderers => MyRenderers;
        SpriteRenderer IUICardComponents.MyRenderer => MyRenderer;
        Collider IUICardComponents.Collider => MyCollider;
        Rigidbody IUICardComponents.Rigidbody => MyRigidbody;
        IMouseInput IUICardComponents.Input => MyInput;
        IUICardHand IUICardComponents.Hand => Hand;
        public MonoBehaviour MonoBehaviour => this;
        public UICardParameters CardConfigsParameters => cardConfigParameters;
        public Camera MainCamera => Camera.main;
        public bool IsDragging => Fsm.IsCurrent<UICardDragState>();
        public bool IsHovering => Fsm.IsCurrent<UICardHoverState>();
        public bool IsDisabled => Fsm.IsCurrent<UICardDisableState>();
        public bool IsPlayer => transform.CloserEdge(MainCamera, Screen.width, Screen.height) == 1;


        #endregion
        
        #region Transform

        public UIMotionBaseCard Movement { get; private set; }
        public UIMotionBaseCard Rotation { get; private set; }
        public UIMotionBaseCard Scale { get; private set; }


        #endregion

        #region Properties

        public string Name => gameObject.name;
        [SerializeField] public UICardParameters cardConfigParameters;
        private UICardHandFsm Fsm {get; set;}
        
        private Transform MyTransform { get; set; }
        private Collider MyCollider { get; set; }
        private SpriteRenderer[] MyRenderers { get; set; }
        private SpriteRenderer MyRenderer { get; set; }
        private Rigidbody MyRigidbody { get; set; }
        private IMouseInput MyInput { get; set; }
        private IUICardHand Hand { get; set; }
        
       

        #endregion

        #region Transform

        public void RotateTo(Vector3 rotation, float speed)
        {
            Rotation.Execute(rotation, speed);
        }
        public void MoveTo(Vector3 position, float speed, float delay)
        {
            Movement.Execute(position, speed, delay,false);
        }
        public void MoveToWithZAxis(Vector3 position, float speed, float delay = 0)
        {
            Movement.Execute(position, speed, delay,true);
        }
        public void ScaleTo(Vector3 scale, float speed, float delay = 0)
        {
            Scale.Execute(scale, speed, delay);
        }

        #endregion

        #region Operations

        public void Hover()
        {
            Fsm.Hover();
        }

        public void Disable()
        {
            Fsm.Disable();
        }

        public void Enable()
        {
            Fsm.Enable();
        }
        public void Select()
        {
            // to avoid the player selecting enemy's cards
            if (!IsPlayer)
                return;

            Hand.SelectCard(this);
            Fsm.Select();
        }

        public void Unselect()
        { 
            Fsm.UnSelect();
        }

        public void Draw()
        {
            Fsm.Draw();
        }

        public void Discard()
        {
            Fsm.Discard();
        }
        
        #endregion

        #region UnityCallBacks

        private void Awake()
        {
            //components
            MyTransform = transform;
            MyCollider = GetComponent<Collider>();
            MyRigidbody = GetComponent<Rigidbody>();
            MyInput = GetComponent<IMouseInput>();
            Hand = transform.parent.GetComponentInChildren<IUICardHand>();
            MyRenderers = GetComponentsInChildren<SpriteRenderer>();
            MyRenderer = GetComponent<SpriteRenderer>();

            //transform
            Scale = new UIMotionScaleCard(this);
            Movement = new UIMotionMovementCard(this);
            Rotation = new UIMotionRotationCard(this);
            
            Fsm = new UICardHandFsm(MainCamera, CardConfigsParameters, this);
        }
        private void Update()
        {
            Fsm?.Update();
            Movement?.Update();
            Rotation?.Update();
            Scale?.Update();
        }


        #endregion

    }
    
}