using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintItem : MonoBehaviour
{
    public Sprite[] animSprites;
    private Camera mainCam;
    bool animStarted;
    public List<Vector3> positionLookedFor;
    private SpriteRenderer mySpriteRenderer;
       
    void Awake()
    {
        
        animStarted = false;
        mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
        mySpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        mySpriteRenderer.sprite = animSprites[0];
        //if (positionLookedFor.Count == 0)
          //  positionLookedFor = new List<Vector3>();

                
    }
    void OnEnable()
    {
        animStarted = false;
        mySpriteRenderer.sprite = animSprites[0];
    }
    void Update()
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
                mySpriteRenderer.sprite = animSprites[0];
                animStarted = false;
            }
            i++;
        }

    }

    private IEnumerator CheckForInteraction()
    {
        yield return new WaitForFixedUpdate();
        while (!Input.GetMouseButtonDown(0)) ///////check if player pressed anything, can be switch to interactive items only if needed)
            {
            yield return null;
        }
        mySpriteRenderer.sprite = animSprites[0];
        
        yield return new WaitForFixedUpdate();
       
        mySpriteRenderer.sprite = animSprites[0];
        animStarted = false;
        StopAllCoroutines();
        yield return null;



    }

    private IEnumerator AnimThis()
    {
        
        while (animStarted)
        {
            yield return new WaitForSeconds(5f);
            for (int i = 0; i < animSprites.Length; i++)
            {
                mySpriteRenderer.sprite = animSprites[i];
                yield return new WaitForSeconds(0.35f);
            }
            mySpriteRenderer.sprite = animSprites[0];
        }
        
        yield return null;
    }
}