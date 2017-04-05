using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractiveItem : MonoBehaviour {

    protected Collider c;
    void Start()
    {
        c = gameObject.GetComponent<Collider>();
    }


    public virtual void OnClickBehaviour()
    {

        StartCoroutine(OnClickAction());
    }

    protected virtual IEnumerator OnClickAction()
    {
        c.transform.position= new Vector3(c.transform.position.x,c.transform.position.y+ 5,c.transform.position.z);
        
        yield break;
    }
}
