using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    [SerializeField] EndMenu EndMenu;

    public int nbHumansForLevel;
    public int nbHumansAlive;
    private int nbHumansFinished;

    // Start is called before the first frame update
    void Start()
    {
        nbHumansFinished = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Human")
        {
            nbHumansFinished++;
            print("Another Human saved!");
            other.gameObject.SetActive(false);

            if (nbHumansFinished == nbHumansAlive)
            {
                EndMenu.EndLevel(nbHumansForLevel, nbHumansFinished);
            }
        }
    }
}
