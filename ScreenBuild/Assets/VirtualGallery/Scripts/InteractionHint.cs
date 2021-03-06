using TMPro;
using UnityEngine;

namespace VirtualGallery.Scripts
{
    public class InteractionHint : MonoBehaviour
    {
        public TextMeshProUGUI interactionHintText;
        public float duration = 10.0f;

        void Update()
        {
            if (Time.timeSinceLevelLoad > duration || Input.GetKey(KeyCode.Space))
            {
                interactionHintText.CrossFadeAlpha(0, 0.1f, true);
            }
        }
    }
}