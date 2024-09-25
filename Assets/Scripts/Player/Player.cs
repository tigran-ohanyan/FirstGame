using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

using System.Runtime.Serialization.Formatters.Binary;
public class Player : MonoBehaviour
{
    public int level = 0;
    public int health = 100;
    public string[,] items = new string[12, 2];

    void Start()
    {
		//Debug.Log(items[0,0]);
		//items = new string[12][];
        LoadPlayer();
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
