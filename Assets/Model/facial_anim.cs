using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class facial_anim : MonoBehaviour
{
    Material myMat;
    public TextMesh text;
  //  public ParticleSystem particles;
    float timer;
    int second;
    string stage;
    Animator anim;
    public Animator anim2;
    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        myMat = gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material;
        anim = GetComponent<Animator>();
        timer = 0;
        second = 0;
        count = 0;
        text.text = "";
        stage = "";
        // Time.timeScale = 1.0f;
        animEvent(count);

    }
    private void Update()
    {
        timer += Time.unscaledDeltaTime;
        float tmp = Time.unscaledDeltaTime/ Time.deltaTime ;
        anim.SetFloat("_speed", tmp);
        anim2.SetFloat("_speed", tmp);

        if (timer > 1)
        {
            if (count < 9) count++;
            else count = 0;
            animEvent(count);
            timer = 0;
            text.text = stage + "\n" + second.ToString() + "초" ;
            second--;

        }
    }

    // Update is called once per frame
    public void animEvent(int num)
    {
        switch (num)
        {
            case 0:

                myMat.mainTextureOffset = new Vector2(1 / 3f, 0f);
                second = 4;  
                stage = "Inhale";
                break;
            case 1://입조금
                myMat.mainTextureOffset = new Vector2(1 / 3f, 0f);
                
                break;
            case 2://입많이
                myMat.mainTextureOffset = new Vector2(2 / 3f, 0f);
                break;
            case 3://fixed 윙크  입 조금
                 myMat.mainTextureOffset = new Vector2(0f, 1 / 3f);
               // particles.Play();
                break;
            case 4://fixed 눈감  입 조금
                second = 6;  
                stage = "Exhale";
                myMat.mainTextureOffset = new Vector2(1 / 3f, 1 / 3f);
                break;
            case 5://눈감  입 조금 
                myMat.mainTextureOffset = new Vector2(2 / 3f, 1 / 3f);
                break;
            case 8://눈 감          
                myMat.mainTextureOffset = new Vector2(0f, 2 / 3f);
                break;
            case 9://기본
                myMat.mainTextureOffset = new Vector2(0f, 0f);
                break;
            default:
                break;
            
        }


    }
}
