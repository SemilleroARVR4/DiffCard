using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitialController : MonoBehaviour
{
    [SerializeField]
    GameObject _InicioScene;
    [SerializeField]
    GameObject _RegistroScene;

    // Start is called before the first frame update
    void Start()
    {
        _InicioScene.SetActive(true);
        _RegistroScene.SetActive(false);
    }

    // Inicio

    public void EjecutarBtnInicio(string a)
    {
        switch (a)
        {
            case "Iniciar":
                _InicioScene.SetActive(false);
                _RegistroScene.SetActive(false);
                SceneManager.LoadScene("Menu_Game");
                break;
            case "Registro":
                _InicioScene.SetActive(false);
                _RegistroScene.SetActive(true);
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
                break;
        }
    }

}
