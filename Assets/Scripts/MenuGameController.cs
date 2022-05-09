using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGameController : MonoBehaviour
{

    [SerializeField]
    GameObject _MenuScene;

    public void EjecutarBtnMenuPrincipal(string a)
    {
        switch (a)
        {
            case "Frutas":
                PlayerPrefs.SetString("Tema", a);
                SceneManager.LoadScene("Game");
                break;
            case "Animales":
                PlayerPrefs.SetString("Tema", a);
                SceneManager.LoadScene("Game");
                break;
        }
    }

}
