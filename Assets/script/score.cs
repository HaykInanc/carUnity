using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class score
{
    public static float curTime;
    public static float bestTime;
    public static void upadteBestTime() {

        if (score.curTime < score.bestTime || score.bestTime == 0)
        {
            score.bestTime = score.curTime;
        };
    }
}
