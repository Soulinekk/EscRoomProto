using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alarm : InteractivElement {
    
    protected override void Start()
    {
        
        base.Start();
        sequenceSlowerer = 1;
        activationCheck = true;
        actualState = States.Closed;
    }

    protected override void AdvSeqCheck()
    {
        if (references[1].actualState != States.PhaseOne)
        {
            if (Player.interactiveItemClicked)
            {
                feedbackOnly = false;
                switch (actualState)
                {

                    case States.Open:
                        Feedback.Instance.ShowText("OPEN VAULT DETECTET", 1.5f, feedbackOnly);
                        Feedback.Instance.ShowText("DOOR CLOSING IN 5 ", 2f, feedbackOnly);

                        break;
                    case States.PhaseOne:

                        Feedback.Instance.ShowText("DOOR CLOSING IN 4 ", 2f, feedbackOnly);

                        break;
                    case States.PhaseTwo:

                        Feedback.Instance.ShowText("DOOR CLOSING IN 3 ", 2f, feedbackOnly);

                        break;
                    case States.PhaseThree:

                        Feedback.Instance.ShowText("DOOR CLOSING IN 2 ", 2f, feedbackOnly);

                        break;
                    case States.PhaseFour:

                        Feedback.Instance.ShowText("DOOR CLOSING IN 1 ", 2f, feedbackOnly);

                        break;
                    case States.PhaseFive:

                        Feedback.Instance.ShowText("DOOR CLOSING NOW ", 2f, feedbackOnly);

                        break;

                    default:

                        break;
                }
                base.AdvSeqCheck();
            }
        }
        else
        {

            if (Player.interactiveItemClicked && sequenceOn)
            {
                vaultSec.sequenceStarted = false;
                sequenceOn = false;
                Feedback.Instance.ShowText("CLOSED VAULT DETECTET", 1.5f, true);
                Feedback.Instance.ShowText("Alarm goes off finally", 2f, true);
                actualState = States.Closed;
                mySpriteRenderer.sprite = avaibleSprites[0];
            }
        }
        
    }

    protected override void FixedUpdate()
    {
       
        base.FixedUpdate();
         if (actualState == States.Open && !sequenceOn)
        {
            sequenceOn = true;
            mySpriteRenderer.sprite = avaibleSprites[1];
        }
    }




    protected override IEnumerator OnClickAction()                          // Zachowanie po kliknieciu
    {
        switch (actualState)
        {
            case States.Closed:
                

                break;

            default:

                break;
                
        }

        return base.OnClickAction();
    }

}
