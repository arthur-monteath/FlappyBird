using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipePrefab : MonoBehaviour
{
    [SerializeField] private float speed;

    public void SetSpeed(float value)
    {
        speed = value;
    }

    [SerializeField, Range(0,10)] private float minPipeGap;
    [SerializeField, Range(0,10)] private float maxPipeGap;

    [SerializeField] private float maxHeightOffset;

    private void Awake()
    {
        float pipeGap = Random.Range(minPipeGap, maxPipeGap);

        transform.GetChild(0).position += new Vector3(0f, pipeGap / 2f, 0f);
        transform.GetChild(1).position -= new Vector3(0f, pipeGap / 2f, 0f);

        transform.position += new Vector3(0f, Random.Range(-maxHeightOffset, maxHeightOffset), 0f);

        GetComponent<BoxCollider2D>().size = new Vector2(1, pipeGap);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.GetComponent<Player>() != null)
            Game.Instance.Score(1);
    }

    private void Update()
    {
        transform.position += (Vector3)Vector2.left * speed * Time.deltaTime;
    }
}
