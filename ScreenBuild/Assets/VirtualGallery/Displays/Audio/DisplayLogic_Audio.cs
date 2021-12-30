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
    public AudioSource audioSource;
    
    private GameObject playPause_button;
    
    void Start()
    {
        playPause_button = transform.Find("UI").Find("UI_interface").Find("playPause_button").gameObject;
        playPause_button.transform.Find("play_image").gameObject.SetActive(true);
        playPause_button.transform.Find("pause_image").gameObject.SetActive(false);
        
        SetProjectInfo();
        LoadWork();
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
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
            playPause_button.transform.Find("play_image").gameObject.SetActive(true);
            playPause_button.transform.Find("pause_image").gameObject.SetActive(false);
        }
        else
        {
            audioSource.Play();
            playPause_button.transform.Find("play_image").gameObject.SetActive(false);
            playPause_button.transform.Find("pause_image").gameObject.SetActive(true);
        }
    }

    private void LoadWork()
    {
        SetCreatorName();
        SetAudioClip();
        PlayPause();
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
        audioSource.clip = Audios[index];
        audioSource.Pause();
    }
}
