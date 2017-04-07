using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractivElement : MonoBehaviour
{
    //Its copy of interactiveItem.cs from 1lvl for clear 2lvl hierarchy 
    [HideInInspector]
    public bool isInteractive;
    
    protected Collider c;
    protected SpriteRenderer mySpriteRenderer;
    public Sprite[] avaibleSprites;
    protected bool SequenceOn;

    protected int actionClickCount;
    public UseableElement[] hidenItems;

    protected enum States {Open, Closed,UnBroken, Broken, PhaseOne, PhaseTwo, PhaseThree, PhaseFour };
    protected States actualState;

    protected virtual void Start()
    {
        SequenceOn = false;
        isInteractive = true;
        actualState = States.UnBroken;
        c = gameObject.GetComponent<Collider>();
        mySpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    protected virtual void FixedUpdate()
    {
        if (Player.interactiveItemClicked && SequenceOn)
        {
            AdvanceSequence();
            actionClickCount++;
        }
    }

    protected virtual void AdvanceSequence()
    {
        int i = 0;
        while(avaibleSprites[i].name != mySpriteRenderer.sprite.name && i<avaibleSprites.Length-2)    
        {
            i++;

        }
        mySpriteRenderer.sprite = avaibleSprites[i + 1];


    }

    public void OnClickBehaviour()
    {

        StartCoroutine(OnClickAction());
    }

    protected virtual IEnumerator OnClickAction() //override this to move/change interactive items
    {
        //What will happen on click? 

        //c.transform.position = new Vector3(c.transform.position.x, c.transform.position.y + 5, c.transform.position.z); 


        yield return null; 
    }
    protected virtual IEnumerator AnimSprites(int startSprite,int endSprite,float time) //override this to move/change interactive items
    {
        isInteractive = false; //na czas animacji objekt nie interaktywny
        if (startSprite < endSprite)
        {
            for (int i = startSprite + 1; i <= endSprite; i++)
            {
                mySpriteRenderer.sprite = avaibleSprites[i];
                yield return new WaitForSeconds(time);
            }
        }
        else
        {
            for (int i = startSprite - 1; i >= endSprite; i--)
            {
                mySpriteRenderer.sprite = avaibleSprites[i];
                yield return new WaitForSeconds(0.1f);
            }
        }

        isInteractive = true;
        yield return null;
    }
}
