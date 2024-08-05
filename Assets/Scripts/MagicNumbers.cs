using UnityEngine;

public class MagicNumbers : MonoBehaviour
{
    #region Variables

    [SerializeField] private int _max = 10000;
    [SerializeField] private int _min = 1;

    private int _guess;

    #endregion

    #region Unity lifecycle

    private void Start()
    {
        Debug.Log($"Привет в Magic Numbers. Загадай число от {_min} до {_max}");

        CalculateGuessAndLog();
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
            _max = _guess;
            CalculateGuessAndLog();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log($"Ура! Твое число угадано и равно {_guess}");
        }
    }

    #endregion

    #region Private methods

    private void CalculateGuessAndLog()
    {
        _guess = (_max + _min) / 2;
        Debug.Log($"Твое число равно {_guess}?");
    }

    #endregion
}