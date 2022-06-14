using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu_HumanManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nb_Trust;
    [SerializeField] TextMeshProUGUI nb_Untrust;
    [SerializeField] TextMeshProUGUI nb_CollectibleTrust;
    [SerializeField] TextMeshProUGUI nb_CollectibleUntrust;

    private int start_nbTrust;
    private int start_nbUntrust;
    private int start_nbCollectibleTrust;
    private int start_nbCollectibleUntrust;

    public void Play()
    {
        SceneManager.LoadScene("MiniGame1");
    }

    public void SwapTrust()
    {
        if (HumansManager.nbCollectibleTrust > 0 && HumansManager.nbUntrust > 0)
        {
            HumansManager.nbCollectibleTrust -= 1;
            HumansManager.nbUntrust -= 1;
            HumansManager.nbTrust += 1;
        }
        UpdateValue();
    }

    public void SwapUntrust()
    {
        if (HumansManager.nbCollectibleUntrust > 0 && HumansManager.nbTrust > 0)
        {
            HumansManager.nbCollectibleUntrust -= 1;
            HumansManager.nbTrust -= 1;
            HumansManager.nbUntrust += 1;
        }
        UpdateValue();
    }

    public void Revert()
    {
        HumansManager.nbTrust = start_nbTrust;
        HumansManager.nbUntrust = start_nbUntrust;
        HumansManager.nbCollectibleTrust = start_nbCollectibleTrust;
        HumansManager.nbCollectibleUntrust = start_nbCollectibleUntrust;
        UpdateValue();
    }

    private void UpdateValue()
    {
        nb_Trust.text = HumansManager.nbTrust.ToString();
        nb_Untrust.text = HumansManager.nbUntrust.ToString();
        nb_CollectibleTrust.text = HumansManager.nbCollectibleTrust.ToString();
        nb_CollectibleUntrust.text = HumansManager.nbCollectibleUntrust.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        start_nbTrust = HumansManager.nbTrust;
        start_nbUntrust = HumansManager.nbUntrust;
        start_nbCollectibleTrust = HumansManager.nbCollectibleTrust;
        start_nbCollectibleUntrust = HumansManager.nbCollectibleUntrust;
        UpdateValue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
