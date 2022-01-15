using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
        
        public Button backButton;
        public TextMeshProUGUI interactionHintText;

        public GameObject displayParent;
        
        private List<GameObject> audioDisplays = new List<GameObject>();
        private List<GameObject> videoDisplays = new List<GameObject>();      
        private List<GameObject> codeDisplays = new List<GameObject>();
        
        
        private void Start()
        {
            GameObject audioDisplaysParent = displayParent.transform.Find("Audio").gameObject;
            GameObject videoDisplaysParent = displayParent.transform.Find("Video").gameObject;
            GameObject codeDisplaysParent = displayParent.transform.Find("Code").gameObject;

            // find all displays to play/pause and add them to the lists 
            for (int i = 0; i < audioDisplaysParent.transform.childCount; i++)
            {
                audioDisplays.Add(audioDisplaysParent.transform.GetChild(i).gameObject);
            }
            for (int i = 0; i < videoDisplaysParent.transform.childCount; i++)
            {
                videoDisplays.Add(videoDisplaysParent.transform.GetChild(i).gameObject);
            }
            for (int i = 0; i < codeDisplaysParent.transform.childCount; i++)
            {
                codeDisplays.Add(codeDisplaysParent.transform.GetChild(i).gameObject);
            }
        }

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

            interactionHintText.enabled = false;
            buttonHint.SetActive(false);
            pauseMenu.SetActive(true);
            _gameIsPaused = true;
            firstPersonLook.enabled = false;

            Time.timeScale = 0f;

            PauseDisplays();
        }

        public void Restart()
        {
            Pause();
            SceneManager.LoadScene("MainScene");
            Resume();
        }

        public void QuitGame()
        {
            Application.Quit();
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

        private void PauseDisplays()
        {
            for (int i = 0; i < audioDisplays.Count; i++)
            {
                audioDisplays[i].GetComponent<DisplayLogic_Audio>().Pause();
            }
            for (int i = 0; i < videoDisplays.Count; i++)
            {
                videoDisplays[i].GetComponent<DisplayLogic_Video>().Pause();
            }
            for (int i = 0; i < codeDisplays.Count; i++)
            {
                codeDisplays[i].GetComponent<DisplayLogic_Code>().Pause();
            } 
        }
    }
}