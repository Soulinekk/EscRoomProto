using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projector : InteractivElement {

    protected override void Start()
    {
        base.Start();
        actualState = States.Closed;
    }

    protected override IEnumerator OnClickAction()
    {
        switch (actualState)
        {
            case States.Closed:
                //Debug.Log(Inventory.Instance.activeElement.objName);
                if (Inventory.Instance.activeElement.objName == "drySlides")
                {
                    Feedback.Instance.ShowText("This goes there", 1.5f);
                    Inventory.Instance.RemoveFromInventory(Inventory.Instance.activeElement);
                    actualState = States.Open;
                    sequenceOn = true;
                }
                else if (Inventory.Instance.activeElement.objName == "wetSlides")
                {
                    Feedback.Instance.ShowText("Slides are still wet", 1.5f);
                }
                else
                {
                    Feedback.Instance.ShowText("That's not a lamp", 1f);
                }
                break;
            case States.Open:

                Feedback.Instance.ShowText("Time for a slide show", 0.7f);
                break;
            /*
            case States.PhaseTwo:
                
                break;
            
    case States.PhaseFour:
        break;
        */
            default:
                break;

        }
        return base.OnClickAction();
    }
}
