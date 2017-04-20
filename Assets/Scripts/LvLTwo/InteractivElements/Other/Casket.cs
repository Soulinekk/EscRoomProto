using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casket : InteractivElement
{
    protected override void Start()
    {
        base.Start();
        actualState = States.Closed;
    }
    

    protected override void FixedUpdate()
    {
        
    }
    protected override IEnumerator OnClickAction()                          // Zachowanie po kliknieciu
    {
        switch (actualState)
        {
            case States.Closed:
                if(Inventory.Instance.activeElement.objName == "yKey")
                {
                    feedbackOnly = false;
                    actualState = States.PhaseTwo;
                    Feedback.Instance.ShowText("one key in", 1.5f, true);
                    Inventory.Instance.RemoveFromInventory(Inventory.Instance.activeElement);
                    mySpriteRenderer.sprite = avaibleSprites[1];

                }
                else if (Inventory.Instance.activeElement.objName == "bKey")
                {
                    feedbackOnly = false;
                    actualState = States.PhaseOne;
                    Feedback.Instance.ShowText("one key in", 1.5f, true);
                    Inventory.Instance.RemoveFromInventory(Inventory.Instance.activeElement);
                    mySpriteRenderer.sprite = avaibleSprites[2];
                }
                else
                {
                    feedbackOnly = true;
                    Feedback.Instance.ShowText("There are two key holes here",1.5f,true);
                }

                break;
            case States.PhaseOne:
                //if ykey
                if (Inventory.Instance.activeElement.objName == "yKey")
                {
                    feedbackOnly = false;
                    actualState = States.UnBroken;
                    Feedback.Instance.ShowText("both keys in", 1.5f, true);
                    Inventory.Instance.RemoveFromInventory(Inventory.Instance.activeElement);
                    mySpriteRenderer.sprite = avaibleSprites[4];
                    hidenItems[0].gameObject.SetActive(true);

                }

                    break;
            case States.PhaseTwo:
                //if bkey
                if (Inventory.Instance.activeElement.objName == "bKey")
                {
                    feedbackOnly = false;
                    actualState = States.UnBroken;
                    Feedback.Instance.ShowText("both keys in", 1.5f, true);
                    Inventory.Instance.RemoveFromInventory(Inventory.Instance.activeElement);
                    mySpriteRenderer.sprite = avaibleSprites[4];
                    hidenItems[0].gameObject.SetActive(true);
                }

                break;
            case States.UnBroken:
                actualState = States.Open;
                hidenItems[0].PickUp();
                
                Inventory.Instance.RemoveFromInventory(hidenItems[1]);
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                
               
                break;
            case States.Open:


                break;
            default:

                break;
                
        }

        return base.OnClickAction();
    }
}
