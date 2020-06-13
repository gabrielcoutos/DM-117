using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class NaveControlador : MonoBehaviour
{
    // Indica a direção
    enum Direcao
    {
        Direita,
        Esquerda,
        Centro
    }

    [Tooltip("Velocidade de esquivar para os lados")]
    [Range(0, 10)]
    public float velocidadeEsquiva = 1.0f;

    [Tooltip("Velocidade Nave")]
    [Range(0, 10)]
    public float velocidadeNave = 0.25f;

    [Tooltip("Animação de explosao da nave")]
    public GameObject explosao;

    private Rigidbody rb;

    private const float RotDireita = -30;
    private const float RotEsquerda = 30;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var velocidadeHorizontal = Input.GetAxis("Horizontal") * velocidadeEsquiva;

        if (velocidadeHorizontal > 0)
        {
            this.transform.rotation = Quaternion.Euler(0,0,rotacaoNave(Direcao.Direita));
        }
        else if (velocidadeHorizontal < 0)
        {
            this.transform.rotation = Quaternion.Euler(0,0,rotacaoNave(Direcao.Esquerda));
        } else
        {
            this.transform.rotation = Quaternion.Euler(0,0,rotacaoNave(Direcao.Centro));
        }

        rb.AddForce(velocidadeHorizontal, 0, velocidadeNave);
    }


    private float rotacaoNave(Direcao direcao)
    {
        float rot;
        switch (direcao)
        {
            case Direcao.Direita:
                rot = RotDireita;
                break;
            case Direcao.Esquerda:
                rot = RotEsquerda;
                break;
            case Direcao.Centro:
                rot = 0;
                break;
            default:
                rot = 0;
                break;
        }
        return rot;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<ObstaculoComportamento>())
        {
            if (explosao != null)
            {
                var particulas = Instantiate(explosao, transform.position, Quaternion.identity);
                Destroy(particulas, 1.0f);
            }
        }
    }

}
