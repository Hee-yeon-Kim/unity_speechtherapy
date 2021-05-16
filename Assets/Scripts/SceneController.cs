using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine.XR.Management;
using Google.XR.Cardboard;

public class SceneController : MonoBehaviour
{
    public Button btn;
    public ToggleGroup ModePicker;
    public ToggleGroup LevelPicker;

    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(btnListener);
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.brightness = 1.0f;
        ExitVR();
 
    }
    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))

            {
                Application.Quit();
            }
        }
    }

    private bool _isVrModeEnabled
    {
        get
        {
            return XRGeneralSettings.Instance.Manager.isInitializationComplete;
        }
    }
    /// <summary>
    /// Exits VR mode.
    /// </summary>
    private void ExitVR()
    {
        Debug.Log("Stopping XR...");
        XRGeneralSettings.Instance.Manager.StopSubsystems();
        Debug.Log("XR stopped.");

        Debug.Log("Deinitializing XR...");
        XRGeneralSettings.Instance.Manager.DeinitializeLoader();
        Debug.Log("XR deinitialized.");
    }

    /// <summary>
    /// Enters VR mode.
    /// </summary>
    private void EnterVR()
    {
        StartCoroutine(StartXR());
        if (Api.HasNewDeviceParams())
        {
            Api.ReloadDeviceParams();
        }
    }

    private IEnumerator StartXR()
    {
        Debug.Log("Initializing XR...");
        yield return XRGeneralSettings.Instance.Manager.InitializeLoader();

        if (XRGeneralSettings.Instance.Manager.activeLoader == null)
        {
            Debug.LogError("Initializing XR Failed.");
        }
        else
        {
            Debug.Log("XR initialized.");

            Debug.Log("Starting XR...");
            XRGeneralSettings.Instance.Manager.StartSubsystems();
            Debug.Log("XR started.");
        }
    }


    void btnListener()
    {
       
    
        Toggle ModePick = ModePicker.ActiveToggles().FirstOrDefault();
        if (ModePick.CompareTag("S1"))
        {
            SceneManager.LoadScene("ClassScene");
        } else if (ModePick.CompareTag("S2"))
        {
            SceneManager.LoadScene("MeetingScene");
        }
        else if (ModePick.CompareTag("S3"))
        {
            SceneManager.LoadScene("SmallMeetingScene");
        }

        Toggle LevelPick = LevelPicker.ActiveToggles().FirstOrDefault();
        if (ModePick.CompareTag("L1"))
        {
            StaticVar.Level = 1;
        }
        else if (ModePick.CompareTag("L2"))
        {
            StaticVar.Level = 2;
        }
        else if (ModePick.CompareTag("L3"))
        {
            StaticVar.Level = 3;
        }
    }
}
