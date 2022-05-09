using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    GameObject _InicioScene;
    [SerializeField]
    GameObject _RegistroScene;
    [SerializeField]
    GameObject _MenuScene;
    [SerializeField]
    GameObject _GameScene;
    [SerializeField]
    GameObject _EncuestaScene;
    [SerializeField]
    GameObject _ContinuarScene;
    [SerializeField]
    MechanicalControl _Mechanical;
    [SerializeField]
    Encuesta _Encuesta;


    // Start is called before the first frame update
    void Start()
    {
        _InicioScene.SetActive(true);
        _RegistroScene.SetActive(false);
        _MenuScene.SetActive(false);
        _GameScene.SetActive(false);
        _EncuestaScene.SetActive(false);
        _ContinuarScene.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // Inicio

    public void EjecutarBtnInicio(string a) 
    {
        switch (a) 
        {
            case "Iniciar":
                _InicioScene.SetActive(false);
                _RegistroScene.SetActive(false);
                _MenuScene.SetActive(true);
                _GameScene.SetActive(false);
                _EncuestaScene.SetActive(false);
                _ContinuarScene.SetActive(false);
                break;
            case "Registro":
                _InicioScene.SetActive(false);
                _RegistroScene.SetActive(true);
                _MenuScene.SetActive(false);
                _GameScene.SetActive(false);
                _EncuestaScene.SetActive(false);
                _ContinuarScene.SetActive(false);
                break;
        }
    }

    public void EjecutarBtnRegistro(string a)
    {
        switch (a)
        {
            case "Registrar":

                break;
            case "Cancelar":
                _InicioScene.SetActive(true);
                _RegistroScene.SetActive(false);
                _MenuScene.SetActive(false);
                _GameScene.SetActive(false);
                _EncuestaScene.SetActive(false);
                _ContinuarScene.SetActive(false);
                break;
        }
    }

    public void EjecutarBtnMenuPrincipal(string a) 
    {
        switch (a)
        {
            case "Frutas":
                _Mechanical.DecidirTema("Frutas");
                _InicioScene.SetActive(false);
                _RegistroScene.SetActive(false);
                _MenuScene.SetActive(false);
                _GameScene.SetActive(true);
                _EncuestaScene.SetActive(false);
                _ContinuarScene.SetActive(false);
                break;
            case "Animales":
                _Mechanical.DecidirTema("Animales");
                _InicioScene.SetActive(false);
                _RegistroScene.SetActive(false);
                _MenuScene.SetActive(false);
                _GameScene.SetActive(true);
                _EncuestaScene.SetActive(false);
                _ContinuarScene.SetActive(false);
                break;
        }
    }

    public void ActivarEscenaPostJuego() 
    {
        _InicioScene.SetActive(false);
        _RegistroScene.SetActive(false);
        _MenuScene.SetActive(false);
        _GameScene.SetActive(false);
        _EncuestaScene.SetActive(true);
        _ContinuarScene.SetActive(false);
    }

    public void EjecutarBtnEncuesta(string a)
    {
        switch (a)
        {
            case "1":
                _Encuesta.RegistrarValorEncuesta(1);
                _InicioScene.SetActive(false);
                _RegistroScene.SetActive(false);
                _MenuScene.SetActive(false);
                _GameScene.SetActive(false);
                _EncuestaScene.SetActive(false);
                _ContinuarScene.SetActive(true);
                break;
            case "2":
                _Encuesta.RegistrarValorEncuesta(2);
                _InicioScene.SetActive(false);
                _RegistroScene.SetActive(false);
                _MenuScene.SetActive(false);
                _GameScene.SetActive(false);
                _EncuestaScene.SetActive(false);
                _ContinuarScene.SetActive(true);
                break;
            case "3":
                _Encuesta.RegistrarValorEncuesta(3);
                _InicioScene.SetActive(false);
                _RegistroScene.SetActive(false);
                _MenuScene.SetActive(false);
                _GameScene.SetActive(false);
                _EncuestaScene.SetActive(false);
                _ContinuarScene.SetActive(true);
                break;
            case "4":
                _Encuesta.RegistrarValorEncuesta(4);
                _InicioScene.SetActive(false);
                _RegistroScene.SetActive(false);
                _MenuScene.SetActive(false);
                _GameScene.SetActive(false);
                _EncuestaScene.SetActive(false);
                _ContinuarScene.SetActive(true);
                break;
            case "5":
                _Encuesta.RegistrarValorEncuesta(5);
                _InicioScene.SetActive(false);
                _RegistroScene.SetActive(false);
                _MenuScene.SetActive(false);
                _GameScene.SetActive(false);
                _EncuestaScene.SetActive(false);
                _ContinuarScene.SetActive(true);
                break;
        }
    }

    public void EjecutarBtnSeguirJugando(string a)
    {
        switch (a)
        {
            case "Seguir":
                _InicioScene.SetActive(false);
                _RegistroScene.SetActive(false);
                _MenuScene.SetActive(true);
                _GameScene.SetActive(false);
                _EncuestaScene.SetActive(false);
                _ContinuarScene.SetActive(false);
                break;
            case "Salir":
                _InicioScene.SetActive(true);
                _RegistroScene.SetActive(false);
                _MenuScene.SetActive(false);
                _GameScene.SetActive(false);
                _EncuestaScene.SetActive(false);
                _ContinuarScene.SetActive(false);
                break;
        }
    }

}
