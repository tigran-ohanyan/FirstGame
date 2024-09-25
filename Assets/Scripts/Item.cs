using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int ItemID;
    public string ItemName;
    public int ItemCount;
    public bool IsStack;
	public bool Usability;
	
	public enum TypeSelector{
		Book,
		Flashlight,
		Battery
	}
	public TypeSelector ItemType;
	
	public string Title;
    [Multiline(5)]
    public string ItemDescription;
    public string pathIcon, pathPrefabs;
	public Sprite Image;

    void Start()
    {
        pathIcon = "Icons/" + ItemName;
        pathPrefabs = "Prefabs/" + ItemName;
    }

    void Update()
    {
        
    }
}
