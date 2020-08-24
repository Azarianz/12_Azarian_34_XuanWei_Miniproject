using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public Animator doorAnim;
    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        rend.material.color = Color.green;
        doorAnim.SetBool("isOpen", true);
        doorAnim.SetBool("isClosed", false);
    }

    private void OnTriggerExit(Collider other)
    {
        rend.material.color = Color.red;
        doorAnim.SetBool("isOpen", false);
        doorAnim.SetBool("isClosed", true);
    }
}
