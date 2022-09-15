using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class God : MonoBehaviour
{
    //public float Timer;
    public bool Alive = true;
    private void Awake()
    {
        //Singleton = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            //SceneManager.LoadScene("SampleScene");
        }
        if (Alive)
        {
            /* Survival?
            Timer += Time.deltaTime;
            Timertext.text = "Time: " + Mathf.Round(Timer);
            Gameovertext.text = "Game OverYou Survived: " + Mathf.Round(Timer) + " Seconds";*/
        }
    }
}