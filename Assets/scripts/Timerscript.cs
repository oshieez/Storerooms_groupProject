using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timerscript : MonoBehaviour
{
    public float timeleft;

    public int timeRemaining;

    public Text  TimerText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeleft -= Time.deltaTime;

        timeRemaining = Mathf.FloorToInt(timeleft % 60);

        TimerText.text = "Timer : " + timeRemaining.ToString();

        if(timeRemaining <= 0)
        {
            SceneManager.LoadScene("LoseScene");
        }
    }
}
