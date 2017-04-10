using System.Collections;
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
                    actualState = States.PhaseOne;
                    Feedback.Instance.ShowText("Good spot for drying", 1.5f);
                    hidenItems[0].gameObject.SetActive(true);
                    sequenceOn = true;
                    actionClickCount = 0;
                    Inventory.Instance.RemoveFromInventory(Inventory.Instance.activeElement);
                }
                else
                {
                    Feedback.Instance.ShowText("mhhhh... warm", 1.5f);
                }
                break;
            case States.Open:
                
                break;
              
        case States.PhaseOne:
                Feedback.Instance.ShowText("Still Drying",1f);
            break;
                
        case States.PhaseTwo:
                Feedback.Instance.ShowText("Nice and dry", 1f);
                hidenItems[0].PickUp();
                actualState = States.Closed;
                break;
                /*
        case States.PhaseFour:
            break;
            */
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
