using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstaculoComportamento : MonoBehaviour
{
    [Tooltip("Tempo antes de reiniciar o game")]
    public float tempoEspera = 3.0f;

    [Tooltip("Animação da explosão do obstaculo")]
    public GameObject explosao;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            verificaSeDestroiObjeto(Input.mousePosition);
        }
    }

    private void verificaSeDestroiObjeto(Vector2 pos)
    {
        Ray cliqueRay = Camera.main.ScreenPointToRay(pos);

        RaycastHit hit;

        if(Physics.Raycast(cliqueRay,out hit))
        {
            hit.transform.SendMessage("DestroiObstaculo", SendMessageOptions.DontRequireReceiver);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        // Verfica a colisão
        if (collision.gameObject.GetComponent<NaveControlador>())
        {
            Destroy(collision.gameObject);
            Invoke("ResetaJogo", tempoEspera);
        }
    }

    /// <sumary>
    /// Reinicia o jogo
    ///</sumary>
    void ResetaJogo()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void DestroiObstaculo()
    {
        if(explosao != null)
        {
            var particulas = Instantiate(explosao, transform.position, Quaternion.identity);
            Destroy(particulas, 1.0f);
        }

        Destroy(this.gameObject);
    }
}
