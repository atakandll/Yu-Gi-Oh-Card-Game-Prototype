using System;
using System.Collections.Generic;
using Attributes;
using UICardHand;
using UnityEngine;

namespace UICardPile
{
    public abstract class UiCardPile : MonoBehaviour, IUICardPile
    {
        #region Properties

        // List with all cards
        public List<IUICard> Cards { get; private set; }
        
        // Event raised when add or remove a card
        private event Action<IUICard[]> onPileChanged = hand => { };

        #endregion

        public Action<IUICard[]> OnPileChanged
        {
            get => onPileChanged; 
            set => onPileChanged = value;
        }
        public virtual void AddCard(IUICard card)
        {
            if(card == null)
                throw new ArgumentNullException("Null is not a valid card");
            
            Cards.Add(card);
            card.transform.SetParent(transform);

            NotifyPileChange();
            card.Draw();
            
        }
        

        public virtual void RemoveCard(IUICard card)
        {
            if(card == null)
                throw new ArgumentNullException("Null is not a valid card");
            
            Cards.Remove(card);
            NotifyPileChange();
        }

        [Button]
        protected virtual void Clear()
        {
            var childCards = GetComponentsInChildren<IUICard>();
            foreach (var uiCardHand in childCards)
                Destroy(uiCardHand.gameObject);
            
            Cards.Clear(); // removes all the element
            
        }

        [Button]
        public void NotifyPileChange()
        {
            onPileChanged?.Invoke(Cards.ToArray());
        }

        protected virtual void Awake()
        {
            Cards = new List<IUICard>();
            Clear();
        }
    }
}