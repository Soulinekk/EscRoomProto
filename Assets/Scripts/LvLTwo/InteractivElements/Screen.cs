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
        base.FixedUpdate();
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
