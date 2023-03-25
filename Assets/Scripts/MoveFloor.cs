using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFloor : MonoBehaviour
{
    private SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();

        width = new Vector2(sr.size.x, sr.size.y);
    }

    [SerializeField] private float speed;

    private Vector2 width;

    void Update()
    {
        width += Vector2.right * Time.deltaTime * speed * 2f;

        sr.size = width;
    }
}
