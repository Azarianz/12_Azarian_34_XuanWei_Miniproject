using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseUI;

    // Start is called before the first frame update
    void Start()
    {
        pauseUI.SetActive(false);

        StartCoroutine(ScaleTime(1.0f, 1.0f, 1.0f));
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            PauseGame();
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

    void PauseGame()
    {
        pauseUI.SetActive(true);
        StartCoroutine(ScaleTime(0.0f, 0.0f, 0.0f));
        Cursor.visible = true;
    }

    public void Resume()
    {
        pauseUI.SetActive(false);
        StartCoroutine(ScaleTime(1.0f, 1.0f, 1.0f));
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
