using UnityEngine;


public class ClickEvent : MonoBehaviour
{
    [SerializeField] private CreateDemineur _DemineurGame;
    public Sprite Flag;
    private void Start()
    {
        
    }
    void OnMouseDown()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.black;
        Debug.Log("Sprite Clicked");
        
    }

    private void OnMouseOver()
    {
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
       return true;
    }
}
