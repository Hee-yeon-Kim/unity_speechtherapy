using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class facial_anim : MonoBehaviour
{
    Material myMat;
    public TextMesh text;
    int second;
    string stage;
    Animator anim;
    public Animator anim2;
    public GameObject RestEffect;
        
    int total = 0;

    void Start()
    {
        myMat = gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material;
        anim = GetComponent<Animator>();
        second = 0;
        text.text = "";
        stage = "";
        // Time.timeScale = 1.0f;

    }
  
   
    // Update is called once per frame
    public void AnimEvent(int num)
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
                case 4://윙크
                    second = 7;
                    myMat.mainTextureOffset = new Vector2(0f, 1 / 3f);
                    stage = "Holding";
                    break;
                case 11://fixed 눈감  입 조금
                    second = 8;
                    stage = "Exhale";
                    myMat.mainTextureOffset = new Vector2(1 / 3f, 1 / 3f);
                    break;
                case 13://눈감  입 조금 
                    myMat.mainTextureOffset = new Vector2(2 / 3f, 1 / 3f);
                    break;
                case 17://눈 감          
                    myMat.mainTextureOffset = new Vector2(0f, 2 / 3f);
                    break;
                case 19://기본
                    myMat.mainTextureOffset = new Vector2(0f, 0f);
                    break;
                default:
                    break;

            }
        text.text = stage + "\n" + second.ToString() + "Sec";

        second--;


    }
}
