using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    [SerializeField] bool trust;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Human"))
        {
            if (trust)
            {
                HumansManager.nbCollectibleTrust += 1;
            }
            else
            {
                HumansManager.nbCollectibleUntrust += 1;
            }
            this.gameObject.SetActive(false);
        }
    }
}
