using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [SerializeField] private EndMenu endMenu;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        endMenu = FindObjectOfType<EndMenu>(true);
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Creature")
        {
            anim.SetTrigger("isTrapTriggered");
            
            ControlCreatures ccreatures = other.gameObject.GetComponent<ControlCreatures>();

            CreaturesManager.nbAlive--;
            CreaturesManager.nbDeadLevel++;
            CreaturesManager.nbLeftLevel--;
            if (ccreatures.IsFollower())
            {
                CreaturesManager.nbFollowers--;
            }
            else
            {
                CreaturesManager.nbExplorers--;
            }

            ccreatures.GetSoundPlayer().PlayDeathSound(ccreatures.GetPitch());
            Destroy(other.gameObject);
            
            if (CreaturesManager.nbLeftLevel == 0)
            {
                endMenu.EndLevel();
            }
        }
    }
}
