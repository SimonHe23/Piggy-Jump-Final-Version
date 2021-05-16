using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    //Static integral
    public static int score = 0;
    public void Awake()
    {
        //Switching scenes will not be destroyed
        DontDestroyOnLoad(this);
    }
}
