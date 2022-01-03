using UnityEngine;
using UnityEngine.UI;

//add script to ui slider

//lets the user determine the overall volume
//volume is saved with PlayerPrefs

namespace VirtualGallery.Scripts
{
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] private Slider volumeSlider;
        
        void Start()
        {
            if (!PlayerPrefs.HasKey("musicVolume"))
            {
                PlayerPrefs.SetFloat("musicVolume", 1);
                Load();
            }
            else
            {
                Load();
            }
        }

        public void ChangeVolume()
        {
            AudioListener.volume = volumeSlider.value;
            Save();
        }

        private void Load()
        {
            volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
        }

        private void Save()
        {
            PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
        }
    }
}