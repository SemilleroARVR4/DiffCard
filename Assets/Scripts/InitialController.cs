using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class InitialController : MonoBehaviour
{
    [SerializeField]
    GameObject _InicioScene;
    [SerializeField]
    GameObject _RegistroScene;
    private double tiempoSesion;
    public Main main;

    // Start is called before the first frame update
    void Start()
    {
        main = FindObjectOfType<Main>();

        main.UserInfo.ResetInfo();
        main.SessionInfo.ResetInfo();
        main.MatchGameInfo.ResetInfo();
        main.PerformanceInfo.ResetInfo();


        Time.timeScale = 0;
        tiempoSesion = main.SessionInfo.Totaltime;

        string format = "dd MMM yyyy";
        main.SessionInfo.SetDate(DateTime.Now.ToString(format));

        _InicioScene.SetActive(true);
        _RegistroScene.SetActive(false);
    }
    
    public void EjecutarBtnInicio(string a)
    {
        switch (a)
        {
            case "Registro":
                _InicioScene.SetActive(false);
                _RegistroScene.SetActive(true);
                Debug.Log(Time.deltaTime);
                break;
        }
    }

    public void EjecutarBtnRegistro(string a)
    {
        switch (a)
        {
            case "Cancelar":
                _InicioScene.SetActive(true);
                _RegistroScene.SetActive(false);
                break;
        }
    }
    

}
