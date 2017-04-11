using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen : InteractivElement {

    bool screenClicked;
    bool changephase;
    protected override void Start()
    {
        base.Start();
        screenClicked = false;
        changephase = false;
        actualState = States.Open;
        activatingState = States.Open;
        sequenceSlowerer = 2;
        
        
    }
    protected override void FixedUpdate()
    {
        if (FindInReferences("projector").actualState == States.Open)
        {
            if (actualState == States.Closed)
            {
                actualState = States.PhaseTwo;
                mySpriteRenderer.sprite = avaibleSprites[7];
            }
            if (actualState == States.Open)
            {
                actualState = States.PhaseOne;
                mySpriteRenderer.sprite = avaibleSprites[4];
            }
        }

        if (references[0].actualState == States.Broken)
        {
            if (actualState == States.Closed || actualState == States.Open)
            {
                actualState = States.DarkRoom;
                mySpriteRenderer.sprite = darkRoomSprite;
            }
            if(actualState == States.PhaseOne)
            {
                actualState = States.PhaseThree;
                mySpriteRenderer.sprite = avaibleSprites[8];
            }
            if (actualState == States.PhaseTwo)
            {
                actualState = States.PhaseFour;
                mySpriteRenderer.sprite = avaibleSprites[11];
            }
        }

        if (actualState > States.PhaseTwo) {
            // ActivateSequenceCheck();
            if (Player.interactiveItemClicked)
            {
                //ChangeState();  // jezeli obiekt zmienia sie sekwencyjnie zmienia tez swoj state
                if (actionClickCount % sequenceSlowerer == 0)
                {
                    if (!screenClicked)
                    {
                        ChangeScreenPhase();
                    }
                    else
                    {
                        changephase = true;
                    }

                }
                actionClickCount++;
                //np co drugie (2%2 i 4%2 6%2=0) lub co trzecie (3%3 i 6%3 9%3 =0)
            }
        }
    }
    protected override IEnumerator AnimSprites(int startSprite, int endSprite, float time)
    {
        yield return base.AnimSprites(startSprite, endSprite, time);
        yield return new WaitForFixedUpdate();
        if (changephase)
        {
            changephase = false;
            ChangeScreenPhase();
        }
        screenClicked = false;
    }

    void ChangeScreenPhase()
    {
        if (actualState == States.PhaseThree)
        {
            actualState = States.PhaseFive;
            mySpriteRenderer.sprite = avaibleSprites[12];
        }
        else if (actualState == States.PhaseFive)
        {
            actualState = States.PhaseThree;
            mySpriteRenderer.sprite = avaibleSprites[8];
        }
        else if (actualState == States.PhaseFour)
        {
            actualState = States.PhaseSix;
            mySpriteRenderer.sprite = avaibleSprites[15];
        }
        else if (actualState == States.PhaseSix)
        {
            mySpriteRenderer.sprite = avaibleSprites[11];
            actualState = States.PhaseFour;
        }
    }

    protected override IEnumerator OnClickAction()
    {
        //if (isInteractive)
        // {

        screenClicked = true;
            switch (actualState)
            {
                case States.Open:                                   //mainlight on , no slides
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
                case States.PhaseOne:                                   //mainlight on slides on

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
                case States.PhaseThree:                                 //light of ,slides & bulb on - slide 1
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
                case States.PhaseFive:                                  //light of ,slides & bulb on - slide 2
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
       // }
        


       yield return base.OnClickAction();
        
       
    }
    
}
