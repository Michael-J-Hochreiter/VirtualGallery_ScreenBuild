using System;
using TMPro;
using UnityEngine;

namespace VirtualGallery.Scripts
{
    public class InteractionHint : MonoBehaviour
    {
        public TextMeshProUGUI interactionHintText;
        private float _duration = 5.0f;
        private float _elapsedTime;


        private void Start()
        {
            _elapsedTime = Time.time;
        }

        void Update()
        {
            if (_elapsedTime > _duration || Input.GetKey(KeyCode.Space))
            {
                interactionHintText.CrossFadeAlpha(0, 0.5f, false);
            }

            Debug.Log(Time.time);
        }
    }
}