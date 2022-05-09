using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Image timbeBar;
    public float maxTime = 5f;
    float timeLeft;
    float timeInitial;
    public GameObject timeUpText;
    public bool _con = false;
    [SerializeField]
    private GameController _GController;

    private bool _lecturaInicial = true;
    // Start is called before the first frame update
    void Start()
    {
        timeUpText.SetActive(false);
        timbeBar = GetComponent<Image>();
        timeLeft = maxTime;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_con == true) 
        {
            if (_lecturaInicial)
            {
                timeInitial = Time.deltaTime;
                timeLeft = timeInitial + maxTime;
                _lecturaInicial = false;
                Time.timeScale = 1f;
                Debug.Log("Lectura Inicial"+ timeLeft);
                timeUpText.SetActive(false);
            }
            else if (timeLeft > 0) 
            {
                timeLeft -= Time.deltaTime;
                timbeBar.fillAmount = timeLeft / (maxTime+timeInitial);
                Debug.Log("Tiempo_disponible");
            }
            else
            {
                timeUpText.SetActive(true);
                _GController.ActivarEscenaPostJuego();
                Time.timeScale = 0;
                _lecturaInicial = true;
                Debug.Log("Fin_tiempo");

            } 
        }
  
    }
}
