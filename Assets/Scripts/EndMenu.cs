using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    [SerializeField] GameObject menu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndLevel(int nbHumansSaved)
    {
        menu.SetActive(true);
        print($"You saved {nbHumansSaved} humans!");

        // TODO: calcul de la nouvelle confiance
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
