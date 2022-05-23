using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Human")
        {
            HumansManager.nbDeadTotal++;
            print("A human is dead...");
            if (other.gameObject.trust)
            {
                HumansManager.nbTrust--;
            }
            else
            {
                HumansManager.nbUntrust--;
            }
            Destroy(other.gameObject);

            if (HumansManager.nbLeftLevel == 0)
            {
                int nbHumansForLevel = 
                EndMenu.EndLevel(nbHumansForLevel, nbHumansFinished);
            }
        }
    }
}
