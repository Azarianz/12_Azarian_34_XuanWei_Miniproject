using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteLook : MonoBehaviour
{
    public Transform camPivot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Camera-relative movement
        Vector3 camF = (camPivot.forward).normalized;
        Vector3 camR = (camPivot.right).normalized;
        camF.y = 0;
        camR.y = 0;

        //Make the player always face the camera
        transform.rotation = Quaternion.LookRotation(camF);
    }
}
