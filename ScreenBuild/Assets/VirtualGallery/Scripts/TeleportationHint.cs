using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace VirtualGallery.Scripts
{
    public class TeleportationHint : MonoBehaviour
    {
        public TextMeshProUGUI teleportationHintText;
        
        public void OnMouseEnter()
        {
            teleportationHintText.CrossFadeAlpha(1, 0.1f, false);
            Debug.Log("enter");
        }
        
        public void OnMouseOver()
        {
            teleportationHintText.CrossFadeAlpha(1, 0.1f, false);
            Debug.Log("over");
        }

        public void OnMouseExit()
        {
            teleportationHintText.CrossFadeAlpha(0, 0.1f, false);
            Debug.Log("exit");
        }
        
        public void OnPointerEnter(PointerEventData pointerEventData)
        {
            //Output to console the GameObject's name and the following message
            Debug.Log("Cursor Entering " + name + " GameObject");
        }
        
        public void OnPointerExit(PointerEventData pointerEventData)
        {
            //Output the following message with the GameObject's name
            Debug.Log("Cursor Exiting " + name + " GameObject");
        }
    }
}
