using TMPro;
using UnityEngine;

public class SumNumbers : MonoBehaviour
{
    #region Variables

    [SerializeField] private int _maxSum = 50;
    [SerializeField] private TextMeshProUGUI _consoleText;
    private int _step;
    private int _sum;

    #endregion

    #region Unity lifecycle

    private void Start()
    {
        RestartGame();
    }

    private void Update()
    {
        for (int i = 1; i <= 9; i++)
        {
            KeyCode key = (KeyCode)(i + (int)KeyCode.Alpha0);
            if (Input.GetKeyDown(key))
            {
                _sum += i;
                _step++;
                _consoleText.text += $"\nТекущая сумма: {_sum}";

                if (_sum >= _maxSum)
                {
                    _consoleText.text += $"\nМаксимальная сумма: {_maxSum}";
                    _consoleText.text += $"\nИгра окончена! Количество затраченных ходов: {_step}";
                    RestartGame();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _sum = 0;
            _step = 0;
            _consoleText.text += $"\nСБРОС. Текущая сумма: {_sum}.";
        }
    }

    #endregion

    #region Private methods

    private void RestartGame()
    {
        _sum = 0;
        _step = 0;
        _consoleText.text += "\nВведите число.";
    }

    #endregion
}