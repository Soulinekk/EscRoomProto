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

            if (Manager.Instance.itemsSlots[Manager.Instance.itemActive].gameObject.transform.childCount != 0 && Manager.Instance.itemsSlots[Manager.Instance.itemActive].gameObject.transform.GetChild(0).name == "lvl1_Puzzle(Clone)" && Manager.Instance.itemFirstSpawnPlace.childCount == 0)
            {

                Manager.Instance.ScreenZoom(new Vector3(0.358f, 1.206f, -10f), 0.12f, 0.2f);
                Manager.Instance.itemPlaceholder = Instantiate(Manager.Instance.itemsByIdBigOne[0], Manager.Instance.itemsToDoStuffWith[1].transform);
                Manager.Instance.actualStuffForSwitch = "box_to_open";
                Manager.Instance.backButton.SetActive(true);
                Manager.Instance.inputControlsScript.enabled = false;
                Manager.Instance.itemsToDoStuffWith[4].SetActive(false);
                Manager.Instance.itemsToDoStuffWith[8].SetActive(true);
            }
        }
        else
        {
            Image image = Manager.Instance.itemsSlots[Manager.Instance.itemActive].gameObject.GetComponent<Image>();
            Color c = image.color;
            c.a = 0.5f;
            image.color = c;

            image = Manager.Instance.itemsSlots[slotId].gameObject.GetComponent<Image>();
            c = image.color;
            c.a = 1f;
            image.color = c;
            Manager.Instance.itemActive = slotId;

            if (Manager.Instance.itemsSlots[Manager.Instance.itemActive].gameObject.transform.childCount != 0 && Manager.Instance.itemsSlots[Manager.Instance.itemActive].gameObject.transform.GetChild(0).name == "lvl1_Puzzle(Clone)" && Manager.Instance.itemFirstSpawnPlace.childCount == 0)
            {

                Manager.Instance.ScreenZoom(new Vector3(0.358f, 1.206f, -10f), 0.12f, 0.2f);
                Manager.Instance.itemPlaceholder = Instantiate(Manager.Instance.itemsByIdBigOne[0], Manager.Instance.itemsToDoStuffWith[1].transform);
                Manager.Instance.actualStuffForSwitch = "box_to_open";
                Manager.Instance.backButton.SetActive(true);
                Manager.Instance.inputControlsScript.enabled = false;
                Manager.Instance.itemsToDoStuffWith[4].SetActive(false);
                Manager.Instance.itemsToDoStuffWith[8].SetActive(true);
            }
        }

        if (Manager.Instance.countClicksOn)
        {
            Manager.Instance.clickAmount--;
            if (Manager.Instance.clickAmount == 0)
                Manager.Instance.GameOver();
        }
    }

    public void UnactiveButton()
    {
        Image image = Manager.Instance.itemsSlots[Manager.Instance.itemActive].gameObject.GetComponent<Image>();
        Color c = image.color;
        c.a = 0.5f;
        image.color = c;
        Manager.Instance.itemActive = slotId;
    }
}
