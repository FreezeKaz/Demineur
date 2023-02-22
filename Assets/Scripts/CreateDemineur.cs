using UnityEngine;

public class CreateDemineur : MonoBehaviour
{
    public int GridSize = 10;
    [SerializeField] private GameObject Case_Clear;
    [SerializeField] private GameObject Case_Bomb;
    System.Random random = new System.Random();

    int min = -4;
    int max;
    int BombNumber;
    public int FlagNumber;
 

    public GameObject[,] selectorArr;
    void Start()
    {
        selectorArr = new GameObject[GridSize, GridSize];
        max = min + GridSize;
        BombNumber = GridSize;
        FlagNumber = BombNumber + (BombNumber / 2);

        // Start is called before the first frame update

        for (int i = 0; i < GridSize; i++)
        {
            //Cells
            for (int j = 0; j < GridSize; j++)
            {
                //Instantiate(Case_Clear, new Vector2(j - 4, i - 4), Quaternion.identity);
                selectorArr[i, j] = Instantiate(Case_Clear, new Vector2(j - 4, i - 4), Quaternion.identity, Case_Clear.transform.parent);
            }
        }

        for (int i = 0; i < GridSize; i++)
        {
            //Bombs
            int x = random.Next(min, max);
            int y = random.Next(min, max);
            //Instantiate(Case_Bomb, new Vector2(x, y), Quaternion.identity);
            selectorArr[x + 4, y + 4] =  Instantiate(Case_Bomb, new Vector2(x, y), Quaternion.identity, Case_Bomb.transform.parent);
            BombNumber++;

        }
        Debug.Log("Le nombre de bombes est de "+BombNumber);
    }

    public void LostFlag()
    {
        FlagNumber--;
        Debug.Log("Vous avez utilisé un drapeau, il vous en reste " + FlagNumber);
    }

    // Update is called once per frame
    void Update()
    {
        
    
    }
}