using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class CreaturesManager
{
    // For each playthrough
    public static int nbFollowers = 15;
    public static int nbExplorers = 15;
    public static int nbAlive = 30;
    public static int nbCollectiblesFollower = 2;
    public static int nbCollectiblesExplorer = 2;
    public static int currentLvl = 0;

    // For each level
    public static int nbBeginningLevel;
    public static int nbLeftLevel;
    public static int nbDeadLevel;
    public static int nbSavedLevel;
    public static bool isLevelStarted;
}
