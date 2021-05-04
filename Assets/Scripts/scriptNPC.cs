using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class scriptNPC : MonoBehaviour
{
    public GameObject PC;
    private NavMeshAgent agente;
    public float maxDist = 3.5f;
    public float maxDistPC = 15f;
    private bool perseguicao = false;
    public GameObject[] waypoints = new GameObject[4];
    private int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        proximo();
    }

    private void proximo()
    {
        agente.SetDestination(waypoints[index++].transform.position);
        
        if(index >= waypoints.Length)
        {
            index = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "pacman")
        {
            Destroy(gameObject);
            SceneManager.LoadScene(2);

        }

        if (collision.gameObject.tag == "wakka")
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>() , true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Vector3.Distance(transform.position, PC.transform.position));
        if(Vector3.Distance(transform.position, PC.transform.position) <= maxDistPC || perseguicao)
        {
            agente.SetDestination(PC.transform.position);
            perseguicao = true;
        }

        else if(Vector3.Distance(transform.position, agente.destination) <= maxDist)
        {
            proximo();
        }
        //agente.SetDestination(PC.transform.position);
    }
}
