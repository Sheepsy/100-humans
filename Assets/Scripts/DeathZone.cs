using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [SerializeField] private EndMenu endMenu;

    // Start is called before the first frame update
    void Start()
    {
        endMenu = FindObjectOfType<EndMenu>(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Creature")
        {
            CreaturesManager.nbAlive--;
            CreaturesManager.nbDeadLevel++;
            CreaturesManager.nbLeftLevel--;
            if (other.gameObject.GetComponent<ControlCreatures>().IsFollower())
            {
                CreaturesManager.nbFollowers--;
            }
            else
            {
                CreaturesManager.nbExplorers--;
            }
            Destroy(other.gameObject);
            print("A creature is dead...");

            if (CreaturesManager.nbLeftLevel == 0)
            {
                endMenu.EndLevel();
            }
        }
    }
}
