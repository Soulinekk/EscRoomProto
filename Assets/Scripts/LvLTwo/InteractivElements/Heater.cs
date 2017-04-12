﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heater : InteractivElement {

	protected override void Start()
    {
        base.Start();
        actualState = States.Closed;
        //SequenceOn = true;
        StartCoroutine(AnimSprites(0, 1,0.2f));
        hidenItems[0].gameObject.SetActive(false);

    }
    protected override void FixedUpdate()
    {
        if (actionClickCount == 2)
        {
            sequenceOn = false;
            actualState = States.PhaseTwo;
            actionClickCount = 0;

        }
        base.FixedUpdate();
    }

    protected override IEnumerator OnClickAction()
    {

        switch (actualState)
        {
            case States.Closed:
                //Debug.Log(Inventory.Instance.activeElement.objName);
                if (Inventory.Instance.activeElement.objName == "wetSlides")
                {
                    //mySpriteRenderer.sprite = avaibleSprites[1];
                    if (FindInReferences("water").actualState < States.PhaseThree)
                    {
                        actualState = States.Open;
                        Feedback.Instance.ShowText("Good spot for drying", 1.5f);
                        hidenItems[0].gameObject.SetActive(true);
                        sequenceOn = true;
                        actionClickCount = 0;
                        Inventory.Instance.RemoveFromInventory(Inventory.Instance.activeElement);
                    }
                    else {
                        Feedback.Instance.ShowText("To late for that!", 2f);
                    }
                }
                else
                {
                    Feedback.Instance.ShowText("mhhhh... warm", 1.5f);
                }
                break;
            case States.Open:
                Feedback.Instance.ShowText("Still Drying", 2f);
                break; 
              
        case States.PhaseOne:
                Feedback.Instance.ShowText("Still Drying",2f);
            break;
                
        case States.PhaseTwo:
                if (FindInReferences("water").actualState < States.PhaseThree)
                {
                    Feedback.Instance.ShowText("Nice and dry", 2f);
                    hidenItems[0].PickUp();
                    actualState = States.Closed;
                    //break;
                }
                else
                    Feedback.Instance.ShowText("Its not going to dry now",3);
                       //------------------------------ //RESTART-----------------------------------
                break;
                    
                
        //case States.PhaseThree:

          //  break;
            
            default:
                break;

        }

                return base.OnClickAction();
        
    }

    protected override IEnumerator AnimSprites(int startSprite, int endSprite,float time)
    {

        // yield return base.AnimSprites(startSprite, endSprite,time);
        // yield return AnimSprites(endSprite, startSprite,time);
        yield return null;
    }
}
