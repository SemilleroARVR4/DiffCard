using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDefinition : MonoBehaviour
{
    [SerializeField] 
    private MechanicalControl controller;
    [SerializeField]
    private GameObject Carta;

    private int _id;
    private float _tiempoPareja = 0;
    public bool iniTiempoP = false;

    private void Update()
    {
        if (iniTiempoP) 
        {
            _tiempoPareja += Time.deltaTime;
        }
    }


    private void OnMouseDown()
    {
        if (Carta.activeSelf && controller.state)
        {
            Carta.SetActive(false);
            controller.CardRevealed(this);
            iniTiempoP = true;
        }
    }

    public void ChangeSprite(int id, Sprite image)
    {
        _id = id;
        GetComponent<Image>().sprite = image;
    }

    public void Unreveal() 
    {
        Carta.SetActive(true);
    }


    public int id { get { return _id; } }
    public float tiempoPareja { get { return _tiempoPareja; } }
    // recordar que estoy definiciendo el tiempo pareja con tal de que al levante una carta esta inicie un timer y posteriormente
    // cuando consiga encontrar la pareja de esta, comparare los tiempos de ambas cartas y escogere el mayor tiempo

    public void ActivarCartaInicial(bool a) 
    {
        gameObject.SetActive(a);
    }
}
