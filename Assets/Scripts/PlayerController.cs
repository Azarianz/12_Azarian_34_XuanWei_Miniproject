using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Transform camPivot;
    public float movementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Camera-relative movement
        Vector3 inputMovement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        Vector3 camF = (camPivot.forward).normalized;
        Vector3 camR = (camPivot.right).normalized;
        camF.y = 0;
        camR.y = 0;

        transform.position += (camF * inputMovement.z + camR * inputMovement.x) * movementSpeed * Time.deltaTime;

        //Make the player always face the camera
        transform.rotation = Quaternion.LookRotation(camF);


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

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Win")
        {
            if(SceneManager.GetActiveScene().buildIndex != SceneManager.sceneCountInBuildSettings)
            {
                if (SceneManager.GetActiveScene().buildIndex + 1 == SceneManager.sceneCountInBuildSettings)
                {
                    WinLoseHUD.instance.Win();
                }
                else
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
            }        
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Hazard")
        {
            //Lose
            WinLoseHUD.instance.Lose();
            Destroy(gameObject);    //Destroy Player
        }

    }


}
