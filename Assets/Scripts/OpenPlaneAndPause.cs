using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenPlaneAndPause : MonoBehaviour
{
    [SerializeField] private GameObject ClosePlane, OpenPlane, InteractiveUI;
    public bool AfterPause;

    public void OpenPlanePauseGame()
    {
        ClosePlane.SetActive(false);
        OpenPlane.SetActive(true);
        if (InteractiveUI != null)
        {
            InteractiveUI.SetActive(false);
        }
    
       

        if(AfterPause == true)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
        //Time.timeScale = isPause ? 1 : 0;

        Debug.Log(Time.timeScale);
    }
}
