using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poduszki : InteractiveItem {

    protected override IEnumerator OnClickAction()
    {
        c.enabled = false;
        Vector3 startingPos = transform.position;
        Vector3 finalPos = new Vector3(transform.position.x, transform.position.y + 0.3f, transform.position.z);
        while (transform.position.y < finalPos.y)
        {
            transform.position = Vector3.MoveTowards(transform.position, finalPos, Time.deltaTime);
            yield return null;
        }
        yield return new WaitForSeconds(1f);
        while (transform.position.y > startingPos.y)
        {
            transform.position = Vector3.MoveTowards(transform.position, startingPos, Time.deltaTime);
            yield return null;
        }
        c.enabled = true;
        yield break;
    }
}
