using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {

    public bool canOpenDoor = false;


	void Start () {
        canOpenDoor = false;
	}
	
	void Update () {
		
	}

    void OnTouchDown()
    {

    }

    void OnTouchUp()
    {
        if (Manager.Instance.itemsSlots[Manager.Instance.itemActive].gameObject.transform.childCount != 0 && Manager.Instance.itemsSlots[Manager.Instance.itemActive].gameObject.transform.GetChild(0).name == "lvl1_KeyDoorSmall(Clone)") ;
        {
            SceneManager.LoadScene(1);
        }
    }

    void OnTouchStay()
    {

    }

    void OnTouchExit()
    {

    }
}
