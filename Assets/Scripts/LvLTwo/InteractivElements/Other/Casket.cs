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
                

                break;
            case States.PhaseOne:


                break;
            case States.PhaseTwo:


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
