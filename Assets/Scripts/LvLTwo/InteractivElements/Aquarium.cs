using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aquarium : InteractivElement {


    protected override void Start()
    { 
        base.Start();
        actualState = States.UnBroken;
    }
    /*protected override*/ void Update()
    {
        if (Player.interactiveItemClicked)
        {
            Debug.Log("aqua helou");
        }
    }

    protected override IEnumerator OnClickAction()
    {
        switch (actualState)
        {
            case States.UnBroken:
                Debug.Log(Inventory.Instance.activeElement.objName);
                if (Inventory.Instance.activeElement.objName == "mlotek")
                {
                    if (avaibleSprites.Length > 1)
                    { //Open no water
                        mySpriteRenderer.sprite = avaibleSprites[1];
                        actualState = States.Broken;
                        isInteractive = false;
                    }
                    Inventory.Instance.RemoveFromInventory(Inventory.Instance.activeElement);
                }
                else { Debug.Log("Can't reach through glass"); }
                break;
            /*                      Reszta nie jest interaktywna
            case States.PhaseOne:

                break;
            case States.PhaseTwo:
                break;
            case States.PhaseThree:
                break;
            case States.PhaseFour:
                break;
                */
            default:
                Debug.Log("nothin");
               /* if (avaibleSprites.Length > 0)  //Close
                    mySpriteRenderer.sprite = avaibleSprites[0];
                actualState = States.UnBroken;*/
                break;

                
        }


        return base.OnClickAction();
    }
}
