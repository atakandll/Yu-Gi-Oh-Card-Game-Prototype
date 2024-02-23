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
            CardHand = GetComponent<UiCardHand>();
            CardHand.OnPileChanged += Sort;
        }

        public void Sort(IUICard[] cards)
        {
            if (cards == null)
                throw new ArgumentNullException("Null is not a valid card");
             
            var layerZ = 0;
            
            foreach (var card in cards)
            {
                var localCardPosition = card.transform.localPosition;
                localCardPosition.z = layerZ;
                card.transform.localPosition = localCardPosition;
                layerZ += offSetZ;
                
            }
        }
    }
}