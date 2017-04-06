using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPickedUp : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTouchDown()
    {

    }

    void OnTouchUp()
    {

        if(Manager.Instance.itemsSlots[Manager.Instance.itemActive].gameObject.transform.childCount != 0 && Manager.Instance.itemsSlots[Manager.Instance.itemActive].gameObject.transform.GetChild(0).name == "lvl1_KeySmall(Clone)")
        {
            
            for (int i = 0; i < Manager.Instance.itemsSlots.Length; i++)
            {
                if(Manager.Instance.itemsSlots[i].gameObject.transform.childCount != 0 && Manager.Instance.itemsSlots[i].gameObject.transform.GetChild(0).name == "lvl1_BoxSmall(Clone)")
                {
                    Destroy(Manager.Instance.itemsSlots[i].gameObject.transform.GetChild(0).gameObject);
                }
            }
            Destroy(Manager.Instance.itemsSlots[Manager.Instance.itemActive].gameObject.transform.GetChild(0).gameObject);
            Manager.Instance.backButton.SetActive(false);
            Manager.Instance.OnItemPickUp(3, Manager.Instance.itemFirstSpawnPlace.GetChild(0).gameObject);
            Manager.Instance.itemsToDoStuffWith[1].SetActive(false);
        }
    }

    void OnTouchStay()
    {

    }

    void OnTouchExit()
    {

    }
}
