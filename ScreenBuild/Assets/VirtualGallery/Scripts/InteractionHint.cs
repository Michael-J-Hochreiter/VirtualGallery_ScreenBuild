using TMPro;
using UnityEngine;

namespace VirtualGallery.Scripts
{
    public class InteractionHint : MonoBehaviour
    {
        public TextMeshProUGUI interactionHintText;
        private float _duration = 5.0f;

        void Update()
        {
            if (Time.time > _duration || Input.GetKey(KeyCode.Space))
            {
                interactionHintText.CrossFadeAlpha(0, 0.5f, false);
            }

            Debug.Log(Time.time);
        }
    }
}