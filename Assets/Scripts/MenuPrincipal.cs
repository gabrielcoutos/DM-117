using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    /// <summary>
    /// Metodo para carregar uma scene
    /// </summary>
    public void CarregaScene(string nomeScene)
    {
        SceneManager.LoadScene(nomeScene);
    }
}
