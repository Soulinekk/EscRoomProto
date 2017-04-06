using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseableElement : MonoBehaviour {
    [HideInInspector]
    public bool picked;
    public string objName;
    public Sprite icon;
    protected virtual void Start()
    {
        picked = false;
    }

    public void PickUp()
    {

        StartCoroutine(OnPickUp());
    }

    protected virtual IEnumerator OnPickUp()
    {
        Inventory.Instance.AddToInventory(this);
        yield return null;
    }
}
