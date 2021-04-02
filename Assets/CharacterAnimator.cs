using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
 

    GameObject[] m_CharacterList;

    // Start is called before the first frame update
    void Start()
    {
        m_CharacterList = GameObject.FindGameObjectsWithTag("m_Character");
        int m_size = m_CharacterList.Length;
        Debug.Log(m_size+"사이즈임");
        for(int i=0; i<m_size; i++){
            Animator animator = m_CharacterList[i].GetComponent<Animator>();
            int flag= Random.Range(1,4);
            animator.SetInteger("IdleFlag",flag);
            int flag2 = Random.Range(0,100);
            if(flag2<50) animator.SetBool("Mirror",true);
            else animator.SetBool("Mirror",false);
            animator.SetFloat("Offset",Random.Range(-0.4f,0.4f));
            animator.SetFloat("Speed",Random.Range(0.6f,1.4f));
        }
        // AnimatorClipInfo[] m_CurrentClipInfo = animator1.GetCurrentAnimatorClipInfo(0);
        // //Access the current length of the clip
        // float m_CurrentClipLength = m_CurrentClipInfo[0].clip.length;
        // //Access the Animation clip name  m_ClipName = m_CurrentClipInfo[0].clip.name;
        // animator1.SetFloat("Offset",m_CurrentClipLength/3f);
        // animator2.SetFloat("Offset",0f);  
    
    
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
