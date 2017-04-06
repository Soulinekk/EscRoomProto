using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaultKeyBehaviour : MonoBehaviour {

    public bool canPickUp = false;
    private int id;

    // Use this for initialization
    void Start () {
        id = 1;
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
        if (canPickUp)
        {
            Manager.Instance.OnItemPickUp(id, gameObject);
        }
    }

    void OnTouchStay()
    {

    }

    void OnTouchExit()
    {

    }
    #endregion
}
