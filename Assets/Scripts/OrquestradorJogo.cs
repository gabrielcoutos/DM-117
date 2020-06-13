using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrquestradorJogo : MonoBehaviour
{

    private const int TamPadrao = 1;

    [Tooltip("Referencia ao espaço basico")]
    public Transform tile;

    [Tooltip("Ponto de inicio da construção")]
    public Vector3 pontoInicio = new Vector3(0, 0, 0);

    [Tooltip("Quantidade de repetições do espaço básico no inicio")]
    public int numCriacaoInicial = 5;

    [Header("Obstaculo")]
    [Tooltip("Referencia do obstaculo")]
    public Transform obstaculo;

    [Tooltip("Quantidade minima obstaculos que vão aparecer em paralelo")]
    [Range(0,4)]
    public int quantidadeMinObstaculoLinha = 1;

    [Tooltip("Quantidade mámixa de obstaculos que vão aparecer em paralelo")]
    [Range(1,5)]
    public int quantidadeMaxObstaculoLinha = 3;

    [Tooltip("Comprimento máximo que o obtaculo pode ter")]
    [Range(1,3)]
    public int compMaximoObstaculo =3;

    // Posição que o próximo tile será criado
    private Vector3 posProximoTile;

    private Quaternion rotationProximoTile = Quaternion.identity;

    // Start is called before the first frame update
    void Start()
    {
        posProximoTile = pontoInicio;

        for(int i = 0; i < numCriacaoInicial; i++)
        {
            CriarProximoEspaco();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CriarProximoEspaco()
    {
        // Cria um novo Tile espaço
        var novoEspaco = Instantiate(tile, posProximoTile, rotationProximoTile);

        posProximoTile = novoEspaco.position;

        // Pega o chão para saber o tamanho e somar no eixo z, assim não teremos nada sobreposto
        var tamEspaco = novoEspaco.Find("Chao").localScale.z;
        posProximoTile.z += tamEspaco;

        CriarObstaculos(novoEspaco);

    }

    public void CriarObstaculos(Transform novoEspaco)
    {
        var obstaculos = new List<GameObject>();

        foreach (Transform filho in novoEspaco)
        {
            if (filho.CompareTag("obsSpawn"))
                obstaculos.Add(filho.gameObject);
        }

        var quantidadeObs = Random.Range(quantidadeMinObstaculoLinha, quantidadeMaxObstaculoLinha + 1); // +1 pq é exclusivo o valor maximo e precisa ser inclusivo
        print("qnt ->" + quantidadeObs);
        for (int i = 0; i < quantidadeObs; i++)
        {
            if (obstaculos.Count > 0)
            {
                var indexObtaculo = Random.Range(0, obstaculos.Count);
                print("index ->" + indexObtaculo);

                var tamObstaculo = Random.Range(1, compMaximoObstaculo + 1);

                Vector3 obstaculoTamanho = new Vector3(tamObstaculo, TamPadrao, TamPadrao);

                obstaculo.localScale = obstaculoTamanho;
           
                var pontoSpawn = obstaculos[indexObtaculo];

                var obsSpawnPos = pontoSpawn.transform.position;

                var novoObs = Instantiate(obstaculo, obsSpawnPos, Quaternion.identity);

                novoObs.SetParent(pontoSpawn.transform);

                obstaculos.RemoveAt(indexObtaculo);
            }
        }
    }

}
