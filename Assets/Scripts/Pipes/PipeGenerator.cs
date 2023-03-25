using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGenerator : MonoBehaviour
{
    [SerializeField] private Transform pipePrefab;

    [SerializeField, Range(0,10)] private float minTime, maxTime;

    float currentMaxTime;
    float timePassed = 0f;

    private void Awake()
    {
        currentMaxTime = Random.Range(minTime, maxTime);
    }

    private void Update()
    {
        timePassed += Time.deltaTime;

        if (timePassed >= currentMaxTime)
        {
            timePassed = 0f;
            currentMaxTime = Random.Range(minTime,maxTime);

            Instantiate(pipePrefab, transform);
        }
    }
}
