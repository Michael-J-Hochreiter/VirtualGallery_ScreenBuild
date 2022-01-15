using System;
using TMPro;
using UnityEngine;

namespace VirtualGallery.Scripts
{
    public class InteractionHint : MonoBehaviour
    {
        public TextMeshProUGUI interactionHintText;
        public float duration = 5.0f;

        void Update()
        {
            if (Time.timeSinceLevelLoad > duration || Input.GetKey(KeyCode.Space))
            {
                interactionHintText.CrossFadeAlpha(0, 0.3f, false);
            }
        }
    }
}