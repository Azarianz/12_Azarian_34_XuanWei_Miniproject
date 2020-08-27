using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaySpawner : MonoBehaviour
{
    public GameObject rayPrefab;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnRay", 1f, 0.6f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnRay()
    {
        Instantiate(rayPrefab, transform.position, transform.rotation, transform.parent);
    }
}
