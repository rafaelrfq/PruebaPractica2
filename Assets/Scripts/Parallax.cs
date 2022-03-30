using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, start_position;
    public float parallax_effect;
    float initialPosition = 0f;

    void Start()
    {
        start_position = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        if (initialPosition > 26f)
            initialPosition = 0;

        float temp = (initialPosition * (1 - parallax_effect));
        float dist = (initialPosition * parallax_effect);

        transform.position = new Vector3(start_position + dist, transform.position.y, transform.position.z);

        if (temp > start_position + length) start_position += length;
        else if (temp < start_position - length) start_position -= length;

        initialPosition += 0.01f;
    }
}
