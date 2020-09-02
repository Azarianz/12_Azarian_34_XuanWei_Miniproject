using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLoseHUD : MonoBehaviour
{
    public static WinLoseHUD instance;

    public GameObject winHUD;
    public GameObject loseHUD;
    public GameObject pauseHUD;

    // Start is called before the first frame update
    void Start()
    {
        winHUD.SetActive(false);
        loseHUD.SetActive(false);
        pauseHUD.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(instance == null)
        {
            instance = this;
        }

        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator ScaleTime(float start, float end, float time)
    {
        float lastTime = Time.realtimeSinceStartup;
        float timer = 0.0f;

        while (timer < time)
        {
            Time.timeScale = Mathf.Lerp(start, end, timer / time);
            timer += (Time.realtimeSinceStartup - lastTime);
            lastTime = Time.realtimeSinceStartup;
            yield return null;
        }

        Time.timeScale = end;

    }
    public void Lose()
    {
        loseHUD.SetActive(true);
        pauseHUD.SetActive(false);
        
    }

    public void Win()
    {
        winHUD.SetActive(true);
        pauseHUD.SetActive(false);
        
    }
}
