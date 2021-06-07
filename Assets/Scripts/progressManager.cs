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
    public Image anxietyMark;
 
    public Sprite GreenSign,RedSign;

    public Text scoretext;
    [HideInInspector] public bool isInterrupted;
    [HideInInspector] public int badcount = 0; float totaltimer = 0f;
    public GameObject BioPanel, Character;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        javaClass = new AndroidJavaClass("com.heeyeon.newreceiver.FeedbackReceiver");
        javaClassInstance = javaClass.CallStatic<AndroidJavaObject>("createInstance");

        javaClassInstance.Call("register_Receiver");
        scoretext.text = "Analyzing... ";
        isInterrupted = false;
    }

    private void ChangeColor(int score)
    {
        if (score > 4) return;
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
            case 0:
                break;

            case 1:
                color1 = new Color(255f / 255f, 90f / 255f, 0f / 255f);
                color2 = new Color(255f / 255f, 45f / 255f, 0f / 255f);
                color3 = new Color(255f / 255f, 0f / 255f, 0f / 255f);

                //scoretext.text = "나쁨";
                break;
            case 2:
                color1 = new Color(255f / 255f, 130f / 255f, 0f / 255f);
                color2 = new Color(255f / 255f, 130f / 255f, 0f / 255f);
                color3 = new Color(255f / 255f, 130f / 255f, 0f / 255f);
                color4 = new Color(255f / 255f, 130f / 255f, 0f / 255f);
                color5 = new Color(255f / 255f, 130f / 255f, 0f / 255f);
                color6 = new Color(255f / 255f, 130f / 255f, 0f / 255f);

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
        if (timer > 5f)//10초 마다 확인
        {
            timer = 0f;

            checkStatus();
        }
        timer += Time.unscaledDeltaTime;
        totaltimer += Time.unscaledDeltaTime;
        
    }
    void sendToMain()
    {
        javaClassInstance.Call("sendDATA", badcount, totaltimer);
    }
    private void OnDestroy()
    {
        sendToMain();
    }
    int anxietycount = 0;
    void checkStatus()
    {
        try
        {
            int breathscore = javaClassInstance.Call<int>("getBREATH");

            int anxiety = javaClassInstance.Call<int>("getScore");
            if (anxiety == 1)
            {
                anxietycount++;
            }
            else
            {
                anxietycount = 0;
            }

            if(anxietycount>=6 && isInterrupted == false)
            {//30s anxiety==1
                isInterrupted = true;
                StartCoroutine(StartFeedback());
              
            }

            if (isInterrupted == false)
            {
                return;
            }

            switch (breathscore)
            {
                    case 0:
                        scoretext.text = "Analyzing... ";
                        break;
                    case 1:
                        scoretext.text = "Very Poor";
                        break;
                    case 2:
                        scoretext.text = "Poor";
                        break;
                    case 3:
                        scoretext.text = "Good";
                        break;
                    case 4:
                        scoretext.text = "Excellent";
                        break;
            }
            ChangeColor(breathscore);
            if (anxiety == 1)
            {
                anxietyMark.sprite = RedSign;
            } else
            {
                anxietyMark.sprite = GreenSign;
            }

        }
        catch
        {
            scoretext.text = "/";
            return;
        }
        

    }
    private void OnDisable()
    {
        // javaClassInstance.Call("unregister_Receiver");
        
    }
    IEnumerator StartFeedback()
    {
        BioPanel.SetActive(true);
        Character.SetActive(true);
        isInterrupted = true;
        badcount++;

        yield return new WaitForSeconds(57);
        BioPanel.SetActive(false);
        Character.SetActive(false);
        isInterrupted = false;

    }
}
