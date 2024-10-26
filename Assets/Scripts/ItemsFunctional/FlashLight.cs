using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FlashLight : Item
{
	
	 private GameObject flashLightObj, flashLightUIBtn;
	[SerializeField] private GameObject batteryPercentObj;
	private Light onOffObj;
	private TextMeshProUGUI batteryPercent;
	private int batteryPercentInt;
	private GameObject playerObject;
	Battery battery = new Battery();
	public FlashLight()
    {
        flashLightObj = GameObject.FindGameObjectWithTag("MainCamera").transform.GetChild(0).gameObject;
        flashLightObj.SetActive(true);
        /*
        playerObject = GameObject.FindGameObjectWithTag("Player");
        
        flashLightUIBtn = GameObject.FindGameObjectWithTag("Hood").transform.GetChild(0).gameObject;
        flashLightUIBtn.SetActive(true);
        batteryPercentObj = flashLightUIBtn.transform.GetChild(0).gameObject;
        batteryPercent = batteryPercentObj.GetComponent<TextMeshProUGUI>();
        if (batteryPercent != null)
        {
		    batteryPercent.text = playerObject.GetComponent<Player>().batteryEnergy.ToString() + "%";
        }
		else
        {
	        Debug.LogError($"BatteryPercent = {batteryPercent}");
        }
		*/
        //onOffObj = flashLightObj.transform.GetChild(0).GetComponent<Light>();
    }
/*

	public override void FlashLightOnOff()
	{

		onOffObj = flashLightObj.transform.GetChild(0).GetComponent<Light>();
		if (playerObject.GetComponent<Player>().batteryEnergy >= 1)
		{
			if (onOffObj.enabled)
			{
				onOffObj.enabled = false;
				//battery.StartCoroutineBattery(false);


			}
			else
			{
				onOffObj.enabled = true;
				//battery.StartCoroutineBattery(true);
			}
		}
		else
		{
			onOffObj.enabled = true;
			//StopCoroutine(DecreaseBattery());
		}
		/* REWORK
		Debug.Log($"item 0-0 - {items[0, 0]}");
		int BatteryIndex = -1;
		for (int i = 0; i < items.Length / 2; i++)
		{
			if (items[i, 0] == "Battery")
			{
				BatteryIndex = i;
				Debug.Log($"BatteryIndex = {BatteryIndex}");
			}
		}

		if (BatteryIndex >= 0)
		{
			batteryPercentInt = int.Parse(items[BatteryIndex, 1]) * 100;
			batteryPercent.text = batteryPercentInt.ToString() + "%";
			Debug.Log($"BatteryPercentInt = {batteryPercentInt}");
			if(onOffObj.enabled){
				onOffObj.enabled = false;
				PlayerPrefs.SetInt("FlashLightOnOff", 0);
				StopCoroutine(DecreaseBattery());
			}else{
				onOffObj.enabled = true;
				PlayerPrefs.SetInt("FlashLightOnOff", 1);
				StartCoroutine(DecreaseBattery());
			}
		}
		else
		{
			PlayerPrefs.SetInt("FlashLightOnOff", 0);
			onOffObj.enabled = false;
		}



	}*/
	

}
