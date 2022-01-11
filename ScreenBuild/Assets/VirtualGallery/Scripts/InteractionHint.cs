using TMPro;
using UnityEngine;

namespace VirtualGallery.Scripts
{
    public class InteractionHint : MonoBehaviour
    {
        public TextMeshProUGUI interactionHintText;
        private float _elapsedTime;

        void Awake()
        {
            _elapsedTime = Time.time;
        }
        
        void Update()
        {
            Debug.Log(_elapsedTime);
            interactionHintText.CrossFadeAlpha(0, 1.0f, true);
        }
    }
}