using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneControl : MonoBehaviour
{
    public const int griRows = 2;
    public const int griCols = 4;
    public const float offsetX = 2f;
    public const float offeseY = 3f;

    [SerializeField]
    private CardDefinition originalCard;
    [SerializeField]
    private Sprite[] images;

    public int score = 0;


    // Start is called before the first frame update
    void Start()
    {
        Vector3 startPos = originalCard.transform.position;
        int[] numbers = { 0, 0, 1, 1, 2, 2, 3, 3 };
        numbers = ShufflerArray(numbers);

        for (int i = 0; i < griCols; i ++) 
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
                    card = Instantiate(originalCard) as CardDefinition;
                }

                int index = j * griCols + i;
                int id = numbers[index];
                card.ChangeSprite(id, images[id]);

                float posX = (offsetX * i) + startPos.x;
                float posY = (offeseY * j) + startPos.y;

                card.transform.position = new Vector3(posX, posY, startPos.z);
            }
        }
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

    private CardDefinition _firstReveaked;
    private CardDefinition _sconRevealed;

    private int _score = 0;

    [SerializeField]
    private Text scoreLabel;

    public bool canReveal { get { return _sconRevealed = null; }}

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
        if (_firstReveaked.id == _sconRevealed.id)
        {
            _score++;
            scoreLabel.text = "Score: " + _score;
            if (_score == 4) 
            {
                Debug.Log("Ganaste ^-^");
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
    }

    void cardCoparion(List<int> c) 
    {

    }

}
