using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxWithKey : MonoBehaviour {

    private int id;

	// Use this for initialization
	void Start () {
        id = 2;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    #region Input Behaviour
    void OnTouchDown()
    {

    }

    void OnTouchUp()
    {
        Manager.Instance.OnItemPickUp(id, gameObject);
        Manager.Instance.countClicksOn = true;
        Manager.Instance.clickCountText.gameObject.SetActive(true);
        Manager.Instance.itemsToDoStuffWith[5].SetActive(true);
    }

    void OnTouchStay()
    {

    }

    void OnTouchExit()
    {

    }
    #endregion
}
