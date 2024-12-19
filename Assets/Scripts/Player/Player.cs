using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Drawing;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using Unity.VisualScripting;
using System.Linq;
public class Player : MonoBehaviour
{
    public int level = 0;
    public int health = 100;
    public int batteryEnergy = 0;
    public string[,] items = new string[12, 3];
    public List<int> _itemsFromSave = new List<int>();
	[SerializeField]
	private GameObject flashLightUI;
    
    public Vector3 position;

    void Start()
    {
		//Debug.Log(items[0,0]);
		//items = new string[12][];
        LoadPlayer();
        GetItemFunctional();
    }
    public void ChangeLevel (int hp)
    {
        level += hp;
    }
    public void ChangeHealth (int damage){
        health -= damage;    
    }
    
    public void SavePlayer()
    { 
        Debug.Log("Saved Player : " + this.items);
        SaveSystem.SavePlayer(this);    
    }

    private Item[] itemList;
    public void LoadPlayer(){
        PlayerData data = SaveSystem.LoadPlayer();

        if (data != null)
        {
            level = data.level;
            health = data.health;

            
            position.x = data.position[0];
            position.y = data.position[1];
            position.z = data.position[2];
            transform.position = position;

            items = data.items;
            //Deleting items from loc
            _itemsFromSave = data._itemsFromSave;
            itemList = FindObjectsOfType<Item>();
            if (_itemsFromSave != null && itemList != null)
            {
                for (int s = 0; s < _itemsFromSave.Count; s++)
                {
                    Debug.Log($"itemsFromSave = {_itemsFromSave[s]}");
                    for (int i = 0; i < itemList.Length; i++)
                    {
                        if (itemList[i].ItemID == _itemsFromSave[s])
                        {
                            itemList[i].gameObject.SetActive(false);
                        }
                    }
                }
            }

            // End Deleting
            batteryEnergy = data.batteryEnergy;
            Debug.Log($"BatteryEnergy = {batteryEnergy}");
        }
    }

    public void GetItemFunctional()
    {
        if (items[0, 0] != null)
        {
            Item FlashLightInstance = null;
            for (int i = 0; i < items.Length / 3; i++)
            {
                string className = items[i, 0];
                if (className != null)
                {
                    Type type = Type.GetType(className);

                    if (type != null && typeof(Item).IsAssignableFrom(type))
                    {

                        if (className == "FlashLight")
                        {
                            FlashLightInstance = (Item)Activator.CreateInstance(type);
                            Debug.Log($"Created instance of {className}");
                            flashLightUI.SetActive(true);
                            /*flashLightUI.gameObject.GetComponent<Button>().onClick.RemoveAllListeners();
                            flashLightUI.gameObject.GetComponent<Button>().onClick.AddListener(() =>
                            {
                                FlashLightInstance.FlashLightOnOff();
                            });*/
                        }
                        else
                        {
                            Item instance = (Item)Activator.CreateInstance(type);

                        }
                        /*else if (className == "Battery")
                        {
                            flashLightUI.gameObject.GetComponent<Button>().interactable = true;
                            instance.ItemCount = items[i, 1].ToString();
                        }*/
                    }
                    else
                    {
                        Debug.LogError($"Class {className} not found or does not inherit from Item.");
                    }


                }
            }

            
        }
    }

    private T CreateInstance<T>() where T : Item, new()
    {
        return new T();
    }


#if UNITY_EDITOR
     void OnApplicationQuit()
     {
         SavePlayer();
     }
#else
    void OnApplicationPause()
    {
        SavePlayer();
    }
#endif
    

}
