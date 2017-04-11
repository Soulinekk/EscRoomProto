using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : InteractivElement {
    protected override void Start()
    {
        base.Start();
        activatingState = States.Broken;
        sequenceSlowerer = 2;
        
    }

    protected override void FixedUpdate()
    {
        
        base.FixedUpdate();
        if (sequenceOn & actualState == States.UnBroken)
        {
            actualState = States.Broken;
            mySpriteRenderer.sprite = avaibleSprites[1];
            // sequenceOn = false;
        }
    }

    protected override void AdvSeqCheck()
    {
        if(FindInReferences("Akwarium").actualState< States.PhaseThree)
        switch (actualState)
        {
            case States.Broken:
                if (FindInReferences("DrawerUp").actualState == States.Closed || FindInReferences("DrawerUp").actualState > States.PhaseOne)
                {
                    base.AdvSeqCheck();
                }
                break;
            case States.PhaseOne:
                if (FindInReferences("DrawerDown").actualState == States.Closed || FindInReferences("DrawerDown").actualState > States.PhaseTwo)
                {
                    base.AdvSeqCheck();
                }
                break;
            default:
                base.AdvSeqCheck();
                break;

        }
    }

}
