using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlHumans : MonoBehaviour
{
    public Transform endZoneTransform;
    private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float explorerDetectionRange;
    [SerializeField] private bool explorer = true;
    [SerializeField] private float derivationFactor = 0.5f;
    private Vector2 direction;
    private bool wasSafe = false; // handles the change of derivation angle on two consecutive updates

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (explorer)
        {
            ManageExplorer();
        }
        else
        {
            ManageFollower();
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);
    }

    private void ManageExplorer()
    {
        bool obstacleDetected = false;
        bool endDetected = false;

        // Checking every beacon and obstacle in the detection range of the and compute the mean vector going away from every one of them
        Collider2D[] collidersAround = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), explorerDetectionRange);
        foreach (Collider2D collider in collidersAround)
        {
            if (collider.tag == "Beacon" || collider.tag == "Obstacle")
            {
                if (!obstacleDetected)
                {
                    wasSafe = false;
                    obstacleDetected = true;
                    direction = transform.position - collider.transform.position;
                }
                else
                {
                    Vector2 temp = transform.position - collider.transform.position;
                    direction += temp;
                }
            }
            else if (collider.tag == "EndZone")
            {
                endDetected = true;
            }
        }

        // If no beacon or obstacle has been detected, then the explorer will head to the end zone
        // If the end zone is not in detection range, then there will be a random derivation angle
        if (!obstacleDetected && !wasSafe)
        {
            direction = endZoneTransform.position - transform.position;

            if (!endDetected)
            {
                direction.Normalize();
                Vector2 derivation = new Vector2(Random.Range(-derivationFactor, derivationFactor), Random.Range(-derivationFactor, derivationFactor));
                direction += derivation;
            }
            wasSafe = true;
        }

        direction.Normalize();
    }

    private void ManageFollower()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction = mousePosition - transform.position;
            direction.Normalize();
        }
    }

    public bool IsExplorer()
    {
        return explorer;
    }

    public bool IsFollower()
    {
        return !explorer;
    }

    public Vector2 GetDirection()
    {
        return direction;
    }
}
