﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VaultBehaviour : MonoBehaviour {

    private Vector3 vectorToZoomTo = new Vector3(0.635f, 0.943f, -10f);
    private float camSize = 0.17f;
    private float timeLerp = 0.5f;
    private GameObject vaultDoors;
    public bool canOpen = false;
    public GameObject vKey;
    public bool keyPlaced = false;
    
	void Start () {

        vaultDoors = GameObject.Find("door");
	}
	
	void Update () {

    }

    public void OpenVault()
    {

        if( keyPlaced == true)
        {
            canOpen = true;
        }

        if (canOpen)
        {

            Manager.Instance.backButton.SetActive(true);
            Manager.Instance.actualStuffForSwitch = "door_to_close";
            Manager.Instance.ScreenZoom(vectorToZoomTo, camSize, timeLerp);
            vaultDoors.GetComponent<BoxCollider>().enabled = false;
            vaultDoors.SetActive(false);
        }
    }

    public void PutKey()
    {
        if (canOpen == false)
        {
            
            if(Manager.Instance.itemActive != -1 && Manager.Instance.itemsSlots[Manager.Instance.itemActive].gameObject.transform.childCount != 0 && Manager.Instance.itemsSlots[Manager.Instance.itemActive].gameObject.transform.GetChild(0).name == "lvl1_KeyVaultSmall(Clone)")
            {


                vaultDoors.GetComponent<BoxCollider>().enabled = false;
                Manager.Instance.VaultDoorInvokeMethod();
                Instantiate(vKey, vaultDoors.transform);
                Destroy(Manager.Instance.itemsSlots[Manager.Instance.itemActive].gameObject.transform.GetChild(0).gameObject);
                keyPlaced = true;
            }
        }
        
    }

    #region Input Behaviour
    void OnTouchDown()
    {

    }

    void OnTouchUp()
    {
        if (Manager.Instance.countClicksOn)
        {
            Manager.Instance.clickAmount--;
            if (Manager.Instance.clickAmount == 0)
                Manager.Instance.GameOver();
        }

        OpenVault();
        PutKey();
    }

    void OnTouchStay()
    {

    }

    void OnTouchExit()
    {

    }

    #endregion
}