using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heater : InteractivElement {

	protected override void Start()
    {
        base.Start();
        actualState = States.Closed;
        SequenceOn = true;
        StartCoroutine(AnimSprites(0, 1,0.2f));

    }
    protected override IEnumerator AnimSprites(int startSprite, int endSprite,float time)
    {

        yield return base.AnimSprites(startSprite, endSprite,time);
        yield return AnimSprites(endSprite, startSprite,time);
    }
}
