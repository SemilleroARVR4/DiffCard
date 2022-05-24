using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public InputField usernameInput;
    public InputField nickInput;
    public Button LoginButton;
    private Main main;

    // Start is called before the first frame update
    void Start()
    {
        main = FindObjectOfType<Main>();

        LoginButton.onClick.AddListener(() => {
            StartCoroutine(main.web.Login(usernameInput.text,nickInput.text));
        });       
    }



}
