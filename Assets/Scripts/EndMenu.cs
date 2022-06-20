using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    [SerializeField] GameObject menu;
    int nbLevels = 5;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EndLevel()
    {
        menu.SetActive(true);
        int nbCreaturesTotal = CreaturesManager.nbBeginningLevel;
        int nbCreaturesSaved = CreaturesManager.nbSavedLevel;
        print($"You saved {nbCreaturesSaved} humans from the {nbCreaturesTotal}!");

        CreaturesManager.currentLvl++;
        if (CreaturesManager.currentLvl < nbLevels && CreaturesManager.nbAlive > 0)
        {
            SceneManager.LoadScene("Management_menu");
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
