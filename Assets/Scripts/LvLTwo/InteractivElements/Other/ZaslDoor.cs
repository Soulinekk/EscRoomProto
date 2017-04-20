using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZaslDoor : InteractivElement {
    protected override void FixedUpdate()
    {
        {
            if (actualState == States.Broken)
            {
                mySpriteRenderer.sprite = avaibleSprites[0];
            }
        }
    }

}
