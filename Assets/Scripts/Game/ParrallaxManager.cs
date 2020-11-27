using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script to allow clouds to flow along background giving parrallax effect
public class ParrallaxManager : MonoBehaviour
{
    private float length;
    private float startPos;
    public GameObject cam;
    public float parrallaxEffect;

    // declare start position and length of Y axis to bound across
    void Start()
    {
        startPos = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.y;
        
    }

    // calculate distance to apply parrallax effect 
    // transform the position of object along Y axis
    void FixedUpdate()
    {
        float temp =(cam.transform.position.y * (1 - parrallaxEffect));
        float dist = (cam.transform.position.y * parrallaxEffect);

        transform.position = new Vector3(transform.position.x, startPos + dist, transform.position.z);

        if (temp > startPos + length)
        {
            startPos += length;
        }
        else if (temp < startPos - length)
        {
            startPos -= length;
        }
    }
}
