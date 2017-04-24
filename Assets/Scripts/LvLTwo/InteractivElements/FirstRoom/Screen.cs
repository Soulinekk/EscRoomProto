using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen : InteractivElement {

    bool screenClicked;
    bool changephase;
    int slideCounter;
    bool countClick;
    
    protected override void Start()
    {
        
        base.Start();
        screenClicked = false;
        changephase = false;
        actualState = States.Open;
        activatingState = States.Open;
        sequenceSlowerer = 1;
        slideCounter = 0;
        countClick = true;
       
    }
    protected override void FixedUpdate()
    {
        if (FindInReferences("projector").actualState >= States.Open)
        {
             if (Player.interactiveItemClicked)
             {
                 if (countClick)
                 {

                     StartCoroutine(CountClick());

                 }
             }


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
            isInteractive = false;
           if (Player.interactiveItemClicked)
            {
                if (FindInReferences("lamp").actualState == States.PhaseFour)// || FindInReferences("lamp").actualState == States.PhaseFive)
                {
                    //ChangeState();  // jezeli obiekt zmienia sie sekwencyjnie zmienia tez swoj state
                    /*if (actionClickCount % sequenceSlowerer == 0)
                    {
                        if (!screenClicked)
                        {
                            ChangeScreenPhase();
                        }
                        else
                        {
                            changephase = true;
                        }

                    }*/
                }
                else
                {
                    mySpriteRenderer.sprite = darkRoomSprite;
                    actualState = States.DarkRoom;
                    disableHint = true;
                }
                actionClickCount++;
                //np co drugie (2%2 i 4%2 6%2=0) lub co trzecie (3%3 i 6%3 9%3 =0)
            }

            if (actualState == States.Closed || actualState == States.Open)
            {

                actualState = States.DarkRoom;
                mySpriteRenderer.sprite = darkRoomSprite;
                disableHint = true;
            }
            else
            {
                if (FindInReferences("lamp").actualState == States.PhaseFour)// || FindInReferences("lamp").actualState == States.PhaseFive)
                {
                    //Debug.Log(slideCounter);
                    if (actualState == States.PhaseOne)
                    {

                        if (slideCounter % 2 == 1)
                        {
                            actualState = States.PhaseThree;
                            mySpriteRenderer.sprite = avaibleSprites[8];
                        }
                        else
                        {
                            actualState = States.PhaseFive;
                            mySpriteRenderer.sprite = avaibleSprites[12];
                            //get code
                            //hand.gameObject.SetActive()
                            lupa.gameObject.SetActive(false);
                            Feedback.Instance.ShowText("yay got the code !!1!", 3f, true);
                            Inventory.Instance.AddToInventory(hidenItems[0]);
                            PadLock.codeGet = true;
                        }

                    }
                    else if (actualState == States.PhaseTwo)
                    {

                        if (slideCounter % 2 == 1)
                        {

                            actualState = States.PhaseFour;
                            mySpriteRenderer.sprite = avaibleSprites[11];
                        }
                        else
                        {
                            actualState = States.PhaseSix;
                            mySpriteRenderer.sprite = avaibleSprites[15];
                        }
                    }
                }
                else
                {
                    mySpriteRenderer.sprite = darkRoomSprite;
                    actualState = States.DarkRoom;
                    disableHint = true;
                }
            }
        }

       // if (actualState > States.PhaseTwo) {
            // ActivateSequenceCheck();
            
      //  }
    }

    private IEnumerator CountClick()
    {
        countClick = false;
        slideCounter += 1;
        yield return new WaitForFixedUpdate();
        countClick = true;
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
        if (actualState != States.DarkRoom)
        {
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
                        Feedback.Instance.ShowText("It's to bright to see anything", 1.5f,false);

                    }

                    break;
                case States.PhaseTwo:
                    if (avaibleSprites.Length >= 7)
                    {
                        StartCoroutine(AnimSprites(7, 4, 0.15f));
                        actualState = States.PhaseOne;
                        Feedback.Instance.ShowText("It's to bright to see anything", 1.5f,false);

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
        }
       // }
        


       yield return base.OnClickAction();
        
       
    }
    
}
