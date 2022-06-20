using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    [SerializeField] bool trust;
    // Start is called before the first frame update
    void Start()
    {
        print("collectible");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {
        print("collision 2");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        print("collision");
        if (other.tag == "Creature")
        {
            if (trust)
            {
                CreaturesManager.nbCollectiblesFollower += 2;
            }
            else
            {
                CreaturesManager.nbCollectiblesExplorer += 2;
            }
            this.gameObject.SetActive(false);
        }
    }
}
