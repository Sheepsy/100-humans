using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitCreatures : MonoBehaviour
{
    public GameObject follower;
    public GameObject explorer;
    public Transform spawnZoneTransform;

    // Start is called before the first frame update
    void Start()
    {
        CreaturesManager.nbBeginningLevel = CreaturesManager.nbFollowers + CreaturesManager.nbExplorers;
        CreaturesManager.nbLeftLevel = CreaturesManager.nbBeginningLevel;
        CreaturesManager.nbDeadLevel = 0;
        CreaturesManager.nbSavedLevel = 0;
        CreaturesManager.isLevelStarted = false;

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
        int halfTrust = CreaturesManager.nbFollowers / 2;
        int halfUntrust = CreaturesManager.nbExplorers / 2;

        for (int i = 0; i < halfTrust; i++)
        {
            Instantiate(follower, new Vector3(xLeft, yFollower + 0.5f * i, 0), Quaternion.identity);
        }
        if (CreaturesManager.nbFollowers % 2 == 1)
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
        if (CreaturesManager.nbExplorers % 2 == 1)
        {
            halfUntrust++;
        }
        for (int i = 0; i < halfUntrust; i++)
        {
            Instantiate(explorer, new Vector3(xLeft, yExplorer - 0.5f * i, 0), Quaternion.identity);
        }
    }
}
