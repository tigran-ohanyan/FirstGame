using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    public GameObject CellContainer;
    public GameObject InteractionUI, takeBtn;
    public TextMeshProUGUI interactText;
    bool isPressed = false;
	private GameObject playerS;
	[SerializeField]
	private GameObject BookUI;
    void Start()
    {
  		playerS = GameObject.FindGameObjectWithTag("Player");
        Debug.Log("Items list = " + playerS.GetComponent<Player>().items.Length);

        Debug.Log(Application.persistentDataPath);
		DisplayItem();

    }
    void Update()
    {
       if(Time.timeScale != 0)
           RayCastHiting();
    }

    public void RayCastHiting()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 2f))
        {
            if (hit.collider.GetComponent<Item>())
            {
                interactText.text = "Нажми на кнопку чтобы подабрать";
                InteractionUI.SetActive(true);
                takeBtn.SetActive(true);
                if (isPressed == true)
                {
                    isPressed = !isPressed;
                    for (int i = 0; i <= playerS.GetComponent<Player>().items.Length/2; i++)
                    {
						if(playerS.GetComponent<Player>().items[i, 0] == hit.collider.GetComponent<Item>().ItemName){
							int _count = int.Parse(playerS.GetComponent<Player>().items[i, 1]);
							_count += hit.collider.GetComponent<Item>().ItemCount;
							playerS.GetComponent<Player>().items[i, 1] = _count.ToString();
							DisplayItem();
                            hit.collider.GetComponent<Item>().gameObject.SetActive(false);
                            break;
						}
                        else if (playerS.GetComponent<Player>().items[i, 0] == null)
                        {
                            playerS.GetComponent<Player>().items[i, 0] = hit.collider.GetComponent<Item>().ItemName;
                            //int _count = int.Parse(playerS.GetComponent<Player>().items[i, 1]);
							int _count = hit.collider.GetComponent<Item>().ItemCount;
							playerS.GetComponent<Player>().items[i, 1] = _count.ToString();
                            DisplayItem();
                            hit.collider.GetComponent<Item>().gameObject.SetActive(false);
                            break;
                        }
                    }

                }
            }
            else
            {
                InteractionUI.SetActive(false);
                takeBtn.SetActive(false);
            }
        }
        
    }

    public void ButtonsClicked()
    {
        isPressed = !isPressed;
    }
	
	private GameObject pref;

    public void DisplayItem()
    {
	    for (int i = 0; i < playerS.GetComponent<Player>().items.Length / 2; i++) // CONTINUE!!!
        {
            Transform cell = CellContainer.transform.GetChild(i);
            Transform icon = cell.GetChild(0);
            Image img = icon.GetComponent<Image>();
            TextMeshProUGUI count = icon.GetChild(0).GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI itemTitle = icon.GetChild(1).GetComponent<TextMeshProUGUI>();
            if (playerS.GetComponent<Player>().items[i, 0] != null)
            {
	            string itemName = playerS.GetComponent<Player>().items[i, 0];

				pref = Resources.Load("Prefabs/" + itemName) as GameObject;
				if(pref.GetComponent<Item>().Usability == true)
				{
					cell.gameObject.AddComponent<Button>();
					cell.gameObject.GetComponent<Button>().onClick.RemoveAllListeners();
					cell.gameObject.GetComponent<Button>().onClick.AddListener(() => { InteractWithItem(itemName); });
				}
				count.enabled = true;
				
				itemTitle.enabled = true;
				itemTitle.text = pref.GetComponent<Item>().Title;
				
                img.enabled = true;
                img.sprite = Resources.Load<Sprite>("Icons/" + itemName);
                //pref = Resources.Load("Prefabs/" + playerS.GetComponent<Player>().items[i]) as GameObject;
				count.text = playerS.GetComponent<Player>().items[i, 1];
				
				playerS.GetComponent<Player>().GetItemFunctional();

                //break;
            }
            else
            {
				count.enabled = false;
				itemTitle.enabled = false;
                img.enabled = false;
                img.sprite = null;
            }
        }
    }
	
	protected void InteractWithItem(string itemName){
		pref = Resources.Load("Prefabs/" + itemName) as GameObject;
		//private Item.TypeSelector selector = pref.GetComponent<Item>().ItemType;
		Item.TypeSelector ItemType = pref.GetComponent<Item>().ItemType;
		if (ItemType == Item.TypeSelector.Book)
		{
			BookUI.SetActive(true);
			BookUI.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = pref.GetComponent<Item>().ItemDescription;
			BookUI.transform.GetChild(1).GetComponent<Image>().sprite = pref.GetComponent<Item>().Image;
			BookUI.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = pref.GetComponent<Item>().Title;
		}

}



}
