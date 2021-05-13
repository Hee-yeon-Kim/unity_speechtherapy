using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timerscript : MonoBehaviour
{
    private Text timerText;
    float timer;
    private int totalTime;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        totalTime = 0;
        timerText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.unscaledDeltaTime;
        if (timer > 1)
        {
            totalTime++;
            int minutes = totalTime / 60;
            int seconds = totalTime % 60;
            string minute = minutes.ToString();
            string second = seconds.ToString();

            if (minutes < 10)
            {
                 minute = "0" + minutes.ToString();
            }
            if (seconds < 10)
            {
                second = "0" + seconds.ToString();
            }
            timerText.text = minute + ":" + second;

            timer = 0;
        }
    }
}
