﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayTransport : MonoBehaviour
{
    public float transport_speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag != "Wall")
        {
            other.gameObject.GetComponent<Rigidbody>().useGravity = false;
            other.gameObject.transform.position += transform.forward * transport_speed * Time.deltaTime;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        other.gameObject.GetComponent<Rigidbody>().useGravity = true;
    }
}
