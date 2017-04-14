using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : InteractivElement {

    public States closingState;                 //dla gornej i dolnej szuflady sa inne closingState'y
    private bool closed;
    //private int waterCount;
    protected override void Start()
    {
        
        base.Start();
        closed = false;
        activationCheck = true;
        foreach (UseableElement obj in hidenItems)
            obj.gameObject.SetActive(false);
        actualState = States.Closed;
    }
    protected override void ActivateSequenceCheck()
    {
        if (FindInReferences("water").actualState == closingState-1 && actualState >= States.Open)
            sequenceOn = true;
    }
    protected override void AdvanceSequence()
    {
        base.AdvanceSequence();
        sequenceOn = false;
    }

    protected override IEnumerator OnClickAction()                          // Zachowanie po kliknieciu
    {
        switch (actualState)
        {
            case States.Closed:
                if (!closed && FindInReferences("water").actualState < closingState)
                {
                    if (avaibleSprites.Length > 1)
                    { //Open no water
                        mySpriteRenderer.sprite = avaibleSprites[1];
                        gameObject.GetComponent<Collider2D>().offset = new Vector2(-0.2f, -0.15f);
                        actualState = States.Open;
                        foreach (UseableElement obj in hidenItems)
                        {
                            if (!obj.picked)
                                obj.gameObject.SetActive(true);
                        }

                    }
                }
                else
                {
                    feedbackOnly = true;
                    closed = true;
                    Feedback.Instance.ShowText("Unrechable...", 1.5f,true);
                }
                break;
            default:
                if (avaibleSprites.Length > 0 && actualState!= States.DarkRoom)
                {  //Close
                    sequenceOn = false;
                    if (FindInReferences("Akwarium").actualState >= closingState)
                    {
                        lupa.gameObject.SetActive(false);
                        closed = true;
                    }
                    mySpriteRenderer.sprite = avaibleSprites[0];
                    gameObject.GetComponent<Collider2D>().offset = new Vector2(0.16f, 0.16f);
                    actualState = States.Closed;
                    foreach (UseableElement obj in hidenItems)
                    {
                        if (!obj.picked)
                            obj.gameObject.SetActive(false);
                    }
                }
                break;
           /*
            case States.Phase
                break;
            case States.WaterTwoThirds:
                break;*/
        }

        return base.OnClickAction();
    }
}
