using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public static bool interactiveItemClicked = false;

    void Update()                                       //Wysyłanie raycasta z kursora na gre, 
    {                                                   //jezeli jakikolwiek interaktywny element zostanie uderzony, aktywuje sie
        if (Input.GetMouseButtonDown(0))
        {
           
                Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

                //If something was hit, the RaycastHit2D.collider will not be null.
                if (hit.collider != null)
                {
                    InteractivElement intItem = hit.collider.gameObject.GetComponent<InteractivElement>();
                    if (intItem != null)
                    {
                    if (intItem.isInteractive)
                    {
                        
                        intItem.OnClickBehaviour();
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
}