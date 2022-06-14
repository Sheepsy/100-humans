using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitHumans : MonoBehaviour
{
    public GameObject trustfulHuman;
    public GameObject untrustfulHuman;
    [SerializeField] Vector2 initPos;

    // Start is called before the first frame update
    void Start()
    {
        HumansManager.nbBeginningLevel = HumansManager.nbTrust + HumansManager.nbUntrust;
        HumansManager.nbLeftLevel = HumansManager.nbBeginningLevel;
        HumansManager.nbDeadLevel = 0;
        HumansManager.nbSavedLevel = 0;

        SpawnHumans();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Properly spawns all the humans
    private void SpawnHumans()
    {
        int nbRows = HumansManager.nbAlive / 10;
        int nbCols = 10;
        if (nbRows == 1)
        {
            nbCols = HumansManager.nbAlive;
        }

        float xStart = initPos.x - 0.5f * nbCols / 2f;
        if (nbCols % 2 == 0)
        {
            xStart += 0.25f;
        }
        float yStart = initPos.y + 0.5f * nbRows / 2f;
        if (nbRows % 2 == 0)
        {
            yStart -= 0.25f;
        }

        int x = 0;
        int y = 0;
        int spawned = 0;
        while (spawned < HumansManager.nbTrust)
        {
            Instantiate(trustfulHuman, new Vector3(xStart + 0.5f * x, yStart - 0.5f * y, 0), Quaternion.identity);
            spawned++;
            x++;
            if (x == 10)
            {
                x = 0;
                y++;
            }
        }
        spawned = 0;
        while (spawned < HumansManager.nbUntrust)
        {
            Instantiate(untrustfulHuman, new Vector3(xStart + 0.5f * x, yStart - 0.5f * y, 0), Quaternion.identity);
            spawned++;
            x++;
            if (x == 10)
            {
                x = 0;
                y++;
            }
        }
    }
}
