using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poduszka : InteractivElement
{
    //  public States closingState;                 //dla gornej i dolnej szuflady sa inne closingState'y
    //  private bool closed;
    //private int waterCount;
    protected override void Start()
    {

        base.Start();
        //  closed = false;
        //  activationCheck = true;
        foreach (UseableElement obj in hidenItems)
            obj.gameObject.SetActive(false);
        actualState = States.Closed;
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
            case States.Closed:
                feedbackOnly = false;
                actualState = States.Open;
                gameObject.transform.position = transform.position - new Vector3(0f, 1f, 0f);
                foreach (UseableElement obj in hidenItems)
                    obj.gameObject.SetActive(true);
                break;
            case States.Open:
                feedbackOnly = false;
                
                actualState = States.Closed;
                gameObject.transform.position = transform.position - new Vector3(0f, -1f, 0f);
                foreach (UseableElement obj in hidenItems)
                    obj.gameObject.SetActive(false);
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
