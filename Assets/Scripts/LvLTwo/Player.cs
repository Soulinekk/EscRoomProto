using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public static bool interactiveItemClicked = false;
    public static bool allowInteraction=true;
    public static bool doubleAnim = false;
    void Update()                                       //Wysyłanie raycasta z kursora na gre, 
    {                                                   //jezeli jakikolwiek interaktywny element zostanie uderzony, aktywuje sie
        if (Input.GetMouseButtonDown(0))
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
                       
                        intItem.OnClickBehaviour();
                        Inventory.Instance.SetActiveElement(0);
                    }
                    }
                    UseableElement usblItem = hit.collider.gameObject.GetComponent<UseableElement>();
                    if (usblItem != null)
                    {
                       //if (UsblItem.isInteractive)
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

    private IEnumerator CountClick(InteractivElement item)
    {
        yield return new WaitForFixedUpdate();
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