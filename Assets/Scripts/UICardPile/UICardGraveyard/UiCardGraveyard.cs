using System;
using UICardHand;
using UnityEngine;

namespace UICardPile.UICardGraveyard
{
    // Card graveyard holds a register with cards played by the player
    public class UiCardGraveyard : UiCardPile
    {
        [SerializeField][Tooltip("World point where the graveyard is positioned")]
        private Transform graveyardPosition;
        
        private IUICardHand CardHand { get; set;}

        protected override void Awake()
        {
            base.Awake();
            CardHand = transform.parent.GetComponentInChildren<UiCardHand>();
            CardHand.OnCardPlayed += AddCard;
        }
        
        // Adds a card to the graveyard or discard pile
        public override void AddCard(IUICard card)
        {
            if(card == null)
                throw new ArgumentNullException("Null is not a valid card");
            
            Cards.Add(card);
            card.transform.SetParent(graveyardPosition);
            card.Discard();
            NotifyPileChange();
        }
        
        // Removes a card from the graveyard or discard pile
        public override void RemoveCard(IUICard card)
        {
            if(card == null)
                throw new ArgumentNullException("Null is not a valid card");
            
            Cards.Remove(card);
            NotifyPileChange();
            
        }
    }
}