using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIcontroller : MonoBehaviour
{
    private Toggle _myToggle;
    Text text ;
    // Start is called before the first frame update
    void Start()
    {
       
         text = GetComponentInChildren<Text>() ; 
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
       /// <summary>
    /// This method is called by the Main Camera when it starts gazing at this GameObject.
    /// </summary>
    public void OnPointerEnter()
    {
        SetPressed(true);
    }

    /// <summary>
    /// This method is called by the Main Camera when it stops gazing at this GameObject.
    /// </summary>
    public void OnPointerExit()
    {
        SetPressed(false);
    }

    /// <summary>
    /// This method is called by the Main Camera when it is gazing at this GameObject and the screen
    /// is touched.
    /// </summary>
    public void OnPointerClick()
    {
        
    }

    /// <summary>
    /// Sets this instance's Pressed according to gazedAt status.
    /// </summary>
    ///
    /// <param name="gazedAt">
    /// Value `true` if this object is being gazed at, `false` otherwise.
    /// </param>
    private void SetPressed2()
    {
        
      if(_myToggle.isOn){ 
           _myToggle.isOn=false; 
      
      } 
      else {
        _myToggle.isOn=true;


      } 
    }
 

    int count=0;
      private void SetPressed(bool gazedAt)
    {
           
       
          SetPressed2();
         
      
    }
}
