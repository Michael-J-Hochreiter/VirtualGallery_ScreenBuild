using TMPro;
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
        public GameObject buttonHint;
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
            GameObject.Find("First person camera").GetComponent<FirstPersonLook>().ResetSmoothing();
            var firstPersonLook = GameObject.Find("First person camera").GetComponent<FirstPersonLook>();
            var backButton = GameObject.Find("BackButton").GetComponent<Button>();

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            backButton.onClick.Invoke();
            buttonHint.SetActive(true);
            pauseMenu.SetActive(false);
            _gameIsPaused = false;
            firstPersonLook.enabled = true;
            Time.timeScale = 1f;
        }

        void Pause()
        {
            GameObject.Find("First person camera").GetComponent<FirstPersonLook>().ResetSmoothing();
            var firstPersonLook = GameObject.Find("First person camera").GetComponent<FirstPersonLook>();

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            buttonHint.SetActive(false);
            pauseMenu.SetActive(true);
            _gameIsPaused = true;
            firstPersonLook.enabled = false;

            Time.timeScale = 0f;
        }

        public void Restart()
        {
            SceneManager.LoadScene("MainScene");
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        public void ChangeMode()
        {
            var text = GameObject.Find("ThemeButton").GetComponentInChildren<TextMeshProUGUI>().text;

            switch (text)
            {
                case "LIGHT":
                    GameObject.Find("ThemeButton").GetComponentInChildren<TextMeshProUGUI>().text = "DARK";
                    break;
                case "DARK":
                    GameObject.Find("ThemeButton").GetComponentInChildren<TextMeshProUGUI>().text = "LIGHT";
                    break;
            }
        }

        public void Teleport3D()
        {
            Resume();
            GameObject.Find("First person camera").GetComponent<FirstPersonLook>().SetLookAngle(0, 0);
            player.transform.position = teleport3D.transform.position;
        }

        public void Teleport2D()
        {
            Resume();
            GameObject.Find("First person camera").GetComponent<FirstPersonLook>().SetLookAngle(0, 0);
            player.transform.position = teleport2D.transform.position;
        }

        public void TeleportCode()
        {
            Resume();
            GameObject.Find("First person camera").GetComponent<FirstPersonLook>().SetLookAngle(0, 0);
            player.transform.position = teleportVideo.transform.position;
        }

        public void TeleportVideo()
        {
            Resume();
            GameObject.Find("First person camera").GetComponent<FirstPersonLook>().SetLookAngle(0, 0);
            player.transform.position = teleportAudio.transform.position;
        }

        public void TeleportAudio()
        {
            Resume();
            GameObject.Find("First person camera").GetComponent<FirstPersonLook>().SetLookAngle(0, 0);
            player.transform.position = teleportCode.transform.position;
        }

        public void TeleportLobby()
        {
            Resume();
            GameObject.Find("First person camera").GetComponent<FirstPersonLook>().SetLookAngle(0, 0);
            player.transform.position = teleportLobby.transform.position;
        }
    }
}