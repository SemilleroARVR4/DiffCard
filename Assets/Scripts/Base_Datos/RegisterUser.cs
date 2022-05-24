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
    private Main main;


    // Start is called before the first frame update
    void Start()
    {
        main = FindObjectOfType<Main>();
        SubmitButton.onClick.AddListener(() => {
            string genderText = "Masculino";
            if (gender.value == 0) { genderText = "Masculino"; }
            if (gender.value == 1) { genderText = "Femenino"; }
            if (gender.value == 2) { genderText = "Otro"; }
            StartCoroutine(main.web.RegisterUser(usernameInput.text, nick.text,birthDate.text,genderText)); 
        });

    }

}