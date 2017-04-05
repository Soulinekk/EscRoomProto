using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl1_KeyBehaviour : MonoBehaviour {

    #region Viarables

    private int id;
    public bool canPickUp = false;

#endregion

    // Use this for initialization
    void Start () {
        id = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTouchDown()
    {

    }

    void OnTouchUp()
    {

        if(canPickUp)
            Manager.Instance.OnItemPickUp(id, gameObject);
    }

    void OnTouchStay()
    {

    }

    void OnTouchExit()
    {

    }
}
