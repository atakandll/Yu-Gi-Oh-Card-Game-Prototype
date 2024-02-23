using System;
using System.Collections;
using Attributes;
using Extensions;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UICardHand
{
    public class UICardUtils : MonoBehaviour
    {
        #region Fields

        private int Count { get; set; }
        [SerializeField] [Tooltip("Prefab of the Card")]
        private GameObject cardPrefab;

        [SerializeField] [Tooltip("World point where the deck is positioned")]
        private Transform deckPosition;

        [SerializeField] [Tooltip("Game view transform")]
        private Transform gameView;
        
        private UiCardHand CardHand { get; set; }

        #endregion

        private void Awake()
        {
            CardHand = transform.parent.GetComponentInChildren<UiCardHand>();
        }

        private IEnumerator Start()
        {
            //starting cards
            for (int i = 0; i < 6; i++)
            {
                yield return new WaitForSeconds(0.2f);
                DrawCard();

            }
        }

        [Button]
        public void DrawCard()
        {
            var cardGo = Instantiate(cardPrefab, gameView);
            cardGo.name = "Card" + Count;
            var card = cardGo.GetComponent<IUICard>();
            card.transform.position = deckPosition.position;
            Count++;
            CardHand.AddCard(card);
        }
        [Button]
        public void PlayCard()
        {
            if (CardHand.Cards.Count > 0)
            {
                var randomCard = CardHand.Cards.RandomItem();
                CardHand.PlayCard(randomCard);
            }
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab)) DrawCard();
            if (Input.GetKeyDown(KeyCode.Space)) PlayCard();
            if (Input.GetKeyDown(KeyCode.Escape)) Restart();
        }

        public void Restart()
        {
            SceneManager.LoadScene(0);
        }

    }
}