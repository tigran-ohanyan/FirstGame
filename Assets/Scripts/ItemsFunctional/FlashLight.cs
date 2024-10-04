using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashLight : Item
{
    private GameObject flashLightObj;
	private Light onOffObj;
    
    public FlashLight()
    {
        flashLightObj = GameObject.FindGameObjectWithTag("MainCamera").transform.GetChild(0).gameObject;
        flashLightObj.SetActive(true);
		onOffObj = flashLightObj.transform.GetChild(0).GetComponent<Light>();
		if(PlayerPrefs.GetInt("FlashLightOnOff") == 0){
			onOffObj.enabled = false;
		}else{
			onOffObj.enabled = true;
		}
       // flashLightBtn.SetActive(true);
    }
	public override void FlashLightOnOff(){
		if(onOffObj.enabled){
			onOffObj.enabled = false;
			PlayerPrefs.SetInt("FlashLightOnOff", 0);
		}else{
			onOffObj.enabled = true;
			PlayerPrefs.SetInt("FlashLightOnOff", 1);
		}
	}

}
