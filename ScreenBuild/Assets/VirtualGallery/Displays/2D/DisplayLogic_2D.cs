using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayLogic_2D : MonoBehaviour
{
    private const int numWorks = 5;
    
    [TextArea(5,10)] public String projectInfo;     // information/description of project
    public String[] Names = new String[numWorks];      // names of students
    public Texture2D[] Images = new Texture2D[numWorks];     // references to render images
    public Camera SceneCamera;      // main scene camera used for UI worldspace interaction
    
    void Start()
    {
        SetProjectInfo();
        SetCreatorNames();
        SetImages();
        initiateCameraInUI();
    }

    private void SetProjectInfo()
    {
        GameObject projectInfo_text = gameObject.transform.Find("UI").Find("UI_interface").Find("projectInfo_text").gameObject;
        projectInfo_text.GetComponent<TextMeshProUGUI>().SetText("Project Info: " + projectInfo);
    }

    private void SetCreatorNames()
    {
        GameObject UI = gameObject.transform.Find("UI").gameObject;
        
        for (int i = 0; i < numWorks; i++)
        {
            GameObject createdBy_text = UI.transform.Find("UI_image" + (i + 1)).Find("createdBy_text").gameObject;
            
            createdBy_text.GetComponent<TextMeshProUGUI>().SetText("Created by: " + Names[i]);
        }
    }

    private void SetImages()
    {
        GameObject UI = gameObject.transform.Find("UI").gameObject;
        
        for (int i = 0; i < numWorks; i++)
        {
            GameObject work_image = UI.transform.Find("UI_image" + (i + 1)).Find("work" + (i + 1) + "_image").gameObject;
            
            work_image.GetComponent<Image>().sprite = Sprite.Create(
                Images[i],
                new Rect(0.0f, 0.0f, Images[i].width, Images[i].height), 
                new Vector2(0.5f, 0.5f),
                100.0f
            );  
        }
    }
    
    private void initiateCameraInUI()  // take scene camera and put it into UI Canvas to allow interaction
    {
        GameObject UI_interface = gameObject.transform.Find("UI").Find("UI_interface").gameObject;
        UI_interface.GetComponent<Canvas>().worldCamera = SceneCamera;
    }
}
