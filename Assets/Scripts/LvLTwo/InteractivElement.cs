using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractivElement : MonoBehaviour
{
    //Its copy of interactiveItem.cs from 1lvl for clear 2lvl hierarchy 
    public bool isInteractive;
    protected Collider c;
    protected SpriteRenderer mySpriteRenderer;
    public Sprite[] avaibleSprites;

    protected enum States {Open, Closed,UnBroken, Broken, PhaseOne, PhaseTwo, PhaseThree, PhaseFour };
    protected States actualState;

    protected virtual void Start()
    {
        isInteractive = true;
        actualState = States.UnBroken;
        c = gameObject.GetComponent<Collider>();
        mySpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
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
}
