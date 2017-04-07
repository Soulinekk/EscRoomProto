using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aquarium : InteractivElement {

    
    protected override void Start()
    { 
        base.Start();
        actualState = States.UnBroken;
        hidenItems[0].gameObject.GetComponent<Collider2D>().enabled = false;
    }
    

    protected override IEnumerator OnClickAction()
    {
        switch (actualState)
        {
            case States.UnBroken:
                Debug.Log(Inventory.Instance.activeElement.objName);
                if (Inventory.Instance.activeElement.objName == "mlotek")
                {
                        //mySpriteRenderer.sprite = avaibleSprites[1];
                        actualState = States.Broken;
                        SequenceOn = true;
                    
                    Inventory.Instance.RemoveFromInventory(Inventory.Instance.activeElement);
                }
                else { Feedback.Instance.ShowText("There's glass on top",1.5f); }
                break;
            case States.Broken:
                if (Inventory.Instance.activeElement.objName == "net")
                {
                        actualState = States.PhaseOne;
                        isInteractive = false;
                        Inventory.Instance.AddToInventory(hidenItems[0]);

                    Inventory.Instance.RemoveFromInventory(Inventory.Instance.activeElement);
                }
                else { Feedback.Instance.ShowText("To far to reach by hand", 1.5f); }
                break;
            /*  
        case States.PhaseTwo:
            break;
        case States.PhaseThree:
            break;
        case States.PhaseFour:
            break;
            */
            default:
               /* if (avaibleSprites.Length > 0)  //Close
                    mySpriteRenderer.sprite = avaibleSprites[0];
                actualState = States.UnBroken;*/
                break;

                
        }


        return base.OnClickAction();
    }
}
