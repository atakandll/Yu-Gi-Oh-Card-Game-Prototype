using UnityEngine.EventSystems;

namespace UICardZones
{
    // Game controller hand zone
    public class UIHandZone : UIBaseDropZone
    {
        protected override void OnPointerUp(PointerEventData eventData)
        {
            CardHand?.UnSelect();
        }
    }
}