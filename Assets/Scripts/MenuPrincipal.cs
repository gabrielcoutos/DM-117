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

#if UNITY_ADS
        if (UnityAdControl.showAds) {
            UnityAdControl.ShowAd();
        }
#endif
    }

    // Start is called before the first frame update
    void Start()
    {
        UnityAdControl.InitializeAds();
    }
    // Update is called once per frame
    void Update()
    {

    }
}
