using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetVariables : MonoBehaviour
{
    [SerializeField] private int nbFollowers;
    [SerializeField] private int nbExplorers;
    [SerializeField] private int nbCollectiblesFollower;
    [SerializeField] private int nbCollectiblesExplorer;

    // Start is called before the first frame update
    void Start()
    {
        CreaturesManager.nbFollowers = nbFollowers;
        CreaturesManager.nbExplorers = nbExplorers;
        CreaturesManager.nbAlive = nbFollowers + nbExplorers;
        CreaturesManager.nbCollectiblesFollower = nbCollectiblesFollower;
        CreaturesManager.nbCollectiblesExplorer = nbCollectiblesExplorer;
        CreaturesManager.currentLvl = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
