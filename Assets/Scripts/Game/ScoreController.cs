using TMPro;
using Unity.Netcode;
using UnityEngine;


/// <summary>
/// � respons�vel por tratar da pontua��o de cada jogador e exibir-la no ecr�.
/// </summary>
public class ScoreController : NetworkBehaviour
{
    /* ATRIBUTOS PRIVADOS */

    // vari�vel para a pontua��o por ronda
    [SerializeField] private int _pointsPerRound;

    // para os componentes da UI - texto da pontua��o de cada jogador
    [SerializeField] private GameObject _scorePlayer1;
    [SerializeField] private GameObject _scorePlayer2;


    /* M�TODOS */

    public int AddScore()
    {
        return _pointsPerRound;
    }

    public void DisplayScoreObjectText(int winnerID, int score)
    {
        if (winnerID == 1)
        {
            _scorePlayer1.GetComponent<TextMeshProUGUI>().text = score.ToString();
        }
        else if (winnerID == 2)
        {
            _scorePlayer2.GetComponent<TextMeshProUGUI>().text = score.ToString();
        }
    }
}