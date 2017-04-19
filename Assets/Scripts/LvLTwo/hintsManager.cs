using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hintsManager : MonoBehaviour {
   /* Camera mainCam;
    public HintItem[] hintsItems;
    void Awake()
    {
        mainCam = gameObject.GetComponent<Camera>();
        hintsItems = GameObject.FindObjectsOfType<HintItem>();
    }

    private IEnumerator CheckForInteraction()
    {
        yield return new WaitForFixedUpdate();
        while (!Input.GetMouseButtonDown(0)) ///////check if player pressed anything, can be switch to interactive items only if needed)
        {
            yield return null;
        }
        foreach (HintItem obj in hintsItems)
        {
            obj.mySpriteRenderer.sprite = obj.animSprites[0];
        }
        yield return new WaitForFixedUpdate();
        foreach (HintItem obj in hintsItems)
        {
            obj.mySpriteRenderer.sprite = obj.animSprites[0];
            obj.animStarted = false;
            StopAllCoroutines();
        }
        yield return null;



    }
    /*
    private IEnumerator AnimThis()
    {
        //animuj losowy obj
        HintItem obj;
        Vector3 pos = mainCam.transform.position;
        Vector3 actPos = Vector3.zero;
        int j=0;
        obj = hintsItems[(int)Random.Range(0, hintsItems.Length - 1)];
        do{
            if (j == obj.positionLookedFor.Count - 1)
            {
                obj = hintsItems[(int)Random.Range(0, hintsItems.Length - 1)];
                j = 0;
            }
            else
                j++;

        }
        while ( actPos != pos);
        

        while (obj.animStarted)
        {
            yield return new WaitForSeconds(4f);
            for (int i = 0; i < obj.animSprites.Length; i++)
            {
                obj.mySpriteRenderer.sprite = obj.animSprites[i];
                yield return new WaitForSeconds(0.35f);
            }
            obj.mySpriteRenderer.sprite = obj.animSprites[0];
        }

        yield return null;
    }
    */
}
