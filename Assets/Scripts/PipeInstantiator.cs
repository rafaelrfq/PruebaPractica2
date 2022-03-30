using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeInstantiator : MonoBehaviour
{
    public GameObject pipePrefab;
    public GameObject flippedPipePrefab;
    Vector3 startingPosition = new Vector3(7.5f, 0);
    float nextTime;
    const float MIN_TIME = 0.5f, MAX_TIME = 1f, MIN_X = 5f, MAX_X = 7f, MIN_Y = -5f, MAX_Y = 5f;
    void Start()
    {
        nextTime = getNextTime();
    }

    void Update()
    {
        if (Time.time > nextTime)
        {
            startingPosition.x += Random.Range(MIN_X, MAX_X);
            startingPosition.y = Random.Range(MIN_Y, MAX_Y);
            Instantiate(getNextPipe(), startingPosition, Quaternion.identity);
            nextTime = getNextTime();
        }
    }

    float getNextTime()
    {
        return Time.time + (Random.Range(MIN_TIME, MAX_TIME));
    }

    GameObject getNextPipe()
    {
        switch(Random.Range(0, 2))
        {
            case 0:
                return pipePrefab;
            case 1:
                return flippedPipePrefab;
            default:
                return pipePrefab;

        }
    }
}
