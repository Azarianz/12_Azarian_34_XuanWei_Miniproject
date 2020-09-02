using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public GameObject level;
    public GameObject player;

    public float camrotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
        if (Input.GetKey(KeyCode.E))
        {
            level.transform.Rotate(0, -camrotationSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            level.transform.Rotate(0, camrotationSpeed * Time.deltaTime, 0);
        }
    }
}
