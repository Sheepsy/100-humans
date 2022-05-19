using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject menu;
    public bool gameIsPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameIsPaused = !gameIsPaused;
            menu.SetActive(gameIsPaused);
        }
    }

    public void Resume()
    {
        gameIsPaused = false;
        menu.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameIsPaused = false;
    }

    public void Quit()
    {
        SceneManager.LoadScene("MainMenu");
        gameIsPaused = false;
    }
}
