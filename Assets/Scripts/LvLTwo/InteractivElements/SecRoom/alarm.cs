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
                        Feedback.Instance.ShowText("OPEN VAULT DETECTET", 1f, feedbackOnly);
                        Feedback.Instance.ShowText("DOOR CLOSING IN 5", 1f, feedbackOnly);

                        break;
                    case States.PhaseOne:

                        Feedback.Instance.ShowText("DOOR CLOSING IN 4", 1f, feedbackOnly);

                        break;
                    case States.PhaseTwo:

                        Feedback.Instance.ShowText("DOOR CLOSING IN 3", 1f, feedbackOnly);

                        break;
                    case States.PhaseThree:

                        Feedback.Instance.ShowText("DOOR CLOSING IN 2", 1f, feedbackOnly);

                        break;
                    case States.PhaseFour:
                        vaultSec.sequenceStarted = true;
                        Feedback.Instance.ShowText("DOOR CLOSING IN 1", 1f, feedbackOnly);

                        break;
                    case States.PhaseFive:
                        
                        sequenceOn = false;
                        Feedback.Instance.ShowText("DOOR CLOSED", 1f, feedbackOnly);
                        references[2].actualState = States.Broken;
                        references[3].actualState = States.Broken;
                        references[4].actualState = States.Broken;
                        references[5].actualState = States.Broken;
                        actualState = States.Closed;
                        vaultSec.sequenceStarted = false;

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
                Feedback.Instance.ShowText("CLOSED VAULT DETECTET", 1f, true);
                Feedback.Instance.ShowText("Alarm goes off finally", 1.5f, true);
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
            
            default:
                feedbackOnly = true;
                Feedback.Instance.ShowText("Big red bulb", 1f, true);
                break;
                
        }

        return base.OnClickAction();
    }

}
