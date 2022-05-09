using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MechanicalControl : MonoBehaviour
{
    public const int griRows = 2;
    public const int griCols = 8;
    public const float offsetX = 2f;
    public const float offeseY = 3.5f;
    private bool _state = true;
    private int _score = 0;

    private CardDefinition _firstReveaked;
    private CardDefinition _sconRevealed;

    [SerializeField]
    private CardDefinition originalCard;
    private Sprite[] images;
    [SerializeField]
    private Sprite[] images_Frutas;
    [SerializeField]
    private Sprite[] images_Animales;
    [SerializeField]
    private Text scoreLabel;
    [SerializeField]
    private GameObject juego;
    [SerializeField]
    private Timer _Timer;
    [SerializeField]
    private GameController _GameController;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("WaitSecond");      
    }

    private int[] ShufflerArray(int[] numbers) 
    {
        int[] newArray = numbers.Clone() as int[];
        for (int i = 0; i < newArray.Length; i++) 
        {
            int tmp = newArray[i];
            int r = Random.Range(i,newArray.Length);
            newArray[i] = newArray[r];
            newArray[r] = tmp;
        }
        return newArray;
    }

    public void CardRevealed(CardDefinition card) 
    {
        if (_firstReveaked == null)
        {
            _firstReveaked = card;
        }
        else 
        {
            _sconRevealed = card;
            StartCoroutine(CheckedMatch());
        }
    }

    private IEnumerator CheckedMatch() 
    {
        _state = false;
        if (_firstReveaked.id == _sconRevealed.id)
        {
            _score++;
            scoreLabel.text = "Score: " + _score;
            if (_score == griCols) 
            {
                Debug.Log("Ganaste ^-^");
                _GameController.ActivarEscenaPostJuego();
            }
        }
        else 
        {
            yield return new WaitForSeconds(0.5f);
            _firstReveaked.Unreveal();
            _sconRevealed.Unreveal();
        }

        _firstReveaked = null;
        _firstReveaked = null;
        _state = true;
    }

    private IEnumerator WaitSecond() 
    {
        Debug.Log("Esperando");
        yield return new WaitForSeconds(3f);
        Debug.Log("Listo");

        Vector3 startPos = originalCard.transform.position;
        int[] numbers = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };

        numbers = ShufflerArray(numbers);


        for (int i = 0; i < griCols; i++)
        {
            for (int j = 0; j < griRows; j++)
            {
                CardDefinition card;
                if (i == 0 && j == 0)
                {
                    card = originalCard;
                }
                else
                {
                    originalCard.ActivarCartaInicial(true);
                    card = Instantiate(originalCard, juego.transform) as CardDefinition;
                    card.transform.SetParent(juego.transform);
                }

                int index = j * griCols + i;
                //Debug.Log(index + ", " + i + ", " + j);
                int id = numbers[index];

                card.ChangeSprite(id, images[id]);

                float posX = (offsetX * i) + startPos.x;
                float posY = (offeseY * j) + startPos.y;

                card.transform.position = new Vector3(posX, posY, startPos.z);
            }
            _Timer._con = true;
        }

        StopCoroutine("WaitSecond");
    }

    public void DecidirTema(string tema)
    {
        if (tema == "Frutas") 
        {
            images = images_Frutas;
        } else if (tema == "Animales")
        {
            images = images_Animales;
        }
    }

    public bool canReveal { get { return _sconRevealed = null; } }
    public bool state { get { return _state; } }


}
