using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class progressManager : MonoBehaviour
{
    float timer = 0;

    private AndroidJavaObject activityContext = null;
    private AndroidJavaClass javaClass = null;
    private AndroidJavaObject javaClassInstance = null;

    public Image c1,c2,c3,c4,c5,c6,c7,c8,c9,c10;
 
    public Text scoretext;

    // Start is called before the first frame update
    void Start()
    {
        scoretext = GetComponent<Text>();
        
        timer = 0;
        javaClass = new AndroidJavaClass("com.ims.e4receiver.E4BroadcastReceiver");
        javaClassInstance = javaClass.CallStatic<AndroidJavaObject>("createInstance");
        //data 받기 시작
        javaClassInstance.Call("register_Receiver");

        javaClassInstance.Call("Initialize");
    }

    private void ChangeColor(int score)
    {
        Color color1 = Color.gray;
        Color color2 = Color.gray;
        Color color3 = Color.gray;
        Color color4 = Color.gray;
        Color color5 = Color.gray;
        Color color6 = Color.gray;
        Color color7 = Color.gray;
        Color color8 = Color.gray;  
        Color color9 = Color.gray;
        Color color10 = Color.gray;

        switch (score)
        {
            case 1:
                color1 = new Color(255f / 255f, 90f / 255f, 0f / 255f);
                color2 = new Color(255f / 255f, 45f / 255f, 0f / 255f);
                color3 = new Color(255f / 255f, 0f / 255f, 0f / 255f);

                //scoretext.text = "나쁨";
                break;
            case 2:
                color1 = new Color(255f / 255f, 190f / 255f, 0f / 255f);
                color2 = new Color(235f / 255f, 190f / 255f, 0f / 255f);
                color3 = new Color(215f / 255f, 190f / 255f, 0f / 255f);
                color4 = new Color(195f / 255f, 190f / 255f, 0f / 255f);
                color5 = new Color(170f / 255f, 190f / 255f, 0f / 255f);
                color6 = new Color(160f / 255f, 190f / 255f, 0f / 255f);

                break;
            case 3:
                color1 = new Color(120f / 255f, 200f / 255f, 0f / 255f);
                color2 = new Color(100f / 255f, 200f / 255f, 0f / 255f);
                color3 = new Color(80f / 255f, 200f / 255f, 0f / 255f);
                color4 = new Color(60f / 255f, 200f / 255f, 0f / 255f);
                color5 = new Color(45f / 255f, 200f / 255f, 0f / 255f);
                color6 = new Color(20f / 255f, 200f / 255f, 0f / 255f);
                color7 = new Color(15f / 255f, 200f / 255f, 0f / 255f);
                color8 = new Color(0f / 255f, 200f / 255f, 0f / 255f);

                break;
            case 4:
                color1 = new Color(120f / 255f, 200f / 255f, 0f / 255f);
                color2 = new Color(100f / 255f, 200f / 255f, 0f / 255f);
                color3 = new Color(80f / 255f, 200f / 255f, 0f / 255f);
                color4 = new Color(60f / 255f, 200f / 255f, 0f / 255f);
                color5 = new Color(45f / 255f, 200f / 255f, 0f / 255f);
                color6 = new Color(20f / 255f, 200f / 255f, 0f / 255f);
                color7 = new Color(15f / 255f, 200f / 255f, 0f / 255f);
                color8 = new Color(0f / 255f, 200f / 255f, 0f / 255f);
                color9 = new Color(0f / 255f, 230f / 255f, 0f / 255f);
                color10 = new Color(0f / 255f, 255f / 255f, 0f / 255f);

                break;
            

     
        }
        c1.color = color1;
        c2.color = color2;
        c3.color = color3;
        c4.color = color4;
        c5.color = color5;
        c6.color = color6;
        c7.color = color7;
        c8.color = color8;
        c9.color = color9;
        c10.color = color10;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 5.6f)//10초 마다 확인
        {
            timer = 0f;

            checkStatus();
        }
        timer += Time.unscaledDeltaTime;

        
    }

    void checkStatus()
    {
        try
        {
            int[] tmp = javaClassInstance.Call<int[]>("getScores");

            if (tmp != null)
            {
                int len = tmp.Length;
                if (tmp.Length > 0)
                {
                    int gotscore = tmp[len - 1];
                    scoretext.text = gotscore.ToString() + "점";
                    int flag = 0;
                    if (gotscore > 75) flag = 4;
                    else if (gotscore > 50) flag = 3;
                    else if (gotscore > 25) flag = 2;
                    else flag = 1;
                    ChangeColor(flag);

                }
            }
        }
        catch
        {
            return;
        }

    }
    private void OnDisable()
    {
        javaClassInstance.Call("unregister_Receiver");
        /* AndroidNotificationCenter.CancelAllNotifications();
         AndroidNotificationCenter.DeleteNotificationChannel("channel_id");
         //javaClassInstance.Call("unregister_Receiver");*/

    }
}
