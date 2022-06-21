using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu_CreaturesManager : MonoBehaviour
{
    [SerializeField] List<Sprite> LvlMaps;

    [SerializeField] TextMeshProUGUI nb_Explorers;
    [SerializeField] TextMeshProUGUI nb_Followers;
    [SerializeField] TextMeshProUGUI nb_CollectiblesFollower;
    [SerializeField] TextMeshProUGUI nb_CollectiblesExplorer;
    [SerializeField] TextMeshProUGUI tips;
    [SerializeField] string pathTips;

    private int start_nbFollowers;
    private int start_nbExplorers;
    private int start_nbCollectiblesFollower;
    private int start_nbCollectiblesExplorer;

    [Header("Sound settings")]
    [SerializeField] private float minPitch;
    [SerializeField] private float maxPitch;
    private SoundPlayer soundPlayer;

    public void Play()
    {
        SceneManager.LoadScene("Scenes/Lvl" + (CreaturesManager.currentLvl + 1).ToString());
    }

    public void SwapTrust()
    {
        if (CreaturesManager.nbCollectiblesFollower > 0 && CreaturesManager.nbExplorers > 0)
        {
            CreaturesManager.nbCollectiblesFollower -= 1;
            CreaturesManager.nbExplorers -= 1;
            CreaturesManager.nbFollowers += 1;

            soundPlayer.PlayYumSound(Random.Range(minPitch, maxPitch));
        }
        UpdateValue();
    }

    public void SwapUntrust()
    {
        if (CreaturesManager.nbCollectiblesExplorer > 0 && CreaturesManager.nbFollowers > 0)
        {
            CreaturesManager.nbCollectiblesExplorer -= 1;
            CreaturesManager.nbFollowers -= 1;
            CreaturesManager.nbExplorers += 1;

            soundPlayer.PlayYuckSound(Random.Range(minPitch, maxPitch));
        }
        UpdateValue();
    }

    public void Revert()
    {
        CreaturesManager.nbFollowers = start_nbFollowers;
        CreaturesManager.nbExplorers = start_nbExplorers;
        CreaturesManager.nbCollectiblesFollower = start_nbCollectiblesFollower;
        CreaturesManager.nbCollectiblesExplorer = start_nbCollectiblesExplorer;
        UpdateValue();
    }

    private void UpdateValue()
    {
        nb_Explorers.text = CreaturesManager.nbFollowers.ToString();
        nb_Followers.text = CreaturesManager.nbExplorers.ToString();
        nb_CollectiblesFollower.text = CreaturesManager.nbCollectiblesFollower.ToString();
        nb_CollectiblesExplorer.text = CreaturesManager.nbCollectiblesExplorer.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        // Creatures values
        start_nbFollowers = CreaturesManager.nbFollowers;
        start_nbExplorers = CreaturesManager.nbExplorers;
        start_nbCollectiblesFollower = CreaturesManager.nbCollectiblesFollower;
        start_nbCollectiblesExplorer = CreaturesManager.nbCollectiblesExplorer;
        UpdateValue();

        // Sound Player
        soundPlayer = GameObject.FindWithTag("SoundPlayer").GetComponent<SoundPlayer>();

        // Tips for next level
        pathTips = Application.streamingAssetsPath + pathTips;
        string[] lines = System.IO.File.ReadAllLines(pathTips);
        tips.text = lines[CreaturesManager.currentLvl];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
