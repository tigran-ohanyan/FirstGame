using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using Unity.VisualScripting;
public class Player : MonoBehaviour
{
    public int level = 0;
    public int health = 100;
    public string[,] items = new string[12, 2];
	[SerializeField]
	private GameObject flashLightUI;

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
        
        level = data.level;
        health = data.health;
        
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    
        items = data.items;
		GameObject pref;
        itemList = FindObjectsOfType<Item>();
        for (int s = 0; s <= itemList.Length; s++)
        {
            for (int i = 0; i < items.Length / 2; i++)
            {
                if (items[i, 0] != null)
                {
                    pref = Resources.Load("Prefabs/" + items[i, 0]) as GameObject;
                    if (pref.GetComponent<Item>().ItemID == itemList[s].ItemID)
                    {
                        itemList[s].gameObject.SetActive(false);
                    }
                }
            }
        }
    }

    
    public void GetItemFunctional()
    {
        if (items[0, 0] != null)
        {
            
            for (int i = 0; i < items.Length/2; i++)
            {
                string className = items[i, 0];
                if (className != null)
                {
                    Type type = Type.GetType(className);

                    if (type != null && typeof(Item).IsAssignableFrom(type))
                    {
                        Item instance = (Item)Activator.CreateInstance(type);
                        // Теперь можно использовать экземпляр instance
                        Debug.Log($"Created instance of {className}");
						if (className == "FlashLight")
                   		{
                        	//TODO
                        	//flashLightUI = GameObject.FindGameObjectWithTag("FlashLightBtn");
                       		flashLightUI.SetActive(true);
							flashLightUI.gameObject.GetComponent<Button>().onClick.RemoveAllListeners();
							flashLightUI.gameObject.GetComponent<Button>().onClick.AddListener(() => { instance.FlashLightOnOff(); });
                   		}
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
