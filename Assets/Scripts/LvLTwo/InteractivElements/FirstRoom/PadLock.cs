using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadLock : InteractivElement {

    public static bool correctCode;
    public static bool codeGet=false;
    public GameObject CloseUp;
    protected override void Start()
    {
        base.Start();
        activationCheck = false;
        correctCode = false; feedbackOnly = true;
    }
    protected override IEnumerator OnClickAction()
    {
        /*if (Inventory.Instance.activeElement.objName == "code")
        {
            disableHint = true;
            feedbackOnly = true;
            code = true;
            Inventory.Instance.RemoveFromInventory(Inventory.Instance.activeElement);
            Feedback.Instance.ShowText("It Worked", 1.5f, true);
        }
        else
        {
            feedbackOnly = true;
            Feedback.Instance.ShowText("I Need to find code", 2f, true);
        }*/
        if (codeGet)
        {
            Feedback.Instance.ShowText("I hope that code works", 2f, true);
            //CloseUp.SetActive(true);
        }
        else
            Feedback.Instance.ShowText("I need to find a code", 2f, true);
        CloseUp.SetActive(true);

        yield return null;
    }


}
