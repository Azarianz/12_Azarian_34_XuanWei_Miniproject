using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    private LineRenderer lr;

    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            lr.SetPosition(1, new Vector3(0, 0, hit.distance));

            if(hit.collider.tag == "Player")
            {
                //Lose
                WinLoseHUD.instance.Lose();
                Destroy(hit.collider.gameObject);   //Destroy Player
            }
        }

        else
        {
            lr.SetPosition(1, new Vector3(0, 0, 150));
        }
    }
}
