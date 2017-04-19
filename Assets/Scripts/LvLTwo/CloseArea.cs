using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseArea : InteractivElement
{

    protected override IEnumerator OnClickAction()
    {
        gameObject.SetActive(false);
        yield return base.OnClickAction();
    }
}
