using UnityEngine;

public static class Difficulty {
   static float secondsToMaxDifficulty = 60f;

   public static float getDifficultyPercent() {
       return Mathf.Clamp01(Time.timeSinceLevelLoad / secondsToMaxDifficulty);
   }
}
