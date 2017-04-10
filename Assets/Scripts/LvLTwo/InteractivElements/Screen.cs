using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen : InteractivElement {

    protected override void Start()
    {
        base.Start();
        actualState = States.Open;
        activatingState = States.Open;
        sequenceSlowerer = 2;
        
        
    }
    protected override void FixedUpdate()
    {
       /* if (sequenceOn && actualState== States.Open|| actualState == States.Closed)
        {
            if (mainLamp.actualState == States.UnBroken)
            {
                actualState = States.PhaseOne;
                if (mySpriteRenderer.sprite == avaibleSprites[0])
                    mySpriteRenderer.sprite = avaibleSprites[7];
                else
                    mySpriteRenderer.sprite = avaibleSprites[4];
            }
            else
            {
                actualState = States.PhaseThree;
                if (mySpriteRenderer.sprite == avaibleSprites[0])
                    mySpriteRenderer.sprite = avaibleSprites[11];
                else
                    mySpriteRenderer.sprite = avaibleSprites[8];
            }



            sequenceOn = false;
        }
        
        if (Player.interactiveItemClicked && sequenceOn)
        {
            if (actionClickCount % sequenceSlowerer == 0)
                switch (actualState)
                {
                    case States.PhaseThree:
                        actualState = States.PhaseFive;
                        mySpriteRenderer.sprite = avaibleSprites[8];
                        break;
                    case States.PhaseFour:
                        actualState = States.PhaseSix;
                        mySpriteRenderer.sprite = avaibleSprites[15];
                        break;
                    case States.PhaseFive:
                        actualState = States.PhaseThree;
                        mySpriteRenderer.sprite = avaibleSprites[12];
                        break;
                    case States.PhaseSix:
                        actualState = States.PhaseFour;
                        mySpriteRenderer.sprite = avaibleSprites[11];

                        break;
                    default:
                        break;
                }

            actionClickCount++;
        }*/
    }
    

    protected override IEnumerator OnClickAction()
    {
        if (isInteractive)
        {
            switch (actualState)
            {
                case States.Open:
                    if (avaibleSprites.Length >= 3)
                    {
                        StartCoroutine(AnimSprites(0, 3, 0.15f));
                        actualState = States.Closed;

                    }
                    break;
                case States.Closed:
                    if (avaibleSprites.Length >= 3)
                    {
                        StartCoroutine(AnimSprites(3, 0, 0.15f));
                        actualState = States.Open;

                    }
                    break;
                case States.PhaseOne:

                    if (avaibleSprites.Length >= 7)
                    {
                        StartCoroutine(AnimSprites(4, 7, 0.15f));
                        actualState = States.PhaseTwo;

                    }          

                    break;
                case States.PhaseTwo:
                    if (avaibleSprites.Length >= 7)
                    {
                        StartCoroutine(AnimSprites(7, 4, 0.15f));
                        actualState = States.PhaseOne;

                    }
                    break;
                case States.PhaseThree:
                    if (avaibleSprites.Length >= 11)
                    {
                        StartCoroutine(AnimSprites(8, 11, 0.15f));
                        actualState = States.PhaseFour;

                    }
                    break;
                case States.PhaseFour:
                    if (avaibleSprites.Length >= 11)
                    {
                        StartCoroutine(AnimSprites(11, 8, 0.15f));
                        actualState = States.PhaseThree;

                    }
                    break;
                case States.PhaseFive:
                    if (avaibleSprites.Length >= 15)
                    {
                        StartCoroutine(AnimSprites(12, 15, 0.15f));
                        actualState = States.PhaseSix;

                    }
                    break;
                case States.PhaseSix:
                    if (avaibleSprites.Length >= 15)
                    {
                        StartCoroutine(AnimSprites(15, 12, 0.15f));
                        actualState = States.PhaseFive;

                    }
                    break;
                default:

                    break;


            }
        }
        


        return base.OnClickAction();
    }
}
