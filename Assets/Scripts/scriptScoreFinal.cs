using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class scriptScoreFinal : MonoBehaviour
{
    public Text txtScore;
    private int resultado;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        resultado = PlayerPrefs.GetInt("placar");
        txtScore.text = "Score: " + resultado;
    }
}
