using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] TrustManager trustManager;

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
        int nbHumansTotal = HumansManager.nbBeginningLevel;
        int nbHumansSaved = HumansManager.nbSavedLevel;
        print($"You saved {nbHumansSaved} humans from the {nbHumansTotal}!");

        // TODO: calcul de la nouvelle confiance
        float trustLevel = trustManager.computeTrustLevel();
        trustManager.updateHumansTrust(trustLevel);
    }

    public void Next()
    {
        SceneManager.LoadScene("MiniGame1");
    }

    public void Quit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
