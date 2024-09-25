using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    public Camera mainCamera;
    public float interactionDistance = 5f;

    private bool btnOn = false;

    public GameObject InteractionUI, bookBtn, takeBtn;
    public TextMeshProUGUI interactionText;

    //public GameObject InteractionObject;

    // Update is called once per frame
    void Update()
    {
        //InteractionRay();
    }

    void InteractionRay()
    {
        Ray ray = mainCamera.ViewportPointToRay(Vector3.one / 2f);
        RaycastHit hit;

        bool hitSomething = false;

        if(Physics.Raycast(ray, out hit, interactionDistance))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            Debug.Log("Interactable - " + interactable);
            //InteractionObject = hit.collider;

            if (interactable != null)
            {
                Debug.Log("Interact Collider - " + interactable);
                hitSomething = true;

                interactionText.text = interactable.GetDescription();
                if (btnOn == true)
                {
                    interactable.Interact();
                }
            }

            if(hit.collider.tag == "Book")
            {
                bookBtn.SetActive(true);
            }
            else
            {
                bookBtn.SetActive(false);
            }
            if (hit.collider.tag == "Take")
            {
                takeBtn.SetActive(true);
                takeBtn.GetComponent<TakeItems>().ItemRenderer = hit.collider.GetComponent<MeshRenderer>();
                takeBtn.GetComponent<TakeItems>().ItemID = hit.collider.GetComponent<ItemProps>().ItemID;
                takeBtn.GetComponent<TakeItems>().ItemName = hit.collider.GetComponent<ItemProps>().ItemName;
                takeBtn.GetComponent<TakeItems>().obj = hit.collider.gameObject;
            }
            else
            {
                takeBtn.SetActive(false);
            }

        }
        Debug.Log("HitSomething - " + hitSomething);
        InteractionUI.SetActive(hitSomething);
    }
   
}
