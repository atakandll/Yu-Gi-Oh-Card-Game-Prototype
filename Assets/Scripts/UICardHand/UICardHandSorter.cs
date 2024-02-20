using System;
using UICardPile;
using UnityEngine;

namespace UICardHand
{
    public class UICardHandSorter : MonoBehaviour
    {
        private const int offSetZ = -1;
        private IUICardPile CardHand { get; set; }

        private void Awake()
        {
            CardHand = GetComponent<UICardHand>();
            CardHand.OnPileChanged += Sort;
        }

        public void Sort(IUICard[] cards)
        {
            if (cards == null)
                throw new ArgumentNullException("Null is not a valid card");
             
            var layerZ = 0;
            
            foreach (var card in cards)
            {
                var localCardPosition = card.Transform.localPosition;
                localCardPosition.z = layerZ;
                card.Transform.localPosition = localCardPosition;
                layerZ += offSetZ;
                
            }
        }
    }
}