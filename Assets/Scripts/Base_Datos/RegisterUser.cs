using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegisterUser : MonoBehaviour
{
    public InputField usernameInput;
    public InputField nick;
    public InputField birthDate;
    public Dropdown   gender;
    public Button     SubmitButton;
    public Text advertencia;
    private Main main;

    private void Update()
    {
        advertencia.text = main.web.message;
    }

    // Start is called before the first frame update
    void Start()
    {
        main = FindObjectOfType<Main>();
        SubmitButton.onClick.AddListener(() => {
            string genderText = "Masculino";
            try
            {
                advertencia.text = "";
                int d = Int32.Parse(birthDate.text);
                if (gender.value == 0) { genderText = "Masculino"; }
                if (gender.value == 1) { genderText = "Femenino"; }
                if (gender.value == 2) { genderText = "Otro"; }
                StartCoroutine(main.web.RegisterUser(usernameInput.text, nick.text, birthDate.text, genderText));
            }
            catch (Exception e)
            {
                main.web.message = "Error intente de nuevo";
                advertencia.text = main.web.message;
            }
        });

    }

}
