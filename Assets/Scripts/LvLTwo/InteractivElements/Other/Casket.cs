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
                    actualState = States.PhaseTwo;
                    Feedback.Instance.ShowText("one key in", 1.5f, true);
                }
                else if (Inventory.Instance.activeElement.objName == "bKey")
                {
                    actualState = States.PhaseOne;
                    Feedback.Instance.ShowText("one key in", 1.5f, true);
                }
                else
                {
                    Feedback.Instance.ShowText("There are two key holes here",1.5f,true);
                }

                break;
            case States.PhaseOne:
                //if ykey

                break;
            case States.PhaseTwo:
                //if bkey

                break;
            case States.UnBroken:


                break;
            case States.Open:


                break;
            default:

                break;
                
        }

        return base.OnClickAction();
    }
}
