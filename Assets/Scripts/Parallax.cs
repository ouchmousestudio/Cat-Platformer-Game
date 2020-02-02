using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    float length, startPos;
    public GameObject camera;
    public float parallaxAmount;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float temp = camera.transform.position.x * (1 - parallaxAmount);
        float distance = camera.transform.position.x * parallaxAmount;

        transform.position = new Vector2(startPos + distance, transform.position.y);

        if (temp > startPos + length) startPos += length;
        else if (temp < startPos + length) startPos -= length; 
    }
}
