using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class ItemProps : MonoBehaviour, IInteractable
{
    public int ItemID;
    public string ItemName;


    void Start()
    {
        if (PlayerPrefs.GetInt("ItemID") == ItemID)
        {
            Destroy(gameObject);
        }
    }
    public string GetDescription()
    {
        return "Нажми на кнопку чтобы подобрать";
    }
    public void Interact()
    {
        
    }

}
