using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractivElement : MonoBehaviour
{
    //Its copy of interactiveItem.cs from 1lvl for clear 2lvl hierarchy 
    [HideInInspector]
    public bool isInteractive;
    public bool feedbackOnly;
    protected Collider c;
    protected SpriteRenderer mySpriteRenderer;
    public Sprite darkRoomSprite;
    protected bool sequenceOn;
    protected int sequenceSlowerer;

    protected int actionClickCount;
    

    [HideInInspector]

    public enum States {Closed, Open, UnBroken, Broken, PhaseOne, PhaseTwo, PhaseThree, PhaseFour,PhaseFive,PhaseSix, DarkRoom };
    public States actualState; 



    public List<InteractivElement> references = new List<InteractivElement>();
    [SerializeField]
    //protected InteractivElement references[0];
    protected bool activationCheck;
    protected States activatingState;


    public Sprite[] avaibleSprites;
    public UseableElement[] hidenItems;
    protected virtual void Start()
    {

        references.Insert(0, GameObject.Find("mainLamp").GetComponent<InteractivElement>()); //gorna lampa ktora bedzie wplywala na wszystkie obiekty bedzie na poczatku ref
        feedbackOnly = false;
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
        DarkRoomCheck();
        if (actualState != States.DarkRoom)
        {
            ActivateSequenceCheck();

            AdvSeqCheck();
        }
        
    }

    protected virtual void DarkRoomCheck()
    {
        if (references[0].actualState == States.Broken && actualState != States.DarkRoom && this != references[0])
        {
            actualState = States.DarkRoom;
            ChangeToDarkRoom();
        }
    }

    protected virtual void ActivateSequenceCheck()
    {
        
        if (activationCheck && actualState != States.DarkRoom) //aktywator sekwencji na 1 pozycji listy
        {
            if (references.Count > 1)
            {
                if (references[1].actualState == activatingState)
                {
                    sequenceOn = true;
                    activationCheck = false;
                }
            }
        }
    }

    protected virtual void AdvSeqCheck()
    {
        if (Player.interactiveItemClicked && sequenceOn)
        {
            if (actionClickCount % sequenceSlowerer == 0)  //seqslowerer jest iloscia klikniec potrzebna do kontynuowania sekwencji
                AdvanceSequence();                         //np co drugie (2%2 i 4%2 6%2=0) lub co trzecie (3%3 i 6%3 9%3 =0)

            actionClickCount++;
        }
    }

    protected virtual void ChangeToDarkRoom()
    {
        if(darkRoomSprite!=null)
            mySpriteRenderer.sprite = darkRoomSprite;
        //isInteractive = false;
    }

    protected virtual void AdvanceSequence()
    {
        ChangeState();  // jezeli obiekt zmienia sie sekwencyjnie zmienia tez swoj state

        int i = 0;          //znajdz aktualny i ustaw kolejny sprite
        while (avaibleSprites[i].name != mySpriteRenderer.sprite.name && i<avaibleSprites.Length-2)    
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
        if (actualState == States.DarkRoom)
        {
            Feedback.Instance.ShowText("Can't see anything up there",1.5f);
        }

        yield return null; 
    }
    protected virtual IEnumerator AnimSprites(int startSprite,int endSprite,float time) //override this to move/change interactive items
    {
        if (!Player.allowInteraction)
            Player.doubleAnim = true;
        else
            Player.allowInteraction = false;
        //na czas animacji interakcja nie aktywna
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
        if (!Player.doubleAnim)
            Player.allowInteraction = true;
        else
            Player.doubleAnim = false;
        yield return null;
    }

    protected void ChangeState()
    {
        
            int i = 0;
            while (mySpriteRenderer.sprite != avaibleSprites[i] && i < avaibleSprites.Length - 1)
            {
                i++;
            }
            switch (i)
            {
                case (1):
                    actualState = States.PhaseOne;
                    break;
                case (2):
                    actualState = States.PhaseTwo;
                    break;
                case (3):
                    actualState = States.PhaseThree;
                    break;
                case (4):
                    actualState = States.PhaseFour;
                    break;
                case (5):
                    actualState = States.PhaseFive;
                    break;


                default:
                    break;
            }
        
    }
    protected InteractivElement FindInReferences(string refName)
    {
        foreach(InteractivElement obj in references)
        {
            if(obj.gameObject.name== refName)
            {
                return obj;
            }
        }
        return this;
    }

    
}
