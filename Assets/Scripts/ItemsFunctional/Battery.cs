using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Battery : MonoBehaviour
{
    [SerializeField] private GameObject FlashLightBtn, playerObject;

    [SerializeField] private TextMeshProUGUI batteryPercentText;
    
    [SerializeField] private Light flashLightLight;
    
    private int batteryPercentInt;
    private bool isActive;
    
    private Coroutine flashLightCoroutine = null;
    
    private Inventory inventory;
    public void Start()
    {
        batteryPercentText.text = playerObject.GetComponent<Player>().batteryEnergy.ToString() + "%";
        if (flashLightLight.GetComponent<Light>().enabled == true)
        {
            isActive = true;
        }
        else
        {
            isActive = false;
            flashLightLight.GetComponent<Light>().enabled = false;
        }
        
        inventory = playerObject.GetComponent<Inventory>(); 

    }

    public void BtnClick()
    {
        if (isActive == true && flashLightCoroutine != null || playerObject.GetComponent<Player>().batteryEnergy <= 1 && flashLightCoroutine != null)
        {
            flashLightLight.GetComponent<Light>().enabled = false;
            isActive = false;
            StopCoroutine(flashLightCoroutine);

        }
        else if(isActive == false && playerObject.GetComponent<Player>().batteryEnergy >= 1)
        {
            flashLightLight.GetComponent<Light>().enabled = true;
            isActive = true;
            flashLightCoroutine = StartCoroutine(DecreaseBattery());

        }
        /*else
        {
            isActive = false;
            StopCoroutine(DecreaseBattery());
        }*/
    }

    private IEnumerator DecreaseBattery()
    {
        if (playerObject.GetComponent<Player>().batteryEnergy >= 1)
        {
            if (isActive == true)
            {
                while (playerObject.GetComponent<Player>().batteryEnergy > 0)
                {
                
                    playerObject.GetComponent<Player>().batteryEnergy--;
                    batteryPercentText.text = playerObject.GetComponent<Player>().batteryEnergy.ToString() + "%";
                    if (playerObject.GetComponent<Player>().batteryEnergy == 0)
                    {
                        isActive = false;
                        flashLightLight.GetComponent<Light>().enabled = false;

                        GetBatteryEnergy();
                    }
                    yield return new WaitForSeconds(1);
                }
            }
        }
        else
        {
            isActive = false;
            Debug.Log("Батарея исчерпана!");

           // yield return null;
        }

    }
    
    private void GetBatteryEnergy()
    {
        if (playerObject.GetComponent<Player>().items[0, 0] != null)
        {
            for (int i = 0; i < playerObject.GetComponent<Player>().items.Length / 3; i++)
            {
                if (playerObject.GetComponent<Player>().items[i, 0] == "Battery")
                {
                    playerObject.GetComponent<Player>().batteryEnergy += 100;
                    batteryPercentText.text = playerObject.GetComponent<Player>().batteryEnergy.ToString() + "%";
                    flashLightLight.GetComponent<Light>().enabled = true;
                    isActive = true;
                    if (int.Parse(playerObject.GetComponent<Player>().items[i, 1]) == 1)
                    {
                        playerObject.GetComponent<Player>().items[i, 0] = null;
                        playerObject.GetComponent<Player>().items[i, 1] = null;
                        playerObject.GetComponent<Player>().items[i, 2] = null;
                    }
                    else
                    {
                        playerObject.GetComponent<Player>().items[i, 1] = (int.Parse(playerObject.GetComponent<Player>().items[i, 1]) - 1).ToString();
                    }
                    inventory.DisplayItem();
                    
                    
                }
            }
        }
    }

   
}
