using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public InputField usernameInput;
    public InputField nickInput;
    public Button LoginButton;


    // Start is called before the first frame update
    void Start()
    {
        LoginButton.onClick.AddListener(() => {
            StartCoroutine(Main.Instance.web.Login(usernameInput.text,nickInput.text));
        });       
    }



}
