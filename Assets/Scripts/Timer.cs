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
    public GameObject ganador;
    public bool _con = false;
    [SerializeField]
    private GameController _GController;
    [SerializeField]
    private MechanicalControl _Mechanica;

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
            if (timeLeft > 0 && !_Mechanica.gameCompleted)
            {
                timeLeft -= Time.deltaTime;
                timbeBar.fillAmount = timeLeft / (maxTime + timeInitial);
            }
            else if (timeLeft <= 0)
            {
                timeUpText.SetActive(true);
                StartCoroutine(Wait());
                //Time.timeScale = 0;
            }
            else if (_Mechanica.gameCompleted) 
            {
                ganador.SetActive(true);
                StartCoroutine(Wait());
            }
        }
  
    }

    private IEnumerator Wait() 
    {
        yield return new WaitForSeconds(3f);
        _GController.ActivarEscenaPostJuego();
    }

}
