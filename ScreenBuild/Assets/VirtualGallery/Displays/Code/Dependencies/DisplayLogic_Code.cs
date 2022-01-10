using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
  
public class DisplayLogic_Code : MonoBehaviour
{
    private const int numWorks = 2;     // total number of works in 3D-display
    private const int numProjects = 3;      // total number of projects (colletions of works) to be displayed in video-display
    private int indexWorks = 0;      // indicates which of the works is currently displayed
    private int indexProjects = 0;      // indicated which of the projects is currently selected

    
    // public variables to be filled in inside unity inspector

    [Header("--------- FIRST PROJECT ---------")]
    [Space(15)]
    
    public String project0Title;        // title of first project
    [TextArea(5,10)] public String project0Info;     // information/description of first project
    public String[] project0CreatorNames = new String[numWorks];      // names of students
    public VideoClip[] project0Videos = new VideoClip[numWorks];      // video clips of each work
    
    [Space(40)]
    [Header("--------- SECOND PROJECT ---------")]
    [Space(15)]

    public String project1Title;        // title of second project
    [TextArea(5,10)] public String project1Info;     // information/description of second project
    public String[] project1CreatorNames = new String[numWorks];      // names of students
    public VideoClip[] project1Videos = new VideoClip[numWorks];      // video clips of each work
    
    [Space(40)]
    [Header("--------- THIRD PROJECT ---------")]
    [Space(15)]
    
    public String project2Title;    // title of third project
    [TextArea(5,10)] public String project2Info;     // information/description of third project
    public String[] project2CreatorNames = new String[numWorks];      // names of students
    public VideoClip[] project2Videos = new VideoClip[numWorks];      // video clips of each work
    
    public Camera SceneCamera;      // main scene camera used for UI worldspace interaction
    
    private GameObject UI_interface;
    private GameObject videoPlayer;
    private AudioSource audioSource;
    private GameObject playPause_button;
    


    void Start()
    {
        UI_interface = gameObject.transform.Find("UI").Find("UI_interface").gameObject;
        videoPlayer = gameObject.transform.Find("videoPlayer").gameObject;
        audioSource = gameObject.transform.Find("audioSource").gameObject.GetComponent<AudioSource>();
        playPause_button = gameObject.transform.Find("UI").Find("UI_interface").Find("playPause_button").gameObject;
        
        initiateCameraInUI();
        SetProjectTitles();
        LoadProject(0);
        SetAudioSource();
        
        videoPlayer.GetComponent<VideoPlayer>().targetTexture.Release();
        
        Pause();
    }
    
    public void LoadProject(int index)   // loads the project with index given by parameter
    {
        indexProjects = index;
        
        SetProjectButtonColors(index);
        SetProjectInfo();
        LoadWork();
        Pause();
    }

    public void NextWork()  // call LoadWork() with increased index -> cycle through works inside project
    {
        indexWorks = (indexWorks + 1) % numWorks;   // cycle through index forwards
        
        LoadWork();
    }

    public void PrevWork() // call LoadWork() with decreased index -> cycle through works inside project
    {
        indexWorks -= 1;
        if (indexWorks < 0) // cycle through index backwards
        {
            indexWorks = numWorks - 1;
        }

        LoadWork();
    }

    public void PlayPause()
    {
        if (videoPlayer.GetComponent<VideoPlayer>().isPlaying)
        {
            
            videoPlayer.GetComponent<VideoPlayer>().Pause();
            playPause_button.transform.Find("play_image").gameObject.SetActive(true);
            playPause_button.transform.Find("pause_image").gameObject.SetActive(false);
        }
        else
        {
            videoPlayer.GetComponent<VideoPlayer>().Prepare();
            videoPlayer.GetComponent<VideoPlayer>().Play();
            playPause_button.transform.Find("play_image").gameObject.SetActive(false);
            playPause_button.transform.Find("pause_image").gameObject.SetActive(true);
            
        }
    }

    private void Play()
    {
        videoPlayer.GetComponent<VideoPlayer>().Prepare();
        videoPlayer.GetComponent<VideoPlayer>().Play();
        playPause_button.transform.Find("play_image").gameObject.SetActive(false);
        playPause_button.transform.Find("pause_image").gameObject.SetActive(true);
        
    }
    
    private void Pause()
    {
        videoPlayer.GetComponent<VideoPlayer>().Pause();
        playPause_button.transform.Find("play_image").gameObject.SetActive(true);
        playPause_button.transform.Find("pause_image").gameObject.SetActive(false);
    }

    
    private void LoadWork()
    {
        SetCreatorName();
        SetVideoClip();
        videoPlayer.GetComponent<VideoPlayer>().targetTexture.Release();
        Play();
    }

    private void SetCreatorName()
    {
        GameObject createdBy_text = transform.Find("UI").Find("UI_interface").Find("createdBy_text").gameObject;
        
        switch (indexProjects)
        {
            case 0:
                createdBy_text.GetComponent<TextMeshProUGUI>().SetText("CREATED BY: " + project0CreatorNames[indexWorks]);
                break;
            case 1:
                createdBy_text.GetComponent<TextMeshProUGUI>().SetText("CREATED BY: " + project1CreatorNames[indexWorks]);
                break;
            case 2:
                createdBy_text.GetComponent<TextMeshProUGUI>().SetText("CREATED BY: " + project2CreatorNames[indexWorks]);
                break;
        }
    }

    private void SetProjectInfo()
    {
        GameObject projectInfo_text = gameObject.transform.Find("UI").Find("UI_interface").Find("projectInfo_text").gameObject;
        
        switch (indexProjects)
        {
            case 0:
                projectInfo_text.GetComponent<TextMeshProUGUI>().SetText("PROJECT INFO: " + project0Info);
                break;
            case 1:
                projectInfo_text.GetComponent<TextMeshProUGUI>().SetText("PROJECT INFO: " + project1Info);
                break;
            case 2:
                projectInfo_text.GetComponent<TextMeshProUGUI>().SetText("PROJECT INFO: " + project2Info);
                break;
        }
        
    }

    private void SetProjectTitles()
    {
        UI_interface.transform.Find("project0_button").GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().SetText(project0Title);
        UI_interface.transform.Find("project1_button").GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().SetText(project1Title);
        UI_interface.transform.Find("project2_button").GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().SetText(project2Title);
    }

    private void SetVideoClip()
    {
        videoPlayer.GetComponent<VideoPlayer>().clip = project0Videos[indexWorks];
            
        switch (indexProjects)
        {
            case 0:
                videoPlayer.GetComponent<VideoPlayer>().clip = project0Videos[indexWorks];
                break;
            case 1:
                videoPlayer.GetComponent<VideoPlayer>().clip = project1Videos[indexWorks];
                break;
            case 2:
                videoPlayer.GetComponent<VideoPlayer>().clip = project2Videos[indexWorks];
                break;
        }

        Pause();
        setVideoThumbnail();
    }

    private void SetProjectButtonColors(int index)
    {
        UI_interface.transform.Find("project0_button").gameObject.GetComponent<Image>().color = Color.grey;
        UI_interface.transform.Find("project1_button").gameObject.GetComponent<Image>().color = Color.grey;
        UI_interface.transform.Find("project2_button").gameObject.GetComponent<Image>().color = Color.grey;
        
        switch (index)      // change color of buttons in UI so signal selected project
        {
            case 0:
                UI_interface.transform.Find("project0_button").gameObject.GetComponent<Image>().color = Color.green;
                break;
            case 1:
                UI_interface.transform.Find("project1_button").gameObject.GetComponent<Image>().color = Color.green;
                break;
            case 2:
                UI_interface.transform.Find("project2_button").gameObject.GetComponent<Image>().color = Color.green;
                break;
        }
    }
    
    private void initiateCameraInUI()  // take scene camera and put it into UI Canvas to allow interaction
    {
        UI_interface.GetComponent<Canvas>().worldCamera = SceneCamera;
    }

    private void setVideoThumbnail()        // grab texture of first frame from current video and then set it to the color of the thumbnail material
    {
        /*
        videoWallThumbnail_model.SetActive(true);
        videoPlayer.GetComponent<VideoPlayer>().time = 0;
        videoPlayer.GetComponent<VideoPlayer>().Play();
        Texture thumbnail = videoPlayer.GetComponent<VideoPlayer>().texture;
        
        //videoWallThumbnail_model.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", thumbnail);
        //videoWallThumbnail_model.GetComponent<MeshRenderer>().material.SetTexture("_EmissionMap", thumbnail);
        //videoWallThumbnail_model.GetComponent<MeshRenderer>().sharedMaterial.SetColor("_MainTex", Color.red);
        videoWallThumbnail_model.GetComponent<MeshRenderer>().material.EnableKeyword("_MAINTEX");
        videoWallThumbnail_model.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", bruh);
        
        videoPlayer.GetComponent<VideoPlayer>().Pause();
        */
        
        // doesnt work lmfao
    }

    private void SetAudioSource()
    {
        videoPlayer.GetComponent<VideoPlayer>().SetTargetAudioSource(0, audioSource);
    }
}
