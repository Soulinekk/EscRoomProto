using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBox : InteractivElement {
    //  public States closingState;                 //dla gornej i dolnej szuflady sa inne closingState'y
    //  private bool closed;
    //private int waterCount;
    protected override void Start()
    {

        base.Start();
        //  closed = false;
        //  activationCheck = true;
        hidenItems[0].gameObject.SetActive(true);
        actualState = States.UnBroken;
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

    protected override IEnumerator OnClickAction()                          // Zachowanie po kliknieciu
    {
        switch (actualState)
        {
            case States.UnBroken:
                feedbackOnly = false;
                Feedback.Instance.ShowText("theres small yellow key here",2f,feedbackOnly);
                actualState = States.Closed;
                hidenItems[0].PickUp();
                break;
            case States.Closed:
                //  if (Inventory.Instance.activeElement.objName == "greyKey") { 
                actualState = States.Open;
                if(hidenItems.Length>1)
                    hidenItems[1].gameObject.SetActive(true);
                
                mySpriteRenderer.sprite = avaibleSprites[0];
                
                //}
                break;
            case States.Open:
                //get hammer
                Feedback.Instance.ShowText("who's keeping his hammer in vault?", 3f, false);
                hidenItems[1].PickUp();
                //closevault
                actualState = States.PhaseOne;

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
