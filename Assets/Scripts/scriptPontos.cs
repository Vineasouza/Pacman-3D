using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scriptPontos : MonoBehaviour
{
    public int placar = 0;
    public Text txtPlacar;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("placar", 0);
    }

    public void incrementar(int soma)
    {
        placar += soma;
        txtPlacar.text = "PONTOS: " + placar;
        PlayerPrefs.SetInt("placar", placar);
    }

    private void Update()
    {
        if(PlayerPrefs.GetInt("placar") == 93)
        {
            SceneManager.LoadScene(3);
        }
    }
}
