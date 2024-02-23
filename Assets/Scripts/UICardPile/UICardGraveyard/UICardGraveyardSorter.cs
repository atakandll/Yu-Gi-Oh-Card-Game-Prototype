using System;
using Data;
using UICardHand;
using UnityEngine;

namespace UICardPile.UICardGraveyard
{
    [RequireComponent(typeof(UiCardGraveyard))]
    public class UICardGraveyardSorter : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("World point where the graveyard is positioned")]
        private Transform graveyardPosition;

        [SerializeField] private UICardParameters parameters;
        private IUICardPile CardGraveyard { get; set; }

        private void Awake()
        {
            CardGraveyard = GetComponent<UiCardGraveyard>();
            CardGraveyard.OnPileChanged += Sort;

        }

        public void Sort(IUICard[] cards)
        {
            if(cards == null)
                throw new ArgumentNullException("Null is not a valid card");

            var lastPos = cards.Length - 1;
            var lastCard = cards[lastPos];
            var gravPos = graveyardPosition.position + new Vector3(0, 0, -5);
            var backGravPos = graveyardPosition.position;
            
            // Move last
            lastCard.MoveToWithZAxis(gravPos,parameters.MovementSpeed);
            
            // move other
            for (var i = 0; i < cards.Length - 1; i++)
            {
                var card = cards[i];
                card.MoveToWithZAxis(backGravPos, parameters.MovementSpeed);
            }
        }
    }
}