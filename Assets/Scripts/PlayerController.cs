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

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Win")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
