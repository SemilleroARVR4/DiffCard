using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Image timbeBar;
    public int maxTime = 30;
    float timeLeft;
    float timeInitial;
    public GameObject timeUpText;
    public GameObject ganador;
    public bool _con = false;
    [SerializeField]
    private GameController _GController;
    [SerializeField]
    private MechanicalControl _Mechanica;
    private Main main;

    // Start is called before the first frame update
    void Start()
    {
        main = FindObjectOfType<Main>();

        timeUpText.SetActive(false);
        timbeBar = GetComponent<Image>();

        maxTime = main.MatchGameInfo.Timelimit;
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

                main.PerformanceInfo.SetAvgCouples(_Mechanica.avgPareja);
                main.PerformanceInfo.SetFinalTime(maxTime);
                main.PerformanceInfo.SetScore(_Mechanica._score);

                StartCoroutine(Wait());
                //Time.timeScale = 0;
            }
            else if (_Mechanica.gameCompleted) 
            {
                main.PerformanceInfo.SetAvgCouples(_Mechanica.avgPareja);
                main.PerformanceInfo.SetFinalTime(maxTime - timeLeft);
                main.PerformanceInfo.SetScore(_Mechanica._score);

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
