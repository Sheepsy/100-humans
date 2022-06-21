using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    [SerializeField] private EndMenu endMenu;

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
        if (other.tag == "Creature")
        {
            ControlCreatures ccreatures = other.gameObject.GetComponent<ControlCreatures>();

            CreaturesManager.nbSavedLevel++;
            CreaturesManager.nbLeftLevel--;
            print("Another creature saved!");
            other.gameObject.SetActive(false);

            ccreatures.GetSoundPlayer().PlayJoySound(ccreatures.GetPitch());

            if (CreaturesManager.nbLeftLevel == 0)
            {
                endMenu.EndLevel();
            }
        }
    }
}
