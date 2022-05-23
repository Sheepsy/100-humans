using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitHumans : MonoBehaviour
{
    public GameObject trustfulHuman;
    public GameObject untrustfulHuman;

    // Start is called before the first frame update
    void Start()
    {
        HumansManager.nbLeft = HumansManager.nbTrust + HumansManager.nbUntrust;

        for (int i = 0; i < HumansManager.nbTrust; i++)
            Instantiate(trustfulHuman, new Vector3(-8f + 0.25f * i, 1, 0), Quaternion.identity);
        for (int i = 0; i < HumansManager.nbUntrust; i++)
            Instantiate(untrustfulHuman, new Vector3(-8f + 0.25f * i, -1, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
