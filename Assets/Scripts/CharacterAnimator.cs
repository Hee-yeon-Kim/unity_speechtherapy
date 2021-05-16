using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
   public AudioClip quietsrc, loudsrc;

    GameObject[] m_CharacterList;
    GameObject[] m_FixedList;
    float timer=0;
    public int Mode=3;
    // Start is called before the first frame update
    void Start()
    {
        Mode = StaticVar.Level;
        m_CharacterList = GameObject.FindGameObjectsWithTag("m_Character");
        m_FixedList = GameObject.FindGameObjectsWithTag("m_Fixed");
        AudioSource audioSource= GetComponent<AudioSource>();

        int m_size = m_CharacterList.Length;
        Debug.Log(m_size+"사이즈임");
        for(int i=0; i<m_size; i++){
            Animator animator = m_CharacterList[i].GetComponent<Animator>();
            Debug.Log(m_CharacterList[i].name);
         
            
            int flag2 = Random.Range(0,100);
            if(flag2<50) animator.SetBool("Mirror",true);
            else animator.SetBool("Mirror",false);
            animator.SetFloat("Offset",Random.Range(-0.4f,0.4f));
            animator.SetFloat("Speed",Random.Range(0.73f,1.2f));
        }
        switch(Mode){
            case 1://1탄
                 FixedReation(true,true,true,true,true);
                 audioSource.clip = quietsrc;
                 audioSource.volume=0.2f;
                break;
            case 2:
                FixedReation(false,false,true,true,true);
                m_CharacterList[0].GetComponent<Animator>().SetTrigger("bad1");
                audioSource.clip = quietsrc;
                audioSource.volume=0.4f;
                break;
            case 3:
                FixedReation(false,false,false,false,false);
                m_CharacterList[0].GetComponent<Animator>().SetTrigger("bad1");
                m_CharacterList[2].GetComponent<Animator>().SetTrigger("gobad");
                m_CharacterList[6].GetComponent<Animator>().SetTrigger("bad1");
                m_CharacterList[7].GetComponent<Animator>().SetTrigger("toobad");
                audioSource.clip = loudsrc;
                audioSource.volume=0.13f;
                break;

        }
        // AnimatorClipInfo[] m_CurrentClipInfo = animator1.GetCurrentAnimatorClipInfo(0);
        // //Access the current length of the clip
        // float m_CurrentClipLength = m_CurrentClipInfo[0].clip.length;
        // //Access the Animation clip name  m_ClipName = m_CurrentClipInfo[0].clip.name;
        // animator1.SetFloat("Offset",m_CurrentClipLength/3f);
        // animator2.SetFloat("Offset",0f);  
    
      audioSource.Play();
      
    }

    void FixedReation(bool a1,bool a2, bool a3, bool a4, bool a5){
        Debug.Log(m_FixedList[0].name);
        Debug.Log(m_FixedList[1].name);
        Debug.Log(m_FixedList[2].name);
        Debug.Log(m_FixedList[3].name);
        Debug.Log(m_FixedList[4].name);

        Animator animator1 = m_FixedList[0].GetComponent<Animator>();
        animator1.SetBool("isgood",a1);
        Animator animator2 = m_FixedList[1].GetComponent<Animator>();
        animator2.SetBool("isgood",a2);
        Animator animator3 = m_FixedList[2].GetComponent<Animator>();
        animator3.SetBool("isgood",a3);
        Animator animator4 = m_FixedList[3].GetComponent<Animator>();
        animator4.SetBool("isgood",a4);
        Animator animator5 = m_FixedList[4].GetComponent<Animator>();
        animator5.SetBool("isgood",a5);

        animator1.SetTrigger("go");
        animator2.SetTrigger("go");
        animator3.SetTrigger("go");
        animator4.SetTrigger("go");
        animator5.SetTrigger("go");

    }

    void randomReaction(int flag){
        int n1=0, n2=0,n3=0;
        if(flag==1){
            n1 = 1; n2=11; n3=7;
        } else if(flag==2){
            n1=2; n2=0; n3=8;
        } else {
            n1=6; n2=4; n3=3;
        }
        Animator animator1=  m_CharacterList[n1].GetComponent<Animator>();
        Animator animator2=  m_CharacterList[n2].GetComponent<Animator>();
        Animator animator3=  m_CharacterList[n3].GetComponent<Animator>();
        int a1= Random.Range(1,4);
        int a2= Random.Range(1,4);
        int a3= Random.Range(1,4);
        Debug.Log(flag+"/ "+a1+" "+a2+" "+a3);

        switch(Mode){
            case 1:
                animator1.SetInteger("MotionFlag",a1);
                animator2.SetInteger("MotionFlag",a2);
                animator3.SetInteger("MotionFlag",a3);
                animator1.SetTrigger("motion1");
               // animator2.SetTrigger("motion1");
                animator3.SetTrigger("motion1");

                break;
            case 2:
                animator1.SetInteger("MotionFlag",a1);
                animator2.SetInteger("BadFlag",a2);
                animator3.SetInteger("BadFlag",a3);
                animator1.SetTrigger("motion1");
                animator2.SetTrigger("bad1");
                animator3.SetTrigger("bad1");
                break;
            case 3:
                animator1.SetInteger("BadFlag",a1);
                animator2.SetInteger("BadFlag",a2);
                animator3.SetInteger("BadFlag",a3);
                animator1.SetTrigger("bad1");
                animator2.SetTrigger("bad1");
                animator3.SetTrigger("bad1");
                break;

        }
    }

    int ReactionFlag=1;
    void Update()
    {
       timer += Time.deltaTime;
       if(timer>6.5f){
           randomReaction(ReactionFlag++);
           timer=0f;
           if(ReactionFlag>3){
               ReactionFlag=1;
           }
       }

    }

}
