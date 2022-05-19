using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlHumans : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float maxClickDistance;
    [SerializeField] private bool trust = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Left click
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Distance between humans and mouse must be inferior to maxClickDistance
            if (Vector2.Distance(mousePosition, transform.position) < maxClickDistance)
            {
                // Vecteur se normalise pas bien : il vaut pas 1 mais entre 0 et 1

                Vector2 direction = (mousePosition - transform.position);
                direction.Normalize();
                if (!trust)
                {
                    direction *= -1;
                }
                rb.velocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);
            }
            else
            {
                rb.velocity = Vector2.zero;
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}
