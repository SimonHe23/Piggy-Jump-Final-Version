using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreShow : MonoBehaviour
{
    public GameOverManager GameOverManager;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        //access to the component
        GameOverManager = GameObject.Find("GameOver").GetComponent<GameOverManager>();
        //Update display credits
        scoreText.text = GameOverManager.score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //If the component is NULL, continue fetching
        if (GameOverManager == null)
        {
            GameOverManager = GameObject.Find("GameOver").GetComponent<GameOverManager>();
        }
        else
        {
            //If it is not empty, the integral is displayed
            scoreText.text = GameOverManager.score.ToString();
        }
    }

    public void PlayerAgain(string name)
    {
        //The credits return to 0 when you restart, load the scene
        GameOverManager.score = 0;
        SceneManager.LoadScene(name);
    }
}
