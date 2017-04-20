using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vaultSec : InteractivElement
{
    public static bool sequenceStarted;
    protected override void Start()
    {
        sequenceStarted = false;
        base.Start();
        //  closed = false;
        //  activationCheck = true;
        // foreach (UseableElement obj in hidenItems)
        //obj.gameObject.SetActive(false);
        actualState = States.Closed;
        gameObject.SetActive(false);
    }
    /* protected override void ActivateSequenceCheck()
     {
         if (FindInReferences("water").actualState == closingState - 1 && actualState >= States.Open)
             sequenceOn = true;
     }*/
    /*  protected override void AdvanceSequence()
      {
          base.AdvanceSequence();
          sequenceOn = false;
      }*/

    protected override void FixedUpdate()
    {
        if(references[1].actualState == States.PhaseOne && actualState!= States.PhaseOne)
        {
            actualState = States.PhaseOne;
            mySpriteRenderer.sprite = avaibleSprites[0];
            references[1].gameObject.SetActive(false);
        }
        base.FixedUpdate();
        if(actualState == States.Open)
            gameObject.GetComponent<Collider2D>().enabled = false;
    }
    protected override IEnumerator OnClickAction()                          // Zachowanie po kliknieciu
    {
        switch (actualState)
        {
            case States.Closed:
               
                
                if (Inventory.Instance.activeElement.objName == "vaultwheel")
                {
                    feedbackOnly = false;
                    actualState = States.UnBroken;
                    mySpriteRenderer.sprite = avaibleSprites[0];
                    Inventory.Instance.RemoveFromInventory(Inventory.Instance.activeElement);
                    //gameObject.GetComponent<BoxCollider2D>().enabled = false;
                   
                }
                else
                {
                    feedbackOnly = true;
                    Feedback.Instance.ShowText("its missing a wheel", 2f, feedbackOnly);
                }
                break;
            case States.UnBroken:
                actualState = States.Open;
                //ALARM ON
               
                feedbackOnly = false;
                Feedback.Instance.ShowText("Oh no I turned on the alarm", 2f, feedbackOnly);
                
                references[2].actualState = States.Open;
                mySpriteRenderer.sprite = avaibleSprites[1];
                //show box show key
                hidenItems[0].gameObject.SetActive(true);
                if (references.Count > 1)
                    references[1].gameObject.SetActive(true); /// box}\
                break;
            case States.PhaseOne:
                feedbackOnly = true;
                Feedback.Instance.ShowText("Better not to open again, alarm is off", 2f, feedbackOnly);
                
                break;
            default:

                break;
                /*
                 case States.Phase
                     break;
                 case States.WaterTwoThirds:
                     break;*/
        }

        return base.OnClickAction();
    }

}
