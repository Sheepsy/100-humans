using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowersTraps : MonoBehaviour
{
    [SerializeField] private float minTimeBetweenTraps;
    [SerializeField] private float maxTimeBetweenTraps;
    [SerializeField] private float secondsBeforeTrap;
    [SerializeField] private float trapLifeSpan;
    private bool trapsLaunched;
    private bool followersOnStage;

    // Start is called before the first frame update
    void Start()
    {
        trapsLaunched = false;
        followersOnStage = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!trapsLaunched && CreaturesManager.isLevelStarted)
        {
            trapsLaunched = true;
        }
    }

    private void LaunchTrap()
    {
        if (followersOnStage)
        {
            Vector2 avgFuturePos = GetAverageFollowerPosition(secondsBeforeTrap);

            Invoke("LaunchTrap", Random.Range(minTimeBetweenTraps, maxTimeBetweenTraps));
        }
    }

    private Vector2 GetAverageFollowerPosition(float seconds = 0)
    {
        Vector2 avgPos = Vector2.zero;

        GameObject[] creatures = GameObject.FindGameObjectsWithTag("Creature");
        int nbFollowers = 0;
        foreach (GameObject creature in creatures)
        {
            ControlCreatures ccreature = creature.GetComponent<ControlCreatures>();
            if (ccreature.IsFollower())
            {
                nbFollowers++;

                Vector2 pos = ccreature.transform.position;
                float speed = ccreature.GetSpeed();
                Vector2 dir = ccreature.GetDirection();

                Vector2 futurePos = new Vector2(pos.x + dir.x * speed * seconds, pos.y + dir.y * speed * seconds);
                avgPos += futurePos;
            }
        }

        if (nbFollowers > 0)
        {
            avgPos /= nbFollowers;
        }
        else
        {
            followersOnStage = false;
        }

        return avgPos;
    }
}
