using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Menu_HumanManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nb_Trust;
    [SerializeField] TextMeshProUGUI nb_Untrust;

    // Start is called before the first frame update
    void Start()
    {
        nb_Trust.text = HumansManager.nbTrust.ToString();
        nb_Untrust.text = HumansManager.nbUntrust.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
