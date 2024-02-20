using System;
using UICardHand;

namespace UICardPile
{
    public interface IUICardPile
    {
        Action<IUICard[]> OnPileChanged { get; set; }
        void AddCard(IUICard card);
        void RemoveCard(IUICard card);
    }
}