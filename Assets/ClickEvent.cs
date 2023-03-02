

using UnityEngine;



public class ClickEvent : MonoBehaviour
{
    private GameObject spawner;


    [SerializeField] SpriteRenderer red_flag;
    [SerializeField] SpriteRenderer _number;
    [SerializeField] Sprite empty;
    [SerializeField] AudioSource[] soundsEffect;
    bool clicked = false;

    private void Start()

    {
        spawner = GameObject.Find("GameStatut");
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (!spawner.GetComponent<CreateDemineur>()._stop)
            {
                if (red_flag.gameObject.activeSelf == false && _number.gameObject.activeSelf == false)
                {
                    GetComponent<AudioSource>().clip = soundsEffect[1].clip;
                    GetComponent<AudioSource>().Play();
                    red_flag.gameObject.SetActive(true);
                }
                else if (red_flag.gameObject.activeSelf == true)
                {
                    GetComponent<AudioSource>().clip = soundsEffect[1].clip;
                    GetComponent<AudioSource>().Play();
                    red_flag.gameObject.SetActive(false);
                }
            }
        }
        else if (Input.GetMouseButtonDown(0) && red_flag.gameObject.activeSelf == false)
        {
            if (!spawner.GetComponent<CreateDemineur>()._stop)
            {
                GetComponent<AudioSource>().clip = soundsEffect[0].clip;
                GetComponent<AudioSource>().Play();
                CreateBombOnFirstClick();
                click();
            }
        }
        if (Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(0))
        {
            spawner.GetComponent<CreateDemineur>().CheckWin();
        }
    }
    public void click()
    {
        if (!clicked)
        {
            if (red_flag.gameObject.activeSelf == true)
            {
                red_flag.gameObject.SetActive(false);
            }
            _number.gameObject.SetActive(true);
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
            if (GetComponent<SpriteRenderer>().transform.childCount == 3)
            {
                _number.sprite = empty;
                spawner.GetComponent<CreateDemineur>()._stop = true;
                GetComponent<AudioSource>().clip = soundsEffect[2].clip;
                GetComponent<AudioSource>().Play();
                spawner.GetComponent<CreateDemineur>().LooseGame();
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
            } while (transform.GetChild(1).GetComponent<SpriteRenderer>().sprite.name != "TurnedOff" || transform.childCount == 3);
            spawner.GetComponent<CreateDemineur>().created = true;
        }
    }
}
