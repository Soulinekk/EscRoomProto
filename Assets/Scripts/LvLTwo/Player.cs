﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public static bool interactiveItemClicked = false;
    public static bool allowInteraction=true;
    public static bool doubleAnim = false;
    public static bool allowClick = true;
    private bool forceFeed=true;
    public void SetForceFeed(bool b)
    {
        forceFeed = b;
    }
    public Button backButton;
    void Update()                                       //Wysyłanie raycasta z kursora na gre, 
    {
        //jezeli jakikolwiek interaktywny element zostanie uderzony, aktywuje sie

        if (!forceFeed)
            allowClick = true;


        if (Input.GetMouseButtonDown(0) && allowClick)
        {
           
                Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

                //If something was hit, the RaycastHit2D.collider will not be null.
                if (hit.collider != null && allowInteraction)
                {
                    InteractivElement intItem = hit.collider.gameObject.GetComponent<InteractivElement>();
                    if (intItem != null)
                    {
                    if (intItem.isInteractive)
                    {
                        StartCoroutine(CountClick(intItem));
                        HintFeedback.lastClickedElement = intItem;
                       // Debug.Log(HintFeedback.lastClickedElement.gameObject.name);
                        intItem.OnClickBehaviour();
                        Inventory.Instance.SetActiveElement(0);
                    }
                    }
                    UseableElement usblItem = hit.collider.gameObject.GetComponent<UseableElement>();
                    if (usblItem != null)
                    {
                    //if (UsblItem.isInteractive)
                    //StartCoroutine(CountClick(usblItem));
                        Wait();
                        usblItem.PickUp();
                    }
                    Zoom zoomItem = hit.collider.gameObject.GetComponent<Zoom>();
                    if(zoomItem != null)
                    {
                         zoomItem.ZoomIn();
                    }
            }

        }
        
    }

    public void Wait()                      ///WAIT BUTTON
    {
        Feedback.Instance.StopAll();
        StartCoroutine(WaitC());
    }

    private IEnumerator WaitC()
    {
        if (Aquarium.sequenceStarted || vaultSec.sequenceStarted)
        {
            backButton.onClick.Invoke();
            yield return new WaitForSeconds(0.4f);
        }
        interactiveItemClicked = true;
        yield return new WaitForFixedUpdate();
        interactiveItemClicked = false;
    }

    private IEnumerator CountClick(InteractivElement item)
    {
        // cam shift
        yield return new WaitForFixedUpdate();
        if (!item.feedbackOnly)
        {
            if (Aquarium.sequenceStarted || vaultSec.sequenceStarted)
            {
                yield return new WaitForSeconds(0.2f);
                backButton.onClick.Invoke();
                yield return new WaitForSeconds(0.4f);
            }
        }
        
        if (!item.feedbackOnly)
        {
            interactiveItemClicked = true;
            //Debug.Log("action!");
            yield return new WaitForFixedUpdate();
            interactiveItemClicked = false;
        }
        yield return null;
    }
}