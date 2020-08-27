using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingTexture : MonoBehaviour
{
    public float ScrollX = 0.5f;
    public float ScrollY = 0.5f;
    public Renderer rend;

    // Start is called before the first frame update`
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float offsetX = Time.time * ScrollX;
        float offsetY = Time.time* ScrollY;

        rend.material.SetTextureOffset("_MainTex", new Vector2(offsetX, offsetY));
    }


}
