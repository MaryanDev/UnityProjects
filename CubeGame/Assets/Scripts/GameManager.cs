using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float restartDelay = 1f;

    public void CompleteLevel() {
        Debug.Log("Level won");
    }
    
    public void EndGame()
    {
        if (!gameHasEnded)
        {
            Debug.Log("Game over");
            gameHasEnded = true;
            Invoke("Restart", restartDelay);
        }
    }  


    void Restart()
    {
        //SceneManager.LoadScene("Level 1");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
