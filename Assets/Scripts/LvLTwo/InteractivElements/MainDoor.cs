using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainDoor : InteractivElement
{
    public static bool code;
    protected override void Start()
    {
        base.Start();
        activationCheck = false;
        code = false; feedbackOnly = true;
    }
    protected override IEnumerator OnClickAction()
    {
        if (code)
        {
            feedbackOnly = true;
            Feedback.Instance.ShowText("CONGRATULATION", 10f,true);
        }
        else
        {
            feedbackOnly = true;
            Feedback.Instance.ShowText("I Need to find code",2f,true);
        }
        yield return null; 
    }
}
