using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptPacman : MonoBehaviour
{
    private Rigidbody rbd;
    public float vel = 10;
    private AudioSource som;
    private Quaternion rotIni;
    private float rotY;
    public float velRotX = 80;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        rbd = GetComponent<Rigidbody>();
        som = GetComponent<AudioSource>();
        rotIni = transform.localRotation;
        rotY = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "wakka")
        {
            som.Play();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if(collision.collider.tag == "portal")
        {
            if (transform.position.x < 0)
            {
                rbd.position = new Vector3(((-1)*transform.position.x) - 5, transform.position.y, transform.position.z);
                transform.Rotate(Vector3.back);
            }
            else if(transform.position.x > 0) {
                rbd.position = new Vector3(((-1) * transform.position.x) + 5, transform.position.y, transform.position.z);
                transform.Rotate(Vector3.back);
            }
        }

        if (collision.gameObject.tag == "wakka")
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>(), true);
        }

    }

    // Update is called once per frame
    void Update()
    {
        float moveFrente = Input.GetAxis("Vertical");
        float moveLados = Input.GetAxis("Horizontal");

        rotY += Input.GetAxis("Mouse X") * Time.deltaTime * velRotX;
        Quaternion visaoHorizontal = Quaternion.AngleAxis(rotY, Vector3.up);
        transform.localRotation = rotIni * visaoHorizontal;

        rbd.velocity = transform.TransformDirection(new Vector3(moveLados * vel, rbd.velocity.y, moveFrente * vel));
    }
}
