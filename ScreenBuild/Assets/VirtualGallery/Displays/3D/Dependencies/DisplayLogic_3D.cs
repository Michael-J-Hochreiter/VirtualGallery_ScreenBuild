using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class DisplayLogic_3D : MonoBehaviour
{
    private const int numWorks = 3;     // total number of works in 3D-display
    private int index = 0;      // indicates which of the works is currently displayed

    // public variables to be filled in inside unity inspector
    [TextArea(5,10)] public String projectInfo;     // information/description of project
    public String[] Names = new String[numWorks];      // names of students
    public Texture2D[] renderImages1 = new Texture2D[numWorks];     // references to render images
    public Texture2D[] renderImages2 = new Texture2D[numWorks];     // references to render images
    public Material shadedMaterial;
    public Material wireframeMaterial;
    public Camera SceneCamera;     // main scene camera used for UI worldspace interaction

    private GameObject UI_interface;
    private GameObject UI_images;
    private GameObject UI_projectInfo;
    private GameObject createdBy_text;
    private GameObject projectInfo_text;
    private UnityEngine.UI.Image image1 = null;
    private UnityEngine.UI.Image image2 = null;

    private GameObject works_models;

    void Start()
    {
        // initialize GameObjects for setting text and images

        UI_interface = transform.Find("UI").Find("UI_interface").gameObject;
        UI_images = transform.Find("UI").Find("UI_images").gameObject;
        UI_projectInfo = transform.Find("UI").Find("UI_projectInfo").gameObject;
        
        createdBy_text = UI_interface.transform.Find("createdBy_text").gameObject;
        projectInfo_text = UI_projectInfo.transform.Find("projectInfo_text").gameObject;
        image1 =  UI_images.transform.Find("render1_image").GetComponent<Image>();
        image2 = UI_images.transform.Find("render2_image").GetComponent<Image>();

        works_models = transform.Find("works_models").gameObject;
        
        SetProjectInfo();   // load project description
        LoadWork();    // load first work
        InitiateMatierals(); 
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

    private void LoadWork()
    {
        SetCreatorName();
        SetRenderImages();
        SetModel();
    }

    private void SetCreatorName()
    {
        createdBy_text.GetComponent<TextMeshProUGUI>().SetText("CREATED BY:\n" + Names[index]);
    }

    private void SetProjectInfo()
    {
        projectInfo_text.GetComponent<TextMeshProUGUI>().SetText("PROJECT INFO: " + projectInfo);
    }

    private void SetRenderImages()
    {
        image1.sprite = Sprite.Create(
            renderImages1[index],
            new Rect(0.0f, 0.0f, renderImages1[index].width, renderImages1[index].height), 
            new Vector2(0.5f, 0.5f),
            100.0f
            );      // creates sprite from 2D texture reference and sets sprite as image-sprite in UI
        
        image2.sprite = Sprite.Create(
            renderImages2[index],
            new Rect(0.0f, 0.0f, renderImages2[index].width, renderImages2[index].height), 
            new Vector2(0.5f, 0.5f),
            100.0f
            );
    }

    private void SetModel()
    {
        for (int i = 0; i < numWorks; i++)
        {
            GameObject model = works_models.transform.GetChild(i).gameObject;
            
            if (i == index)
            {
                model.SetActive(true);
            }
            else
            {
                model.SetActive(false);
            }
        }
    }
    
    public void ShadeWireframe()
    {

        for (int i = 0; i < Names.Length; i++)
        {
            works_models.transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().sharedMaterial = wireframeMaterial;
            works_models.transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().material = wireframeMaterial;
        }
    }
    

    public void ShadeSolid()
    {

        for (int i = 0; i < Names.Length; i++)
        {
            works_models.transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().sharedMaterial = shadedMaterial;
            works_models.transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().material = shadedMaterial;
        }
    }

    private void InitiateMatierals() // set materials for all works
    {
        for (int i = 0; i < Names.Length; i++)
        {
            works_models.transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().sharedMaterial = shadedMaterial;
        }
    }

    private void initiateCameraInUI()  // take scene camera and put it into UI Canvases to allow interaction
    {
        UI_interface.GetComponent<Canvas>().worldCamera = SceneCamera;
        UI_images.GetComponent<Canvas>().worldCamera = SceneCamera;
        UI_projectInfo.GetComponent<Canvas>().worldCamera = SceneCamera;
    }
}
