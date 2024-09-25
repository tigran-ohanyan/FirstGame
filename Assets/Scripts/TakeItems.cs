using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeItems : MonoBehaviour
{
    public int ItemID;
    public Renderer ItemRenderer;
    public string ItemName;
    public GameObject obj;
    
    public void GetItem()
    {
        int count = PlayerPrefs.GetInt(ItemName);
        PlayerPrefs.SetInt(ItemName, count + 1);
        PlayerPrefs.SetInt("ItemID", ItemID);
        Destroy(obj);

        Debug.Log(ItemName + " - " + count);
    }

}
