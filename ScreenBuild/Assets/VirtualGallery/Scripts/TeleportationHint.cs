using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace VirtualGallery.Scripts
{
    public class TeleportationHint : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public TextMeshProUGUI teleportationHintText;

        public void OnPointerEnter(PointerEventData pointerEventData)
        {
            teleportationHintText.CrossFadeAlpha(1, 0.2f, true);
        }

        public void OnPointerExit(PointerEventData pointerEventData)
        {
            teleportationHintText.CrossFadeAlpha(0, 0.2f, true);
        }
    }
}