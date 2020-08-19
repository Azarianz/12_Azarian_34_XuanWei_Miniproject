using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public int clicks;

    public Text displayLevel;

    public GameObject settingsUI;
    public GameObject lvlSelectUI;
    public GameObject mainUI;
      
    // Start is called before the first frame update
    void Start()
    {
        settingsUI.SetActive(false);
        lvlSelectUI.SetActive(false);
        mainUI.SetActive(true);

        clicks = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(clicks == 1)
        {
            displayLevel.text = "L e v e l  1";
        }

        if (clicks == 2)
        {
            displayLevel.text = "L e v e l  2";
        }

        if (clicks == 3)
        {
            displayLevel.text = "L e v e l  3";
        }

        if (clicks < 1)
        {
            clicks = 1;
        }

        if (clicks > 3)
        {
            clicks = 3;
        }
    }

    public void Play()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void Settings()
    {
        mainUI.SetActive(false);
        settingsUI.SetActive(true);
    }

    public void LvlSelect()
    {
        mainUI.SetActive(false);
        lvlSelectUI.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Back()
    {
        mainUI.SetActive(true);
        settingsUI.SetActive(false);
        lvlSelectUI.SetActive(false);
    }

    public void ArrowNext()
    {
        clicks += 1;
    }

    public void ArrowBack()
    {
        clicks -= 1;
    }

    public void LvlSelectPlay()
    {
        if(clicks == 1)
        {
            SceneManager.LoadScene("Level 1");
        }

        if (clicks == 2)
        {
            SceneManager.LoadScene("Level 2");
        }

        if (clicks == 3)
        {
            SceneManager.LoadScene("Level 3");
        }
    }
}
