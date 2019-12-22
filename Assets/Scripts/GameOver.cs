using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {
    public GameObject gameOverScreen;
    public Text score;
    bool gameOver;

    // Update is called once per frame
    void Update() {
        if (gameOver){
            if (Input.GetKeyDown(KeyCode.Space)){
                Debug.Log("JJJ");
                SceneManager.LoadScene(0);
            }
        }
    }

    public void onGameOver() {
        gameOverScreen.SetActive(true);
        score.text = Mathf.Round(Time.timeSinceLevelLoad).ToString();
        gameOver = true;
    }
}
