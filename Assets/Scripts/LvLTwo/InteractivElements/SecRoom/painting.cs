using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class painting : InteractivElement {
   // public Zoom oldArea;
 //   public Zoom newArea;
    protected override void Start()
    {

        base.Start();
        //  closed = false;
        //  activationCheck = true;
       // foreach (UseableElement obj in hidenItems)
            //obj.gameObject.SetActive(false);
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

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if(!mySpriteRenderer.enabled)
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
    protected override IEnumerator OnClickAction()                          // Zachowanie po kliknieciu
    {
        switch (actualState)
        {
            case States.Closed:
                feedbackOnly = false;
                //actualState = States.Open;
                //gameObject.SetActive(false);
              //  gameObject.SetActive(false);
                mySpriteRenderer.enabled = false;
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                references[1].gameObject.SetActive(true);       //vault
               // oldArea.ZoomOut();
              //  oldArea.gameObject.SetActive(false); //old zoomArea
              //  newArea.gameObject.SetActive(true); //new zoomarea
                
              //  newArea.ZoomIn();

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

