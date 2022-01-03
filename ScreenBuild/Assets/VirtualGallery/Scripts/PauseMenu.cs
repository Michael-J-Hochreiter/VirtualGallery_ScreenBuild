using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using VirtualArtGalleryAssets.scripts;

//add script to canvas of the pause menu

//pause menu is shown when the escape key has been pressed
//from there, the user can access the settings and the map teleportation

namespace VirtualGallery.Scripts
{
    public class PauseMenu : MonoBehaviour
    {
        private bool _gameIsPaused;
        public GameObject pauseMenu;
        public GameObject player;
        public GameObject teleport3D;
        public GameObject teleport2D;
        public GameObject teleportVideo;
        public GameObject teleportAudio;
        public GameObject teleportCode;
        public GameObject teleportLobby;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (_gameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
            
        }

        public void Resume()
        {
            var firstPersonLook = GameObject.Find("First person camera").GetComponent<FirstPersonLook>();

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            _gameIsPaused = false;
            
            firstPersonLook.enabled = true;
        }

        void Pause()
        {
            GameObject.Find("First person camera").GetComponent<FirstPersonLook>().ResetSmoothing();
            
            var firstPersonLook = GameObject.Find("First person camera").GetComponent<FirstPersonLook>();

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            _gameIsPaused = true;
            
            firstPersonLook.enabled = false;
        }

        public void Restart()
        {
            Pause();
            SceneManager.LoadScene(0);
            Resume();
        }
        
        public void QuitGame()
        {
            Application.Quit();
        }

        public void ChangeMode()
        {
            var text = GameObject.Find("ThemeButton").GetComponentInChildren<Text>().text;

            switch (text)
            {
                case "LIGHT":
                    GameObject.Find("ThemeButton").GetComponentInChildren<Text>().text = "DARK";
                    break;
                case "DARK":
                    GameObject.Find("ThemeButton").GetComponentInChildren<Text>().text = "LIGHT";
                    break;
            }
        }

        public void Teleport3D()
        {
            Resume();
            player.transform.position = teleport3D.transform.position;
        }

        public void Teleport2D()
        {
            Resume();
            player.transform.position = teleport2D.transform.position;
        }

        public void TeleportCode()
        {
            Resume();
            player.transform.position = teleportVideo.transform.position;
        }

        public void TeleportVideo()
        {
            Resume();
            player.transform.position = teleportAudio.transform.position;
        }

        public void TeleportAudio()
        {
            Resume();
            player.transform.position = teleportCode.transform.position;
        }

        public void TeleportLobby()
        {
            Resume();
            player.transform.position = teleportLobby.transform.position;
        }
    }
}