using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] platformPrefabs;
    float currentYPos = 0f;
    public float cameraHeight = 5.5f;//Record high

    public Transform platformPool;//full-automatic

    public GameObject background;   //background
    public Text[] ScoreText;  //scoretext
    public GameOverManager GameOverManager;
    public GameObject OverUI;//finishUI
    public GameObject Player; //gameplayer
    //Maximum integral number
    private int MaxScore=0;
    // Start is called before the first frame update
    void Start()//loop condition
    {
        SpawnPlatformPool();//max hight that platform form
        //Get the GameOverManager script
        GameOverManager = GameObject.Find("GameOverManager").GetComponent<GameOverManager>();
        while (currentYPos < Camera.main.transform.position.y + cameraHeight)
        {
            PickNewPlatform();//form platform
        }
    }

    void SpawnPlatformPool()
    {
        int basicPlatformAmount = 30;//preset 30
        int weakPlatformAmount = 15;//pre ste 15

        for (int i = 0; i < basicPlatformAmount; i++)//for loop
        {
            GameObject platform = Instantiate(platformPrefabs[0], platformPool);//[0] means basic elememnts, the most basic platform, put it into platform pool
            platform.SetActive(false);//then hide it
        }

        for (int i = 0; i < weakPlatformAmount; i++)//loop
        {
            GameObject platform = Instantiate(platformPrefabs[1], platformPool);//[1] means weak elememnts, brown platform
            platform.SetActive(false);//hide it
        }
    }

    void PickNewPlatform()
    {
        currentYPos += Random.Range(0.3f, 1f);//The vertical spacing changes
        float xPos = Random.Range(-3.8f, 3.8f);//ramdon position

        int r = 0;//new var
        do//do loop
        {
            r = Random.Range(0, platformPool.childCount);//take from platform pool
        } while (platformPool.GetChild(r).gameObject.activeInHierarchy);//if child is already shown in the screen, we need to re-get it from the platform pool.

        platformPool.GetChild(r).position = new Vector2(xPos, currentYPos);
        platformPool.GetChild(r).gameObject.SetActive(true);//show the object(platform)
    }
    // Update is called once per frame
    void Update()
    {
        if (currentYPos < Camera.main.transform.position.y + cameraHeight)
        {
            PickNewPlatform();
        }
        //Credits are judged when the background and the character are at a certain distance
        if (background.transform.position.y - Player.transform.position.y < 5)
        {
            //Credits are based on the player's Y position
            GameOverManager.score = (int)Player.transform.position.y;
            //Above the maximum value of the integral, the substitution
            if (MaxScore < GameOverManager.score)
            {
                MaxScore = GameOverManager.score;
            }
            //Traversal updates the integral display
            foreach (var item in ScoreText)
            {
                item.text = MaxScore.ToString();
            }
        }
        else if (!OverUI.activeSelf)
        {
            if (GameOverManager.score < 0)
            {
                foreach (var item in ScoreText)
                {
                    GameOverManager.score = 0;
                    item.text = GameOverManager.score.ToString();
                }
            }
            //Update the final integral
            GameOverManager.score = MaxScore;
            //Switch to the GameOver scene
            SceneManager.LoadScene("GameOver");
        }
    }
    public void PlayerAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}