

using UnityEngine;



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

                red_flag.gameObject.SetActive(false);

            }
            else
            {
                Debug.Log("Sprite right clicked");
                red_flag.gameObject.SetActive(true);
                if (spawner.GetComponent<CreateDemineur>().CheckWin())
                {
                    //
                }
            }

        }
        else if (Input.GetMouseButtonDown(0) && red_flag.gameObject.activeSelf == false)
        {
            GetComponent<AudioSource>().Play();
            CreateBombOnFirstClick();

            click();
            if (spawner.GetComponent<CreateDemineur>().CheckWin())
            {
                //
            }
        }


    }
    public void click()
    {

      
        if (!clicked)
        {
            _number.gameObject.SetActive(true);
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
    {
        if (transform.GetChild(1).GetComponent<SpriteRenderer>().sprite.name == "TurnedOff")
        {
            spawner.GetComponent<CreateDemineur>().RevealAll(gameObject);
        }
    }

    public void CreateBombOnFirstClick()
    {
        if (spawner.GetComponent<CreateDemineur>().created == false)
        {

            do 
            {

                spawner.GetComponent<CreateDemineur>().CreateAllBomb();
            }while (transform.GetChild(1).GetComponent<SpriteRenderer>().sprite.name != "TurnedOff" || transform.childCount == 3);
                
            
           
            spawner.GetComponent<CreateDemineur>().created = true;
        }
       
    }

}
