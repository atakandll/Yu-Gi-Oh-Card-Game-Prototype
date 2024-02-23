using System;
using Data;
using Extensions;
using UnityEngine;

namespace UICardHand
{
    // Class responsible to bend the cards in the player hand
    public class UICardBender : MonoBehaviour
    {
        #region Unity Callbacks

        private void Awake()
        {
            CardHand = GetComponent<UiCardHand>();
            CardRenderer = cardPrefab.GetComponent<SpriteRenderer>();
            CardHand.OnPileChanged += Bend;
        }

        #endregion

        #region Fields and Properties

        [SerializeField] private UICardParameters parameters;

        [SerializeField] [Tooltip("The Card Prefab")]
        private UICardHandComponent cardPrefab;

        [SerializeField] [Tooltip("Transform used as anchor to position the cards")]
        private Transform pivot;
        
        private SpriteRenderer CardRenderer { get; set; }
        private float CardWidth => CardRenderer.bounds.size.x;
        private IUICardHand CardHand { get; set; }

        #endregion

        #region  Operation

        private void Bend(IUICard[] cards)
        {
            if(cards == null)
                throw new ArgumentNullException("Null is not a valid card");

            var fullAngle = -parameters.BentAngle;
            var anglePerCard = fullAngle / cards.Length;
            var firsAngle = CalcFirstAngle(fullAngle);
            var handWidth = CalcHandWidth(cards.Length);

            var pivotLocationFactor = pivot.CloserEdge(Camera.main, Screen.width, Screen.height);
            
            // calculation first position of the offset on X axis
            var offsetX = pivot.position.x - handWidth / 2;

            for (var i = 0; i < cards.Length; i++)
            {
                var card = cards[i];
                
                // set card Z angle
                var angleTwist = (firsAngle + i * anglePerCard) * pivotLocationFactor;
                
                //calc x position
                var xPos = offsetX + CardWidth / 2;

                //calc y position
                var yDistance = Mathf.Abs(angleTwist) * parameters.Height;
                var yPos = pivot.position.y - (yDistance * pivotLocationFactor);

                //set position
                if (!card.IsDragging && !card.IsHovering)
                {
                    var zAxisRot = pivotLocationFactor == 1 ? 0 : 180;
                    var rotation = new Vector3(0, 0, angleTwist - zAxisRot);
                    var position = new Vector3(xPos, yPos, card.transform.position.z);

                    var rotSpeed = card.IsPlayer ? parameters.RotationSpeed : parameters.RotationSpeedP2;
                    card.RotateTo(rotation, rotSpeed);
                    card.MoveTo(position, parameters.MovementSpeed);
                }

                //increment offset
                offsetX += CardWidth + parameters.Spacing;
            }
        }
        
        // Calculus of the angle of the first card
        private static float CalcFirstAngle(float fullAngle)
        {
            var magicMathFactor = 0.1f;
            return -(fullAngle / 2) + fullAngle * magicMathFactor;
        }
        
        // Calculus of the width of the player's hand
        private float CalcHandWidth(int quantityOfCards)
        {
            var widthCards = quantityOfCards * CardWidth;
            var widthSpacing = (quantityOfCards - 1) * parameters.Spacing;
            return widthCards + widthSpacing;
        }

        

        #endregion

    }
}