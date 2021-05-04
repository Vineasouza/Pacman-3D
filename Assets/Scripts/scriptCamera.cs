using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptCamera : MonoBehaviour
{
    private Quaternion rotIni;
    private float rotX;
    public float velRotY = 80;

    // Start is called before the first frame update
    void Start()
    {
        rotIni = transform.localRotation;
        rotX = 0;
    }

    // Update is called once per frame
    void Update()
    {
        rotX += Input.GetAxis("Mouse Y") * Time.deltaTime * velRotY;

        rotX = Mathf.Clamp(rotX, -60, 60);

        Quaternion visaoVertical = Quaternion.AngleAxis(-rotX, Vector3.right);
        transform.localRotation = rotIni * visaoVertical;
    }
}
