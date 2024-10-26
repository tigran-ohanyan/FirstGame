using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int level, health, batteryEnergy;
    public float[] position;
	public string[,] items = new string[12, 3];
	public List<int> _itemsFromSave = new List<int>();

    public PlayerData(Player player){
        level = player.level;
        health = player.health;
        
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
		
		items = player.items;
		_itemsFromSave = player._itemsFromSave;
		batteryEnergy = player.batteryEnergy;

    }

}
