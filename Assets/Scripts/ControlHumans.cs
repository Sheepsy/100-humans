using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlHumans : MonoBehaviour
{
    public Transform spawnZoneTransform;
    public Transform endZoneTransform;
    private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float explorerDetectionRange;
    [SerializeField] private bool explorer = true;
    [SerializeField] private float derivationFactor = 0.5f;
    public Vector2 direction;
    private Vector2 explorerDerivation;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = Vector2.zero;
        if (explorer)
        {
            InvokeRepeating("RandomDerivation", 0, Random.Range(0.5f, 2f));
        }
    }

    // Updates the direction vector depending on the creature behavior
    void Update()
    {
        if (HumansManager.isLevelStarted)
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
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                HumansManager.isLevelStarted = true;
            }
        }
    }

    // Updates the velocity of the creature
    void FixedUpdate()
    {
        rb.velocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);
    }

    private void RandomDerivation()
    {
        explorerDerivation = new Vector2(0, Random.Range(-derivationFactor, derivationFactor));
        explorerDerivation.Normalize();
    }

    private void ManageExplorer()
    {
        bool obstacleDetected = false;
        bool endDetected = false;

        direction = Vector2.right;

        // Checking every beacon and obstacle in the detection range of the and compute the mean vector going away from every one of them
        Collider2D[] collidersAround = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), explorerDetectionRange);
        foreach (Collider2D collider in collidersAround)
        {
            if (collider.tag == "Beacon")
            {
                obstacleDetected = true;
                Vector2 flee = transform.position - collider.transform.position;
                flee.Normalize();
                direction += flee;
            }
            else if (collider.tag == "Obstacle")
            {
                obstacleDetected = true;
                Vector2 flee = (Vector2)transform.position - collider.ClosestPoint(transform.position);
                flee.Normalize();
                direction += flee;
            }
            else if (collider.tag == "EndZone")
            {
                endDetected = true;
            }
        }

        // If no beacon or obstacle has been detected, then the explorer will head to the end zone
        // If the end zone is not in detection range, then there will be a random derivation angle
        if (!obstacleDetected && !endDetected)
        {
            direction += explorerDerivation;
        }

        direction.Normalize();
    }

    private void ManageFollower()
    {
        if (direction == Vector2.zero)
        {
            direction = Vector2.right / 10;
        }
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction = mousePosition - transform.position;
            direction.Normalize();
        }
    }

    private void OnMouseDrag()
    {
        if (!HumansManager.isLevelStarted)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;

            float leftBorder = spawnZoneTransform.position.x - spawnZoneTransform.localScale.x / 2;
            float rightBorder = spawnZoneTransform.position.x + spawnZoneTransform.localScale.x / 2;
            float downBorder = spawnZoneTransform.position.y - spawnZoneTransform.localScale.y / 2;
            float upBorder = spawnZoneTransform.position.y + spawnZoneTransform.localScale.y / 2;
            
            if (pos.x < leftBorder)
            {
                pos.x = leftBorder;
            }
            else if (pos.x > rightBorder)
            {
                pos.x = rightBorder;
            }
            if (pos.y < downBorder)
            {
                pos.y = downBorder;
            }
            else if (pos.y > upBorder)
            {
                pos.y = upBorder;
            }

            transform.position = pos;
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
