using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [SerializeField] private EndMenu EndMenu;

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
            HumansManager.nbAlive--;
            HumansManager.nbDeadLevel++;
            HumansManager.nbLeftLevel--;
            if (other.gameObject.GetComponent<ControlHumans>().trust)
            {
                HumansManager.nbTrust--;
            }
            else
            {
                HumansManager.nbUntrust--;
            }
            Destroy(other.gameObject);
            print("A human is dead...");

            if (HumansManager.nbLeftLevel == 0)
            {
                EndMenu.EndLevel();
            }
        }
    }
}
