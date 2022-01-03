﻿using UnityEngine;

namespace VirtualArtGalleryAssets.scripts
{
    public class FirstPersonLook : MonoBehaviour
    {
        [SerializeField] Transform character;
        Vector2 currentMouseLook;
        Vector2 appliedMouseDelta;
        public float sensitivity = 0.5f;
        public float smoothing = 2;
        private bool cursorUnlocked = false;

        void Reset()
        {
            character = GetComponentInParent<FirstPersonMovement>().transform;
        }

        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        void FixedUpdate()
        {
            if (!cursorUnlocked)
            {
                // Get smooth mouse look.
                Vector2 smoothMouseDelta =
                    Vector2.Scale(new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")),
                        Vector2.one * sensitivity * smoothing);
                appliedMouseDelta = Vector2.Lerp(appliedMouseDelta, smoothMouseDelta, 1 / smoothing);
                currentMouseLook += appliedMouseDelta;
                currentMouseLook.y = Mathf.Clamp(currentMouseLook.y, -90, 90);

                // Rotate camera and controller.
                transform.localRotation = Quaternion.AngleAxis(-currentMouseLook.y, Vector3.right);
                character.localRotation = Quaternion.AngleAxis(currentMouseLook.x, Vector3.up);
            }

            if (Input.GetKey(KeyCode.Space))
            {
                ResetSmoothing();
                cursorUnlocked = true;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
            }
            else
            {
                cursorUnlocked = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }

        public void ChangeMouseSensitivity(float newSensitivity)
        {
            sensitivity = newSensitivity;
        }

        public void ResetSmoothing()
        {
            Vector2 smoothMouseDelta =
                Vector2.Scale(new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")),
                    Vector2.one * sensitivity * smoothing);
            appliedMouseDelta = Vector2.Lerp(appliedMouseDelta, smoothMouseDelta, 1 / smoothing);
        }
    }
}