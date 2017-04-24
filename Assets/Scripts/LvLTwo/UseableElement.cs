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
    public string onClickFeedback;
    protected InteractivElement mainLamp;
    HintItem hand;

    public bool interactive=false;
    public bool feedbackOnlyUseable;
    public GameObject closeUp;

    public void OpenCloseUp()  //dla interaktywnych
    {
        if (closeUp != null)
        {
            closeUp.SetActive(true);
        }
    }
    public void GiveFeedback()
    {
        if(onClickFeedback!="")
            Feedback.Instance.ShowText(onClickFeedback, 2f, true);
    }



    protected virtual void Start()
    {
        //interactive = false;
        //showItemParticles = gameObject.GetComponentInChildren<ParticleSystem>().gameObject;
        hand = gameObject.GetComponentInChildren<HintItem>();
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
        //Feedback.Instance.ShowText(pickUpFeedback, 1.5f);
        picked = true;
        if(hand!=null)
            hand.gameObject.SetActive(false);
        Inventory.Instance.AddToInventory(this);
        Feedback.Instance.ShowText(this.name, 1f,true);
        yield return null;
    }

}
