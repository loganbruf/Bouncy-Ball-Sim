using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Callbacks;
using UnityEngine;




public class Ball : MonoBehaviour
{
    public float speed;
    public float speedRangeModifier;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        float realSpeed = UnityEngine.Random.Range(speed - speedRangeModifier, speed + speedRangeModifier);
        float vecX, vecY;
        vecX = transform.position.x >= 0 ? -1 : 1;
        vecY = transform.position.y >= 0 ? -1 : 1;
        rb.AddForce(new Vector2(vecX, vecY) * realSpeed);
    }

}