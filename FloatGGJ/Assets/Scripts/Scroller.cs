using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    public Renderer bgRender;
    public float speed;
    public bool setY;

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = (setY) ? new Vector2(0, speed * Time.deltaTime) : new Vector2(speed * Time.deltaTime, 0);
        bgRender.material.mainTextureOffset += offset;
    }
}
