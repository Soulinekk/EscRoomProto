using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : InteractivElement {
    protected override void Start()
    {
        base.Start();
        activationCheck = true;
        actualState = States.Closed;
        //sequenceSlowerer = 1;
    }

    protected override void FixedUpdate()
    {
        if (actionClickCount == 7)
        {
            sequenceOn = false;
            actualState = States.Broken;
            actionClickCount = 0;

        }
        base.FixedUpdate();
    }
    protected override void DarkRoomCheck()
    {
       
    }

    protected override IEnumerator OnClickAction()
    {
        switch (actualState)
        {
            case States.Closed:
                //Debug.Log(Inventory.Instance.activeElement.objName);
                if (Inventory.Instance.activeElement.objName == "bulb")
                {
                    feedbackOnly = false;
                    Feedback.Instance.ShowText("Doesn't fit well, but it works", 1.5f);
                    actualState = States.Open;
                    sequenceOn = true;
                    actionClickCount = 0;
                    Inventory.Instance.RemoveFromInventory(Inventory.Instance.activeElement);
                }
                else
                {
                    feedbackOnly = true;
                    Feedback.Instance.ShowText("That's a lamp", 1f);
                }
                break;
            case States.Open:
                feedbackOnly = true;
                Feedback.Instance.ShowText("it need to heat up to give some light", 0.7f);
                break;
            


            case States.Broken:
                feedbackOnly = true;
                Feedback.Instance.ShowText("well... i need new bulb", 0.7f);

                break;
            
            case States.PhaseFive:
                Feedback.Instance.ShowText("light comming out, but bulb its still heating up",2f);

                break;
            
    case States.PhaseFour:
                Feedback.Instance.ShowText("Heated up, light comming out",2f);
                break;
        
            default:
                Feedback.Instance.ShowText("It's heating up", 0.7f);
                sequenceOn = true;
                break;

        }
        return base.OnClickAction();
    }
}
