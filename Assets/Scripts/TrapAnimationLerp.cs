using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapAnimationLerp : MonoBehaviour
{
    private SpriteRenderer sprite;
    private float fadingTime;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        sprite.color = new Color(1f, 0f, 0f, Mathf.PingPong(Time.time, 1));
    }
}
