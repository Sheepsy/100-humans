using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class TrustManager : MonoBehaviour
{
    // Le nombre de morts total depuis le début de la partie
    public int deaths = 0;
    
    // Le nombre de morts attendus au tour actuel
    public float expectedDeaths = 1;

    // Le niveau de confiance, correspondant à la probabilité, au début du niveau, qu'un humain suive le curseur
    public float trustLevel = 100;

    public float computeTrustLevel() {
        int nbDeathsCurrentTurn = HumansManager.nbDeadLevel;

        // On met à jour le nombre de morts total
        deaths = (deaths + nbDeathsCurrentTurn);


        // Ce nombre, compris entre -1 et 1, mesure la performance du joueur par rapport à ce qui était attendu
        float deathScore = Mathf.Max((expectedDeaths - nbDeathsCurrentTurn) / expectedDeaths, -1);

        // On modifie la confiance des humains en fonction de la performance
        // Si on ne perd personne à ce tour, la confiance est multipliée par 1.5
        // Si on perd au moins deux fois plus de personnes que prévu, la confiance est divisée par 2
        // Si on perd autant de gens que prévu, la confiance ne bouge pas
        trustLevel = Mathf.Max(Mathf.Min((1 + deathScore/2) * trustLevel, 100), 0);

        // On calcule le nombre de morts attendu au prochain tour
        expectedDeaths = trustLevel * (100 - deaths);
        
        return trustLevel;
    }

    public void updateHumansTrust(float trustLevel)
    {
        HumansManager.nbTrust = 0;
        HumansManager.nbUntrust = 0;
        for (int i = 0; i < HumansManager.nbAlive; i++)
        {
            if (Random.Range(0, 100) < trustLevel)
            {
                HumansManager.nbTrust++;
            }
            else
            {
                HumansManager.nbUntrust++;
            }
        }
    }
}