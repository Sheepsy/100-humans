using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HumansManager
{
    // For each playthrough
    public static int nbTrust = 15;
    public static int nbUntrust = 15;
    public static int nbAlive = 30;
    public static int nbCollectibleTrust = 2;
    public static int nbCollectibleUntrust = 2;

    public static int currentLvl = 0;

    // For each level
    public static int nbBeginningLevel;
    public static int nbLeftLevel;
    public static int nbDeadLevel;
    public static int nbSavedLevel;
    public static bool isLevelStarted;
}
