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
            if (gameIsPaused)
            {
                gameIsPaused = false;
                Time.timeScale = 1f;
            }
            else
            {
                gameIsPaused = true;
                Time.timeScale = 0f;
            }

            menu.SetActive(gameIsPaused);
        }
    }

    public void Resume()
    {
        gameIsPaused = false;
        menu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameIsPaused = false;
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        SceneManager.LoadScene("MainMenu");
        gameIsPaused = false;
        Time.timeScale = 1f;
    }
}
