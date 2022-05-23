using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Labyrinth : MonoBehaviour
{
    [SerializeField] Transform pos;
    [SerializeField] float speed = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pos.position.y > -10.0f) {
            pos.position -= new Vector3(0, speed, 0);
        }
    }
}
