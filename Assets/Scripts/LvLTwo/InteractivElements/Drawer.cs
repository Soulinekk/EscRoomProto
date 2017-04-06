using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : InteractivElement {

    public UseableElement hidenItem;
    protected override void Start()
    {
        hidenItem.gameObject.SetActive(false);
        base.Start();
        actualState = States.Closed;
    }
    protected override IEnumerator OnClickAction()                          // Zachowanie po kliknieciu
    {
        switch (actualState)
        {
            case States.Closed:
                if (avaibleSprites.Length > 1)
                { //Open no water
                    mySpriteRenderer.sprite = avaibleSprites[1];
                    gameObject.GetComponent<Collider2D>().offset = new Vector2(-0.2f, -0.15f);
                    actualState = States.Open;
                    if (!hidenItem.picked)
                        hidenItem.gameObject.SetActive(true);

                }
                break;
            default:
                if (avaibleSprites.Length > 0)
                {  //Close
                    mySpriteRenderer.sprite = avaibleSprites[0];
                    gameObject.GetComponent<Collider2D>().offset = new Vector2(0.16f, 0.16f);
                    actualState = States.Closed;
                    if(!hidenItem.picked)
                         hidenItem.gameObject.SetActive(false);
                }
                break;
           
           /* case States.Open:
                break;
            case States.WaterFull:
                break;
            case States.WaterOneThird:
                break;
            case States.WaterTwoThirds:
                break;*/
        }

        return base.OnClickAction();
    }
}
