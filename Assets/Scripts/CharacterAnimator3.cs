using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator3 : MonoBehaviour
{
    //Fixed 5 : Random 5
 
    public Animator josh, lousie, leonard;
    public AudioClip quietsrc, loudsrc;
    float timer=0f;
    float duration=10f;
    public int Mode=3;
  
    // Start is called before the first frame update
    void Start()
    {
        Mode = StaticVar.Level;

        lousie = lousie.GetComponent<Animator>();
        leonard = leonard.GetComponent<Animator>();
        AudioSource audioSource= GetComponent<AudioSource>();

        switch(Mode){
            case 1://1탄
                lousie.SetBool("isgood",true);
                leonard.SetTrigger("goodfor3");
                duration = 6.5f;
                audioSource.clip = quietsrc;
                 audioSource.volume=0.2f;
                break;
            case 2:
                lousie.SetBool("isgood",true);
                leonard.SetBool("isgood",true);
                duration=6.5f;
                audioSource.clip = quietsrc;
                audioSource.volume=0.4f;

                break;
            case 3:
                lousie.SetBool("isgood",false);
                leonard.SetBool("isgood",false);
                duration=6.5f;
                audioSource.clip = loudsrc;
                audioSource.volume=0.13f;

                break;

        }
        lousie.SetTrigger("go");
        leonard.SetTrigger("go");
        audioSource.Play();

      
    }


    void randomReaction(int ReactionFlag){
       
        int a1= Random.Range(1,4);
        int a2= Random.Range(1,4);

        switch(Mode){
            case 1:
                if(ReactionFlag>4){
                    josh.SetInteger("MotionFlag",a1);
                    josh.SetTrigger("motion1");
                } else if(ReactionFlag>3){
                    lousie.SetInteger("MotionFlag",a1);
                    lousie.SetTrigger("motion1");
                } else if(ReactionFlag>2){
                    josh.SetInteger("MotionFlag",a2);
                    josh.SetTrigger("motion1");
                } else if(ReactionFlag>1){
                    lousie.SetInteger("MotionFlag",a2);
                    lousie.SetTrigger("motion1");
                } else {
                    josh.SetInteger("MotionFlag",a1);
                    josh.SetTrigger("motion1");
                }
                break;

            case 2:
                if(ReactionFlag>4){
                    lousie.SetInteger("MotionFlag",a1);
                    lousie.SetTrigger("motion1");
                } else if(ReactionFlag>3){
                    josh.SetInteger("BadFlag",a2);
                    josh.SetTrigger("bad1");
                }
                else if(ReactionFlag>2){
                    lousie.SetInteger("MotionFlag",a1);
                    lousie.SetTrigger("motion1");
                } else if(ReactionFlag>1){
                    josh.SetInteger("MotionFlag",a2);
                    josh.SetTrigger("motion1");
                } else {
                    josh.SetInteger("MotionFlag",a2);
                    josh.SetTrigger("motion1");
                }
                break;
            case 3:
                if(ReactionFlag>4){
                     josh.SetInteger("BadFlag",a2);
                    josh.SetTrigger("bad1");
                    
                } else if(ReactionFlag>3){
                    lousie.SetInteger("MotionFlag",a1);
                    lousie.SetTrigger("motion1");
                    leonard.SetTrigger("gonew");
                }
                else if(ReactionFlag>2){
                    lousie.SetInteger("MotionFlag",a1);
                    lousie.SetTrigger("motion1");
                } else if(ReactionFlag>1){
                    josh.SetInteger("MotionFlag",a2);
                    josh.SetTrigger("motion1");
                } else {

                    josh.SetInteger("MotionFlag",a1);
                    josh.SetTrigger("motion1");
                }
              
                break;

        }
    }

    int ReactionFlag=1;
    void Update()
    {
       timer += Time.deltaTime;
       if(timer>duration){
           randomReaction(ReactionFlag++);
           timer=0f;
           if(ReactionFlag>5){
               ReactionFlag=1;
           }
       }

    }

}
