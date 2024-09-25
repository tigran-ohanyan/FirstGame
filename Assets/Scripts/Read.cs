using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Read : MonoBehaviour, IInteractable
{
    public bool isOn = false;
    public GameObject bookUI;
    public int BookID;

    public GameObject bookImage;
    public Sprite[] sprite;
    public TextMeshProUGUI title, description;

    void Start()
    {
        bookUI.SetActive(isOn);

        GetBook();

    }
    public string GetDescription()
    {
        return "Нажми на кнопку для взаимодействии";
    }
    public void Interact()
    {
        bookUI.SetActive(isOn);
        isOn = !isOn;

    }

    public void GetBook()
    {
        if (BookID == 0)
        {
            title.text = "Testing";
            description.text = "awdawdwa";
            bookImage.GetComponent<Image>().sprite = sprite[BookID];

        }

    }

}
