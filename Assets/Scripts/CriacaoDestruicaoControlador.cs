using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriacaoDestruicaoControlador : MonoBehaviour
{
    [Tooltip("Tempo para destruir os itens deixados para trás")]
    public float tempoDestruir = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider endPoint)
    {
        if (endPoint.GetComponent<NaveControlador>())
        {
            GameObject.FindObjectOfType<OrquestradorJogo>().CriarProximoEspaco();
            Destroy(this.transform.parent.gameObject, tempoDestruir);
        }
    }
}
