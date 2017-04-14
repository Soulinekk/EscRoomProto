using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainDoor : InteractivElement
{
    protected override void Start()
    {
        base.Start();
        activationCheck = false;
        
    }
    protected override IEnumerator OnClickAction()
    {
        if (PadLock.code)
        {
            feedbackOnly = true;
            Feedback.Instance.ShowText("CONGRATULATION", 10f,true);
        }
        else
        {
            feedbackOnly = true;
            Feedback.Instance.ShowText("It's Locked",2f,true);
        }
        yield return null; 
    }
}
