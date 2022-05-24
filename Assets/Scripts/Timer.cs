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

        int[] optiontime = new int[] {100,100,100};
        timeUpText.SetActive(false);
        timbeBar = GetComponent<Image>();
        int numparejas = _Mechanica.griCols;

        switch (numparejas) 
        {
            case 4:
                maxTime = optiontime[0];
                break;
            case 6:
                maxTime = optiontime[1];
                break;
            case 8:
                maxTime = optiontime[2];
                break;

        }
        main.MatchGameInfo.SetTimeLimit(maxTime);
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
                main.PerformanceInfo.SetFinalTime(timeLeft);
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
