using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Labyrinth : MonoBehaviour
{
    [SerializeField] Transform pos;
    [SerializeField] Transform endPos;
    [SerializeField] float speed = 0.01f;

    private float _endPos;

    // Start is called before the first frame update
    void Start()
    {
        _endPos = endPos.position.y - pos.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (pos.position.y > -_endPos) {
            pos.position -= new Vector3(0, speed, 0);
        }
    }
}
