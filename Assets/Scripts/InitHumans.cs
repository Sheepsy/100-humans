using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitHumans : MonoBehaviour
{
    public GameObject follower;
    public GameObject explorer;
    public Transform spawnZoneTransform;

    // Start is called before the first frame update
    void Start()
    {
        HumansManager.nbBeginningLevel = HumansManager.nbTrust + HumansManager.nbUntrust;
        HumansManager.nbLeftLevel = HumansManager.nbBeginningLevel;
        HumansManager.nbDeadLevel = 0;
        HumansManager.nbSavedLevel = 0;
        HumansManager.isLevelStarted = false;

        SpawnCreatures();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnCreatures()
    {
        float yFollower = spawnZoneTransform.position.y - spawnZoneTransform.localScale.y / 2 + 0.5f;
        float yExplorer = spawnZoneTransform.position.y + spawnZoneTransform.localScale.y / 2 - 0.5f;
        float xLeft = spawnZoneTransform.position.x - spawnZoneTransform.localScale.x / 6f;
        float xRight = spawnZoneTransform.position.x + spawnZoneTransform.localScale.x / 6f;
        int halfTrust = HumansManager.nbTrust / 2;
        int halfUntrust = HumansManager.nbUntrust / 2;

        for (int i = 0; i < halfTrust; i++)
        {
            Instantiate(follower, new Vector3(xLeft, yFollower + 0.5f * i, 0), Quaternion.identity);
        }
        if (halfTrust % 2 == 1)
        {
            halfTrust++;
        }
        for (int i = 0; i < halfTrust; i++)
        {
            Instantiate(follower, new Vector3(xRight, yFollower + 0.5f * i, 0), Quaternion.identity);
        }

        for (int i = 0; i < halfUntrust; i++)
        {
            Instantiate(explorer, new Vector3(xRight, yExplorer - 0.5f * i, 0), Quaternion.identity);
        }
        if (halfUntrust % 2 == 1)
        {
            halfUntrust++;
        }
        for (int i = 0; i < halfUntrust; i++)
        {
            Instantiate(explorer, new Vector3(xLeft, yExplorer - 0.5f * i, 0), Quaternion.identity);
        }
    }
}
