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
    protected InteractivElement mainLamp;

    protected virtual void Start()
    {
        mainLamp = GameObject.Find("mainLamp").GetComponent<InteractivElement>();
        picked = false;
    }
    protected void FixedUpdate()
    {
        if (mainLamp.actualState == InteractivElement.States.Broken)
        {
            gameObject.SetActive(false);
        }
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
