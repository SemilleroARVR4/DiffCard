using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDefinition : MonoBehaviour
{
    [SerializeField] 
    private SceneControl controller;
    [SerializeField] 
    private GameObject Carta;

    private int _id;

    private void OnMouseDown()
    {
        //Rotar();
        if (Carta.activeSelf) 
        {
            Carta.SetActive(false);
            controller.CardRevealed(this);
        }
    }

    public void ChangeSprite(int id, Sprite image)
    {
        _id = id;
        GetComponent<SpriteRenderer>().sprite = image;
    }

    public void Unreveal() 
    {
        Carta.SetActive(true);
    }


    public int id { get { return _id; } }

}
