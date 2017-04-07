using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseableElement : MonoBehaviour {
    [HideInInspector]
    public bool picked;
    public string objName;
    public Sprite icon;
    public string pickUpFeedback;
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
        Feedback.Instance.ShowText(pickUpFeedback, 1.5f);
        Inventory.Instance.AddToInventory(this);
        yield return null;
    }
}
