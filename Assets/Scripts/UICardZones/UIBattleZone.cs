using UnityEngine;
using UnityEngine.EventSystems;

namespace UICardZones
{
    // Battle field zone
    public class UIBattleZone : UIBaseDropZone
    {
        protected override void OnPointerUp(PointerEventData eventData)
        {
            CardHand?.PlaySelected();
        }
    }
}