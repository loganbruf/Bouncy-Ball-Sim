using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;




public class Ball : MonoBehaviour
{
    public float speed;
    public float speedRangeModifier;
    public float musicPlayTime;
    public List<Color> colors;
    
    public GameObject trail;
    private AudioSource _audio;
    private int _currColorIndex;
    private Rigidbody2D _rb;
    private SpriteRenderer _sprite;
    private float _timer;


    // Start is called before the first frame update
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _sprite = gameObject.GetComponent<SpriteRenderer>();
        _audio = gameObject.GetComponent<AudioSource>();

    }

    void Update()
    {
        trail.transform.localScale = gameObject.transform.localScale;
        trail.GetComponent<SpriteRenderer>().color = colors[_currColorIndex];
        Instantiate(trail, gameObject.transform.position, gameObject.transform.rotation);

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        float realSpeed = UnityEngine.Random.Range(speed - speedRangeModifier, speed + speedRangeModifier);
        float vecX, vecY;
        vecX = transform.position.x >= 0 ? -1 : 1;
        vecY = transform.position.y >= 0 ? -1 : 1;
        _rb.AddForce(new Vector2(vecX, vecY) * realSpeed);
        ChangeColor();
        _timer += musicPlayTime;
        gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, 0) * 1.005f; //Ball get bigger.
        _audio.Play();
    }

    void ChangeColor()
    {
        _currColorIndex = _currColorIndex + 1 >= colors.Count ? 0 : _currColorIndex + 1;
        _sprite.color = colors[_currColorIndex];
    }

}