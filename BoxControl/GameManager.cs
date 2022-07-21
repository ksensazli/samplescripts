using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float restartDelay = 1f;

    public GameObject completeLevelUI;
    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
        Invoke("Restart", restartDelay);
    }

    public void EndGame()
    {
        Debug.Log("Yo");
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("GameOver.");
            Invoke("Restart", restartDelay);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
