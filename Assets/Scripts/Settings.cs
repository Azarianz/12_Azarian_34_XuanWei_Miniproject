using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Settings : MonoBehaviour
{
    //Audio Mix
    public AudioMixer MasterChannel;

    //Settings Menu
    public TMP_Dropdown fullscreenDropdown;
    public TMP_Dropdown resolutionDropdown;
    public TMP_Dropdown graphicsDropdown;
    Resolution[] resolutions;

    // Start is called before the first frame update
    void Start()
    {
        //Display Resolutions
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionindex = 0;        

        //Auto Select Resolution Settings
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionindex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionindex;
        resolutionDropdown.RefreshShownValue();

        //Auto Select Current Fullscreen Status
        if(Screen.fullScreen == true)
        {
            fullscreenDropdown.value = 0;
        }

        if (Screen.fullScreen == false)
        {
            fullscreenDropdown.value = 1;
        }

        //Auto Select Graphics Quality Status
        int qualityLevel = QualitySettings.GetQualityLevel();
        graphicsDropdown.value = qualityLevel;

    }

    public void SetVolume(float sliderval)
    {
        MasterChannel.SetFloat("volume", sliderval);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(int isFullscreen)
    {
        if (isFullscreen == 0)
        {
            Screen.fullScreen = true;
        }

        if (isFullscreen == 1)
        {
            Screen.fullScreen = false;
        }
    }


    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }


}

