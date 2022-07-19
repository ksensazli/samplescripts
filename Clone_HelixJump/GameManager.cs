using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public int score;
    public Text scoreText;
    public GameObject completeLevelUI;

    public void Start()
    {
        GetComponent<Button>().onClick.AddListener(restartGame);
    }

    public void gameScore(int ringScore) {
        score += ringScore;
        scoreText.text = score.ToString();
    }
    
    public void restartGame() 
    {
        SceneManager.LoadScene("Level 1");
    }

    public void nextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void endGame()
    {
        completeLevelUI.SetActive(true);
    }
}
