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
                    Feedback.Instance.ShowText("Doesn't fit well, but it works", 1.5f,true);
                    actualState = States.Open;
                    sequenceOn = true;
                    actionClickCount = 0;
                    Inventory.Instance.RemoveFromInventory(Inventory.Instance.activeElement);
                }
                else
                {
                    feedbackOnly = true;
                    Feedback.Instance.ShowText("That's a lamp", 1f,true);
                }
                break;
            case States.Open:
                feedbackOnly = true;
                Feedback.Instance.ShowText("it need to heat up to give some light", 2f,true);
                break;
            


            case States.Broken:
                feedbackOnly = true;
                Feedback.Instance.ShowText("well... i need new bulb", 1.5f,true);

                break;
            
            case States.PhaseFive:
                feedbackOnly = true;
                Feedback.Instance.ShowText("light comming out, but bulb its still heating up",2f,true);

                break;
            
    case States.PhaseFour:
                feedbackOnly = true;
                Feedback.Instance.ShowText("Heated up, light comming out",2f,true);
                break;
        
            default:
                feedbackOnly = true;
                Feedback.Instance.ShowText("It's heating up", 1f,true);
                sequenceOn = true;
                break;

        }
        return base.OnClickAction();
    }
    protected override void AdvanceSequence()
    {
        base.AdvanceSequence();
        if (actualState == States.PhaseThree)
            Feedback.Instance.ShowText("bulb heated up theres light coming out", 2f, false);
        if (actualState == States.PhaseFour)
            Feedback.Instance.ShowText("bulb looks like its about to break", 2f, false);
        if (actualState == States.PhaseFive)
            Feedback.Instance.ShowText("bulb in lamp broke, hope it wasnt important", 2f, false);
    }
}
