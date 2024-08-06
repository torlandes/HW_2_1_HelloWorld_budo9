using TMPro;
using UnityEngine;

public class MagicNumbers : MonoBehaviour
{
    #region Variables

    [SerializeField] private int _max = 10000;
    [SerializeField] private int _min = 1;
    [SerializeField] private TextMeshProUGUI _consoleText;
    private int _guess;
    private int _step;

    #endregion

    #region Unity lifecycle

    private void Start()
    {
        PlayerPrefs.SetInt("DefaultMax", _max);
        PlayerPrefs.SetInt("DefaultMin", _min);
        RestartGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _max = _guess;
            CalculateGuessAndLog();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _min = _guess;
            CalculateGuessAndLog();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _consoleText.text += $"\nУра! Твое число угадано и равно {_guess}!\nКоличество затраченных ходов: {_step}";
            RestartGame();
        }
    }

    #endregion

    #region Private methods

    private void CalculateGuessAndLog()
    {
        _guess = (_max + _min) / 2;
        _step++;
        _consoleText.text += $"\n Твое число равно {_guess}?";
    }

    private void RestartGame()
    {
        _step = 0;
        _min = PlayerPrefs.GetInt("DefaultMin", _min);
        _max = PlayerPrefs.GetInt("DefaultMax", _max);
        _consoleText.text += "\n____________________________";
        _consoleText.text += $"\nПривет в Magic Numbers!\nЗагадай число от {_min} до {_max}";
        CalculateGuessAndLog();
    }

    #endregion
}