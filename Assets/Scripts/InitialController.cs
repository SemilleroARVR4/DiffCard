using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class InitialController : MonoBehaviour
{
    [SerializeField]
    GameObject _InicioScene;
    [SerializeField]
    GameObject _RegistroScene;
    [SerializeField]
    Text message; 
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

        string format = "dd MMM yyyy";
        main.SessionInfo.SetDate(DateTime.Now.ToString(format));

        _InicioScene.SetActive(true);
        _RegistroScene.SetActive(false);
    }

    private void Update()
    {
        message.text = main.web.message;     
    }


    public void EjecutarBtnInicio(string a)
    {
        switch (a)
        {
            case "Registro":
                _InicioScene.SetActive(false);
                _RegistroScene.SetActive(true);
                main.web.message = "";
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
                main.web.message = "";
                break;
        }
    }
    

}
