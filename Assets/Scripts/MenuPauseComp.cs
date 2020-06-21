using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPauseComp : MonoBehaviour
{
    public static bool pausado;

    public GameObject menuPausePanel;

    /// <summary>
    /// Metodo para reiniciar a scene
    /// </summary>
    public void Restart()
    {
        print("teste");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// Metodo para pausar o jogo
    /// </summary>
    public void Pause(bool isPausado)
    {
        pausado = isPausado;

        //Se o jogo estiver pausado, timescale recebe 0
        Time.timeScale = (pausado) ? 0 : 1;

        menuPausePanel.SetActive(pausado);
    }

    /// <summary>
    /// Metodo para carregar uma scene
    /// </summary>
    public void CarregaScene(string nomeScene)
    {
        SceneManager.LoadScene(nomeScene);
    }

    // Start is called before the first frame update
    void Start()
    {
        Pause(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
