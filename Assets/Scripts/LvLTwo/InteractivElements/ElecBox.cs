using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElecBox : InteractivElement {
    
    
    protected override void Start()
    {
        base.Start();
        actualState = States.UnBroken;
        activatingState = States.PhaseFour;   //akwarium puste; nienajlepszy sposob na ustawienie tego :p ale nie bede kombinowal teraz
        activationCheck = true;
        feedbackOnly = true;
    }

    protected override void FixedUpdate()
    {
        
        if (sequenceOn)
        {
            StartCoroutine(AnimSprites(0, avaibleSprites.Length-1, 0.3f));
            
            sequenceOn = false;
        }
        base.FixedUpdate();
    }

    protected override IEnumerator AnimSprites(int startSprite, int endSprite, float time)
    {
        
        yield return base.AnimSprites(startSprite, endSprite, time);
        actualState = States.Broken;
    }

    protected override IEnumerator OnClickAction()
    {
        //SequenceOn = true;

        if (isInteractive)
        {
            switch (actualState)
            {
                case States.UnBroken:
                    
                    Feedback.Instance.ShowText("Looks important", 1.5f);
                    break;
                case States.Broken:
                    feedbackOnly = true;
                    Feedback.Instance.ShowText("can't see shit",1f);
                    break;
                default:

                    break;


            }
            
        }
        return base.OnClickAction();
    }
}
