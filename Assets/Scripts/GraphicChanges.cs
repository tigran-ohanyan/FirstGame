using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphicChanges : MonoBehaviour
{
    private Color BtnColor, Change;
    
    [SerializeField]
    protected GameObject[] Buttons;

    public void Start()
    {
        Buttons[PlayerPrefs.GetInt("GraphicSettings")].GetComponent<Image>().color = new Color32(100, 200, 200, 255);
    }

    public void ClickBtn(int ID)
    {
        Change = new Color32(100, 200, 200, 255);
        BtnColor = gameObject.GetComponent<Image>().color;
        gameObject.GetComponent<Image>().color = Change;
        Buttons[PlayerPrefs.GetInt("GraphicSettings")].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        PlayerPrefs.SetInt("GraphicSettings", ID);
        QualitySettings.SetQualityLevel(ID);
        
        Debug.Log(BtnColor);
    }
}
