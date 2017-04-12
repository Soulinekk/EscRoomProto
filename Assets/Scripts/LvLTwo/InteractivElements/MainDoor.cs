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
        code = false;
    }
    protected override IEnumerator OnClickAction()
    {
        if (code)
        {
            Feedback.Instance.ShowText("CONGRATULATION", 10);
        }
        else
        {
            Feedback.Instance.ShowText("I Need to find code",2f);
        }
        yield return null; 
    }
}
