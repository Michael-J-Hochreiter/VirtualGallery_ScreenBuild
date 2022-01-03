using UnityEngine;
using UnityEngine.UI;
using VirtualArtGalleryAssets.scripts;

//add script to ui slider

//lets the user determine the mouse sensitivity
//sensitivity is saved with PlayerPrefs

namespace VirtualGallery.Scripts
{
    public class SensitivityManager : MonoBehaviour
    {
        [SerializeField] private Slider sensitivitySlider;

        void Start()
        {
            if (!PlayerPrefs.HasKey("sensitivity"))
            {
                PlayerPrefs.SetFloat("sensitivity", 0.5f);
                Load();
            }
            else
            {
                Load();
            }
        }

        public void ChangeSensitivity()
        {
            GameObject.Find("First person camera").GetComponent<FirstPersonLook>()
                .ChangeMouseSensitivity(sensitivitySlider.value);
            Save();
        }

        private void Load()
        {
            sensitivitySlider.value = PlayerPrefs.GetFloat("sensitivity");
        }

        private void Save()
        {
            PlayerPrefs.SetFloat("sensitivity", sensitivitySlider.value);
        }
    }
}