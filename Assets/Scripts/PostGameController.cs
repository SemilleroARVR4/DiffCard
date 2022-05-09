using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PostGameController : MonoBehaviour
{
    [SerializeField]
    GameObject _EncuestaScene;
    [SerializeField]
    GameObject _ContinuarScene;
    [SerializeField]
    Encuesta _Encuesta;

    public void EjecutarBtnEncuesta(string a)
    {
        switch (a)
        {
            case "1":
                _Encuesta.RegistrarValorEncuesta(1);
                _EncuestaScene.SetActive(false);
                _ContinuarScene.SetActive(true);
                break;
            case "2":
                _Encuesta.RegistrarValorEncuesta(2);
                _EncuestaScene.SetActive(false);
                _ContinuarScene.SetActive(true);
                break;
            case "3":
                _Encuesta.RegistrarValorEncuesta(3);
                _EncuestaScene.SetActive(false);
                _ContinuarScene.SetActive(true);
                break;
            case "4":
                _Encuesta.RegistrarValorEncuesta(4);
                _EncuestaScene.SetActive(false);
                _ContinuarScene.SetActive(true);
                break;
            case "5":
                _Encuesta.RegistrarValorEncuesta(5);
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
                SceneManager.LoadScene("Menu_Game");
                break;
            case "Salir":
                SceneManager.LoadScene("Inicial_Registro");
                break;
        }
    }
}
