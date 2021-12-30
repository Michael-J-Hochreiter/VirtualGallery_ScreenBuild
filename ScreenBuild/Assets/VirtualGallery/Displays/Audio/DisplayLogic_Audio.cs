using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayLogic_Audio : MonoBehaviour
{
    private const int numWorks = 3;     // total number of works in 3D-display
    private int index = 0;      // indicates which of the works is currently displayed

    // public variables to be filled in inside unity inspector
    [TextArea(5,10)] public String projectInfo;     // information/description of project
    public String[] Names = new String[numWorks];      // names of students
    public AudioClip[] Audios = new AudioClip[numWorks];
    public AudioSource GlobalAudioSource;   // global scene audio source that plays ambience
    public Camera SceneCamera;      // main scene camera used for UI worldspace interaction

    private GameObject playPause_button;
    private AudioSource localAudioSource;   // local audio source that plays clips of this display
    private float globalAudioMaxVolume = 0.1f;    // maximum volume of scene audio 
    private float globalAudioMinVolume = 0.1f;     // minimum volume of scene audio 
    
    void Start()
    {
        playPause_button = transform.Find("UI").Find("UI_interface").Find("playPause_button").gameObject;
        playPause_button.transform.Find("play_image").gameObject.SetActive(true);
        playPause_button.transform.Find("pause_image").gameObject.SetActive(false);
        localAudioSource = transform.Find("audioPlayer").Find("audioSource").gameObject.GetComponent<AudioSource>();
        
        SetProjectInfo();
        LoadWork();
        initiateCameraInUI();
    }
    
    public void NextWork()  // call LoadWork() with increased index
    {
        index = (index + 1) % Names.Length;   // cycle through index forwards
        
        LoadWork();
    }
    
    public void PrevWork()  // call LoadWork() with decreased index
    {
        index -= 1;
        if (index < 0)      // cycle through index backwards
        {
            index = Names.Length - 1;
        }
        
        LoadWork();
    }
    
    public void PlayPause()
    {
        if (localAudioSource.isPlaying)
        {
            GlobalAudioSource.volume = globalAudioMaxVolume;
            localAudioSource.Pause();
            playPause_button.transform.Find("play_image").gameObject.SetActive(true);
            playPause_button.transform.Find("pause_image").gameObject.SetActive(false);
        }
        else
        {
            GlobalAudioSource.volume = globalAudioMinVolume;
            localAudioSource.Play();
            playPause_button.transform.Find("play_image").gameObject.SetActive(false);
            playPause_button.transform.Find("pause_image").gameObject.SetActive(true);
        }
    }

    private void Play()
    {
        GlobalAudioSource.volume = globalAudioMinVolume;
        localAudioSource.Play();
        playPause_button.transform.Find("play_image").gameObject.SetActive(false);
        playPause_button.transform.Find("pause_image").gameObject.SetActive(true);
    }

    private void Pause()
    {
        GlobalAudioSource.volume = globalAudioMaxVolume;
        localAudioSource.Pause();
        playPause_button.transform.Find("play_image").gameObject.SetActive(true);
        playPause_button.transform.Find("pause_image").gameObject.SetActive(false);
    }

    private void LoadWork()
    {
        SetCreatorName();
        SetAudioClip();
        Pause();
    }
    
    private void SetProjectInfo()
    {
        GameObject projectInfo_text = gameObject.transform.Find("UI").Find("UI_interface").Find("projectInfo_text").gameObject;
        projectInfo_text.GetComponent<TextMeshProUGUI>().SetText("Project Info: " + projectInfo);
    }

    private void SetCreatorName()
    {
        GameObject createdBy_text = transform.Find("UI").Find("UI_interface").Find("createdBy_text").gameObject;
        createdBy_text.GetComponent<TextMeshProUGUI>().SetText("Created by: " + Names[index]);
    }

    private void SetAudioClip()
    {
        localAudioSource.clip = Audios[index];
    }
    
    private void initiateCameraInUI()  // take scene camera and put it into UI Canvas to allow interaction
    {
        GameObject UI_interface = gameObject.transform.Find("UI").Find("UI_interface").gameObject;
        UI_interface.GetComponent<Canvas>().worldCamera = SceneCamera;
    }
}
