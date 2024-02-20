using System;
using Attributes;
using UICardPile;
namespace UICardHand
{
    
    // Card hand hold a register of cards
    public class UiCardHand : UiCardPile, IUICardHand
    {
        #region Properties

         /// Card currently selected by the player.
         public IUICard SelectedCard { get; private set; }
         private event Action<IUICard> onCardSelected = card => { };
         private event Action<IUICard> onCardPlayed = card => { };

        #endregion


        public void UnselectCard(IUICard card)
        {
            throw new NotImplementedException();
        }

        Action<IUICard> IUICardHand.OnCardPlayed 
        { 
            get => onCardPlayed; 
            set => onCardPlayed = value; 
        }

        Action<IUICard> IUICardHand.OnCardSelected
        {
            get => onCardSelected; 
            set => onCardSelected = value; 
            
        }

        #region Operations

        /// Select the card in the parameter
        public void SelectCard(IUICard card)
        {
            SelectedCard = card ?? throw new ArgumentNullException("Null is not a valid card");
            DisableCards();
            NotifyCardSelected();
        }
        
        /// Play the card which is currently selected. Nothing happens if current is null.
        public void PlaySelected()
        {
            if(SelectedCard == null)
                return;
            
            PlayCard(SelectedCard);
        }
        

        /// Play the card in the parameter
        public void PlayCard(IUICard card)
        {
            if(card == null)
                throw new ArgumentNullException("Null is not a valid card");
            
            SelectedCard = null;
            RemoveCard(card);
            onCardPlayed?.Invoke(card);
            EnableCards();
            NotifyPileChange();
        }
        
        /// Unselect the card in the paramater
        public void UnSelectCard(IUICard card)
        {
            if(card == null)
                return;
            SelectedCard = null;
            card.Unselect();
            NotifyPileChange();
            EnableCards();
        }
        /// Unselect the card which is currentlSelectedç Nothing happens if current is null.
        public void UnSelect()
        {
            UnSelectCard(SelectedCard);
        }
        
        
        /// Disable input fot all cards
        public void DisableCards()
        {
            foreach (var card in Cards)
                card.Disable();
        }
        
        ///     Enables input for all cards.
        public void EnableCards()
        {
            foreach (var otherCard in Cards)
                otherCard.Enable();
        }

        [Button]
        private void NotifyCardSelected()
        {
            onCardSelected?.Invoke(SelectedCard);
        }

        #endregion
    }
}