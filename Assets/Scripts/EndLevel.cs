using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
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
            HumansManager.nbSavedLevel++;
            HumansManager.nbLeftLevel--;
            print("Another Human saved!");
            other.gameObject.SetActive(false);

            if (HumansManager.nbLeftLevel == 0)
            {
                EndMenu.EndLevel();
            }
        }
    }
}
