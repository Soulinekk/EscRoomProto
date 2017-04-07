using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen : InteractivElement {

    protected override void Start()
    {
        base.Start();
        actualState = States.Open;
    }


    protected override IEnumerator OnClickAction()
    {
        if (isInteractive)
        {
            switch (actualState)
            {
                case States.Open:
                    if (avaibleSprites.Length > 1)
                    {
                        StartCoroutine(AnimSprites(0, 3,0.15f));
                        actualState = States.Closed;

                    }
                    break;
                case States.Closed:
                    if (avaibleSprites.Length > 0)
                    {
                        StartCoroutine(AnimSprites(3, 0,0.15f));
                        actualState = States.Open;

                    }
                    break;
                default:

                    break;


            }
        }
        


        return base.OnClickAction();
    }
}
