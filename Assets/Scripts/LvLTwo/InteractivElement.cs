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
    
    protected bool sequenceOn;
    protected int sequenceSlowerer;

    protected int actionClickCount;
    

    [HideInInspector]

    public enum States { Open, Closed, UnBroken, Broken, DarkRoom, PhaseOne, PhaseTwo, PhaseThree, PhaseFour,PhaseFive,PhaseSix };
    public States actualState; 



    public InteractivElement aktywator;
    [SerializeField]
    protected InteractivElement mainLamp;
    protected bool activationCheck;
    protected States activatingState;


    public Sprite[] avaibleSprites;
    public UseableElement[] hidenItems;
    protected virtual void Start()
    {
        if(aktywator==null)
            aktywator = this;
        mainLamp = GameObject.Find("mainLamp").GetComponent<InteractivElement>();

        activationCheck = true;
        activatingState = States.PhaseFour;
        sequenceSlowerer = 1;
        sequenceOn = false;
        isInteractive = true;
        actualState = States.UnBroken;
        c = gameObject.GetComponent<Collider>();
        mySpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    protected virtual void FixedUpdate()
    {
        if (aktywator.actualState == activatingState && activationCheck)
        {
            sequenceOn = true;
            activationCheck = false;
        }

        if (Player.interactiveItemClicked && sequenceOn )
        {
            if(actionClickCount % sequenceSlowerer == 0)
                 AdvanceSequence();

            actionClickCount++;
        }
        
    }

    protected virtual void AdvanceSequence()
    {
        ChangeState();
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
        Player.allowInteraction = false; //na czas animacji interakcja nie interaktywny
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

        Player.allowInteraction = true;
        yield return null;
    }

    protected void ChangeState()
    {
        int i=0;
        while (mySpriteRenderer.sprite != avaibleSprites[i])
        {
            i++;
        }
        switch (i)
        {
            case (2):
                actualState = States.PhaseOne;
                break;
            case (3):
                actualState = States.PhaseTwo;
                break;
            case (4):
                actualState = States.PhaseThree;
                break;
            case (5):
                actualState = States.PhaseFour;
                break;


            default:
                break;
        }
    }

    
}
