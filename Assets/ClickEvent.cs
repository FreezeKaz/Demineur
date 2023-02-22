using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickEvent : MonoBehaviour
{
    void OnMouseDown()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.black;
        Debug.Log("Sprite Clicked");
        
    }
    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(1)){
            Debug.Log("Sprite right clicked");
            //flag
        }
    }

    public bool IsBombAround()
    {
       return true;
    }
}
