using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptWakka : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.tag == "pacman")
        {
            Destroy(gameObject);
            GameObject gamePlacar = GameObject.Find("controlePontos");
            scriptPontos script = gamePlacar.GetComponent<scriptPontos>();
            script.incrementar(1);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
