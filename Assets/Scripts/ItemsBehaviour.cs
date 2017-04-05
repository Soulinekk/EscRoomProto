using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemsBehaviour : MonoBehaviour, IPointerClickHandler{

    public int itemIdInSlot;
    public bool slotTakenOrNot;                                                                         // false = there is no item in slot
    public int slotId;
    
	void Start () {
        slotTakenOrNot = false;
	}
	
	void Update () {
		
	}


    public void OnPointerClick(PointerEventData eventData)
    {
        if (Manager.Instance.itemActive == -1)
        {
            Image image = GetComponent<Image>();
            Color c = image.color;
            c.a = 255;
            image.color = c;
            Manager.Instance.itemActive = slotId;

        }
        else
        {
            Image image = Manager.Instance.itemsSlots[Manager.Instance.itemActive].gameObject.GetComponent<Image>();
            Color c = image.color;
            c.a = 0.5f;
            image.color = c;
            Manager.Instance.itemActive = slotId;

            image = Manager.Instance.itemsSlots[slotId].gameObject.GetComponent<Image>();
            c = image.color;
            c.a = 1f;
            image.color = c;
            Manager.Instance.itemActive = slotId;
        }
    }
}
