using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] TMP_Text _timerText;

    [SerializeField] float _timer;

    private void Update()
    {
        _timer = Time.deltaTime;
    }
}
