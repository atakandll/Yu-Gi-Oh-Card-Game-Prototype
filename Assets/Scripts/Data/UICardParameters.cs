using System.Security.Cryptography.X509Certificates;
using Attributes;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName ="CardConfigParameters")]
    public class UICardParameters : ScriptableObject
    {
        #region Disable
        
        public float DisabledAlpha
        {
            get => disabledAlpha;
            set => disabledAlpha = value;
        }

        [Header("Disable")] [Tooltip("How card fades when disabled")] [Range(0.1f, 1f)] [SerializeField]
        private float disabledAlpha;

        #endregion

        #region Hover

        public float HoverHeight
        {
            get => hoverHeight;
            set => hoverHeight = value;
        }
        public bool HoverRotation
        {
            get => hoverRotation;
            set => hoverRotation = value;
        }
        public float HoverScale
        {
            get => hoverScale;
            set => hoverScale = value;
        }
        [Header("Hover")][Tooltip("How much the card will go upwards when hovered")] [SerializeField]
        private float hoverHeight;
        [SerializeField] [Tooltip("Whether the hovered card keep its rotation.")] private bool hoverRotation;
        [SerializeField] [Tooltip("How much hovered card scales")] private float hoverScale;
        [SerializeField]
        [Range(0,25)]
        [Tooltip("Speed of a card while it is hovering")]
        private float hoverSpeed;

        #endregion

        #region Bend

        public float Height
        {
            get => height;
            set => height = value;
        }
        public float BentAngle
        {
            get => bentAngle;
            set => bentAngle = value;
        }
        public float Spacing
        {
            get => spacing;
            set => spacing = value;
        }

        [Header("Bend")] [Tooltip("Height factor between two cards.")] [Range(0f, 1f)]
        [SerializeField] private float height;
        
        [SerializeField] [Tooltip("Total angle in degrees the card will bend")] [Range(0f, 60f)]
        private float bentAngle;
        
        [SerializeField] [Tooltip("Amount of space between the cards on the X axis")] [Range(0, -5f)]
        private float spacing;
        


        #endregion

        #region Movement

        [Header("Rotation")]
        [SerializeField][Range(0,60)] [Tooltip("Speed of a card while it is rotating")]
        private float rotationSpeed;
        
        [Range(0,1000)]
        [Tooltip("Speed of a card while it is rotating for player 2")]
        [SerializeField] private float rotationSpeedP2;
        
        [Header("Movement")] [SerializeField] [Range(0,15)] [Tooltip("Speed of a card while it is moving")]
        private float movementSpeed;
        
        [Header("Scaling")] [SerializeField] [Range(0,15)] [Tooltip("Speed of a card while it is scaling")]
        private float scaleSpeed;

        public float HoverSpeed { get => hoverSpeed; set => hoverSpeed = value; }
        public float MovementSpeed { get => movementSpeed; set => movementSpeed = value; }
        public float RotationSpeed { get => rotationSpeed; set => rotationSpeed = value; }
        public float ScaleSpeed { get => scaleSpeed; set => scaleSpeed = value;}
        public float RotationSpeedP2 { get => rotationSpeedP2; set => rotationSpeedP2 = value; }
        
        #endregion

        #region Draw Discard

        [Header("Draw")][SerializeField][Range(0,1)][Tooltip("Scale when draw the card")]
        private float startSizeWhenDraw;
        
        public float StartSizeWhenDraw
        {
            get => startSizeWhenDraw;
            set => startSizeWhenDraw = value;
        }
        
        [Header("Discard")][SerializeField][Range(0,1)][Tooltip("Scale when discard the card")]
        private float discardedSize;

        public float DiscardedSize => discardedSize;

        #endregion

       [Button]
       public void SetDefaults()
       {
           disabledAlpha = 0.5f;

           hoverHeight = 1;
           hoverRotation = false;
           hoverScale = 1.3f;
           hoverSpeed = 15f;

           height = 0.12f;
           spacing = -2;
           bentAngle = 20;

           rotationSpeedP2 = 500;
           rotationSpeed = 20;
           movementSpeed = 4;
           scaleSpeed = 7;

           startSizeWhenDraw = 0.05f;
           discardedSize = 0.5f;
       }


    }
}