//-----------------------------------------------------------------------
// <copyright file="CameraPointer.cs" company="Google LLC">
// Copyright 2020 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Sends messages to gazed GameObject.
/// </summary>
public class CameraPointer2 : MonoBehaviour
{
    private const float _maxDistance = 150;
    private GameObject _gazedAtObject = null;
   public  GameObject BioFeedbackPanel,BioCharacter;
    public progressManager _progressManager;

    GameObject preSphere=null;

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    public void Update()
    {
        // Casts ray towards camera's forward direction, to detect if a GameObject is being gazed
        // at.
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, _maxDistance))
        {
            // GameObject detected in front of the camera.
            if (_gazedAtObject != hit.transform.gameObject)
            {
                _gazedAtObject = hit.transform.gameObject;

                if (_gazedAtObject.tag == "toggle") {
                    // New GameObject.
                    Debug.Log("toggle");
                   
                    SceneManager.LoadScene("StartScene");
                } else if (_gazedAtObject.tag == "toggle2") {
                    Debug.Log("toggle2");
                     
                    StartCoroutine(StartFeedback());
                }
                /*else if (_gazedAtObject.tag == "chgameobject") {
                  //  if (preSphere != null) ChangeMat(preSphere, false);
                  //  _gazedAtObject = hit.transform.gameObject;
                  //  preSphere = _gazedAtObject.transform.GetChild(1).gameObject;
                   // ChangeMat(preSphere, true);

                } else {
                    if (preSphere != null) {
                        ChangeMat(preSphere, false);
                        preSphere = null;
                    }
                    _gazedAtObject = hit.transform.gameObject;
                }*/
            }
        }
        else
        {
            // No GameObject detected in front of the camera.
            if(_gazedAtObject.tag=="toggle"|| _gazedAtObject.tag == "toggle2")
            { 
                 _gazedAtObject = null;
            }
        }

        
    }
 /*   public Material SphereRed;
     public Material SphereWhite;
    public void ChangeMat( GameObject gameObject, bool isActive){
        if (gameObject == null) return;
        if(isActive) gameObject.GetComponent<MeshRenderer>().material = SphereRed;
        else gameObject.GetComponent<MeshRenderer>().material =  SphereWhite;
        
    }*/
    IEnumerator StartFeedback()
    {
       BioFeedbackPanel.SetActive(true);
        BioCharacter.SetActive(true);
        _progressManager.isInterrupted = true;
        _progressManager.badcount++;
        yield return new WaitForSeconds(180);
       BioFeedbackPanel.SetActive(false);
        BioCharacter.SetActive(false);

    }
}
