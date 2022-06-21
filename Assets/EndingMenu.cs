using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndingMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI endText;

    // Start is called before the first frame update
    void Start()
    {
        if (CreaturesManager.nbAlive > 0)
        {
            endText.text = "You win!\nYou saved " + CreaturesManager.nbAlive.ToString() + " Wigglys!";
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Play()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
