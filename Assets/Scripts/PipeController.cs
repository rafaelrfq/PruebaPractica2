using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    Vector3 deltaPosition = new Vector3();
    float axis = -1;

    // Update is called once per frame
    void Update()
    {
        deltaPosition.x = axis * 5f * Time.deltaTime;
        transform.Translate(deltaPosition);
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
}
