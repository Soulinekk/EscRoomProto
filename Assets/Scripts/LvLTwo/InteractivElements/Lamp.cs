using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : InteractivElement {
    protected override void Start()
    {
        base.Start();
        actualState = States.Closed;
    }

    protected override void FixedUpdate()
    {
        if (actionClickCount == 5)
        {
            SequenceOn = false;
            actualState = States.Broken;
            actionClickCount = 0;

        }
        base.FixedUpdate();
    }

    protected override IEnumerator OnClickAction()
    {
        switch (actualState)
        {
            case States.Closed:
                //Debug.Log(Inventory.Instance.activeElement.objName);
                if (Inventory.Instance.activeElement.objName == "bulb")
                {
                    Feedback.Instance.ShowText("Doesn't fit well, but it works", 1.5f);
                    actualState = States.Open;
                    SequenceOn = true;
                }
                else
                {
                    Feedback.Instance.ShowText("That's a lamp", 1f);
                }
                break;
            case States.Open:

                Feedback.Instance.ShowText("Looks fine", 0.7f);
                break;

            case States.Broken:
                Feedback.Instance.ShowText("meh... still Looks fine", 0.7f);

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
