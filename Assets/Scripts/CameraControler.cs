using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    [Tooltip("Quem a camera acompanha")]
    public Transform alvo;
    [Tooltip("offset da camera em relação ao alvo")]
    public Vector3 offset = new Vector3(0,3,-6);
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if (alvo != null)
        {
            transform.position = alvo.position + offset;
            transform.LookAt(alvo);
        }
    }
}
