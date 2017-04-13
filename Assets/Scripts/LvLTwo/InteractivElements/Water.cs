using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : InteractivElement {
    protected override void Start()
    {
        base.Start();
        activatingState = States.Broken;
        sequenceSlowerer = 1;
        
    }

    protected override void FixedUpdate()
    {
        
        base.FixedUpdate();
        if (actualState == States.PhaseTwo && sequenceSlowerer != 2)
            sequenceSlowerer = 2;
        
        if (sequenceOn & actualState == States.UnBroken)
        {
            actualState = States.Broken;
            mySpriteRenderer.sprite = avaibleSprites[1];
            // sequenceOn = false;
        }
    }

    protected override void AdvSeqCheck()
    {
        if (FindInReferences("Akwarium").actualState < States.PhaseFive)
        {
            switch (actualState)
            {
                case States.Broken:
                    if (FindInReferences("DrawerUp").actualState == States.Closed || FindInReferences("DrawerUp").actualState > States.PhaseTwo)
                    {
                        if(Player.interactiveItemClicked)
                            //Feedback.Instance.ShowText("Water still pouring",1.5f,false);
                        base.AdvSeqCheck();
                    }
                    break;
                case States.PhaseOne:
                    if (FindInReferences("DrawerDown").actualState == States.Closed || FindInReferences("DrawerDown").actualState > States.PhaseThree)
                    {
                        base.AdvSeqCheck();
                        if (Player.interactiveItemClicked)
                            Feedback.Instance.ShowText("Water is on the Floor!", 1.5f,false);
                    }
                    break;
                case States.PhaseTwo:
                    {
                        base.AdvSeqCheck();
                        if (Player.interactiveItemClicked)
                            Feedback.Instance.ShowText("The lights will go off, if water get to the electric box!", 1.5f, false);
                        
                    }
                    break;
                default:
                    base.AdvSeqCheck();
                    break;

            }
        }
    }

}
