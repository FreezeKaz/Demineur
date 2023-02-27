
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.PlayerSettings;


public class ClickEvent : MonoBehaviour
{
    public GameObject spawner;

    [SerializeField] SpriteRenderer red_flag;
    [SerializeField] SpriteRenderer _number;
    [SerializeField] Sprite empty;
    bool clicked = false;

    private void Start()

    {
        spawner = GameObject.Find("GameStatut");
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (red_flag.gameObject.activeSelf == true)
            {
                Debug.Log("Sprite right clicked");
                red_flag.gameObject.SetActive(false);
            }
            else
            {
                red_flag.gameObject.SetActive(true);
            }
        }
        else if (Input.GetMouseButtonDown(0))
        {
            click();
        }
    }
    public void click()
    {
        if (!clicked)
        {
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
            if (GetComponent<SpriteRenderer>().transform.childCount == 3)
            {
                _number.sprite = empty;
                Debug.Log("Dead");
            }
            else
            {
                _number.gameObject.SetActive(true);
                clicked = true;
                workOnAdjacent();
            }
        }
    }

    public void workOnAdjacent()
        if(Input.GetMouseButtonDown(1))
        {
            if(_DemineurGame.FlagNumber > 0)
            {
                Debug.Log("Sprite right clicked");
                ChangeOnFlag();         //flag   
                _DemineurGame.LostFlag();
            }
            else
            {
                Debug.Log("Vous ne possédez plus de drapeau");
            }

        }
    }

    void ChangeOnFlag()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = Flag;
    }

    public bool IsBombAround()
    {
        if (transform.GetChild(1).GetComponent<SpriteRenderer>().sprite.name == "TurnedOff")
        {
            spawner.GetComponent<CreateDemineur>().RevealAll(gameObject);
        }
    }
}
