using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadLock : InteractivElement {

    public static bool code;
    protected override void Start()
    {
        base.Start();
        activationCheck = false;
        code = false; feedbackOnly = true;
    }
    protected override IEnumerator OnClickAction()
    {
        if (Inventory.Instance.activeElement.objName == "code")
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
        }
        yield return null;
    }


}
