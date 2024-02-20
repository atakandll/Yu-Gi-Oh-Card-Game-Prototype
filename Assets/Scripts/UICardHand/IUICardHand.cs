using System;
using UICardPile;

namespace UICardHand
{
    public interface IUICardHand : IUICardPile
    {
        void PlaySelected();
        void UnSelect();
        void PlayCard(IUICard card);
        void SelectCard(IUICard card);
        void UnselectCard(IUICard card);
        Action<IUICard> OnCardPlayed { get; set; }
        Action<IUICard> OnCardSelected { get; set; }

    }
}