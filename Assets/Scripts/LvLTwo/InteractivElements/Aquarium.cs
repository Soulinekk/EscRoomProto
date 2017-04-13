using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aquarium : InteractivElement {

    public static bool sequenceStarted;
    protected override void Start()
    {
        sequenceStarted = false;
        base.Start();
        actualState = States.UnBroken;
        sequenceSlowerer = 2;
        activationCheck = true;
        hidenItems[0].gameObject.GetComponent<Collider2D>().enabled = false;
    }
    protected override void FixedUpdate()
    {
       
        base.FixedUpdate();
    }

    protected override IEnumerator OnClickAction()
    {
        switch (actualState)
        {
            case States.UnBroken:
               // Debug.Log(Inventory.Instance.activeElement.objName);
                if (Inventory.Instance.activeElement.objName == "mlotek")
                {
                    sequenceStarted = true;
                    feedbackOnly = false;
                    //mySpriteRenderer.sprite = avaibleSprites[1];
                    Feedback.Instance.ShowText("Aquarium broke whole! water is pouring out!", 2f, false);
                    actualState = States.Broken;
                        sequenceOn = true;
                    
                    Inventory.Instance.RemoveFromInventory(Inventory.Instance.activeElement);
                }
                else { Feedback.Instance.ShowText("There's glass on top",1.5f,true); }
                break;
            default:
                if (Inventory.Instance.activeElement.objName == "net")
                {
                    feedbackOnly = false;
                       // actualState = States.PhaseOne;
                        //isInteractive = false;
                        hidenItems[0].PickUp();
                    hidenItems = new UseableElement[0];                        //Inventory.Instance.AddToInventory(hidenItems[0]);
                    Feedback.Instance.ShowText("i need to dry these slides", 2f, false);
                    Inventory.Instance.RemoveFromInventory(Inventory.Instance.activeElement);
                }
                else {
                    if (hidenItems.Length < 1)
                    {
                        feedbackOnly = true;
                        Feedback.Instance.ShowText("nothing else is here",1.5f,true);
                    }
                    else
                    {
                        feedbackOnly = true;
                        Feedback.Instance.ShowText("To far to reach by hand", 1.5f,true);
                    }
                }
                break;
            /* 
        case States.PhaseTwo:
            break;
        case States.PhaseThree:
            break;
        case States.PhaseFour:
            break;
            */
            

                
        }


        return base.OnClickAction();
    }
}
