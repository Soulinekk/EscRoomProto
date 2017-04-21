using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintItem : MonoBehaviour
{
    public List<UseableElement> hintItemDisablersU;
   public List<InteractivElement> hintItemDisablersI;
    public Sprite[] animSprites;
    private Camera mainCam;
    public bool animStarted;                    // wszystko public bo nie chce mi sie pisac metod :/ to i tak tylko proto
    public List<Vector3> positionLookedFor;
    [HideInInspector]
    public SpriteRenderer mySpriteRenderer;
    public bool randomMode=false;
    
    void Awake()
    {
        
        animStarted = false;
        mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
        mySpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        mySpriteRenderer.sprite = animSprites[1];
        mySpriteRenderer.enabled = false;
        //if (positionLookedFor.Count == 0)
          //  positionLookedFor = new List<Vector3>();

                
    }
    void OnEnable()
    {
        animStarted = false;
        mySpriteRenderer.enabled = false;
    }
    void Update()
    {
        


        if (!randomMode)
        {
            int i = 0;
            while (!animStarted && i != positionLookedFor.Count)
            {
                if (mainCam.transform.position == positionLookedFor[i])
                {
                    if (!animStarted)
                    {
                        animStarted = true;
                        StartCoroutine(AnimThis());
                        StartCoroutine(CheckForInteraction());
                    }

                }
                else
                {

                    StopAllCoroutines();
                    mySpriteRenderer.sprite = animSprites[1];
                    mySpriteRenderer.enabled = false;
                    animStarted = false;
                }
                i++;
            }
        }


        List<InteractivElement> itemsToRemove=new List<InteractivElement>();
        foreach (InteractivElement item in hintItemDisablersI)
        {
            if (item.disableHint)
            {
                itemsToRemove.Add(item);
            }
        }
        foreach(InteractivElement item in itemsToRemove)
        {
            if (hintItemDisablersI.Contains(item))
            {
                hintItemDisablersI.Remove(item);
            }
        }

        List<UseableElement> uItemsToRemove = new List<UseableElement>();
        foreach (UseableElement item in hintItemDisablersU)
        {
            if (item.picked)
            {
                uItemsToRemove.Add(item);
                
            }
        }
        foreach (UseableElement item in uItemsToRemove)
        {
            if (hintItemDisablersU.Contains(item))
            {
                hintItemDisablersU.Remove(item);
            }
        }

        if (hintItemDisablersU.Count==0&& hintItemDisablersI.Count == 0)
        {
            StopAllCoroutines();
            this.gameObject.SetActive(false);
          
        }

    }

    private IEnumerator CheckForInteraction()
    {
        yield return new WaitForFixedUpdate();
        while (!Input.GetMouseButtonDown(0)) ///////check if player pressed anything, can be switch to interactive items only if needed)
            {
            yield return null;
        }
        mySpriteRenderer.sprite = animSprites[1];
        mySpriteRenderer.enabled = false;
        yield return new WaitForFixedUpdate();
       
        mySpriteRenderer.sprite = animSprites[1];
        mySpriteRenderer.enabled = false;
        animStarted = false;
        StopAllCoroutines();
        yield return null;



    }

    private IEnumerator AnimThis()
    {
        mySpriteRenderer.enabled = false;
        while (animStarted)
        {
            yield return new WaitForSeconds(4f);
            mySpriteRenderer.enabled = true;
            for (int i = 1; i < animSprites.Length; i++)
            {
                mySpriteRenderer.sprite = animSprites[i];
                yield return new WaitForSeconds(0.35f);
            }
            mySpriteRenderer.sprite = animSprites[1];
            mySpriteRenderer.enabled = false;
        }
        
       
        yield return null;
    }
    public void AnimNow()
    {
        StartCoroutine(AnimThisNow());
    }
    private IEnumerator AnimThisNow()
    {
            Debug.Log("hi");
        mySpriteRenderer.enabled = true; 
        mySpriteRenderer.sprite = animSprites[1];
            for (int i = 0; i < animSprites.Length; i++)
            {
                mySpriteRenderer.sprite = animSprites[i];
                yield return new WaitForSeconds(0.35f);
            }
            mySpriteRenderer.sprite = animSprites[1];
        mySpriteRenderer.enabled = false;
        yield return null;
    }
}