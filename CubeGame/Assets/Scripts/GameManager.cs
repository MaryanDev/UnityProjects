using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float restartDelay = 1f;
    public GameObject completeLevelUI;

    public Score score;

    public void CompleteLevel()
    {
        Debug.Log("Level won");
        completeLevelUI.SetActive(true);
    }

    public void EndGame()
    {
        if (!gameHasEnded)
        {
            Debug.Log("Game over");
            gameHasEnded = true;
            score.enabled = false;
            Invoke("Restart", restartDelay);
        }
    }


    void Restart()
    {
        //SceneManager.LoadScene("Level 1");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
