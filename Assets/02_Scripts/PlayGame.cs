using UnityEngine;

public class PlayGame : MonoBehaviour
{
    [SerializeField] PlayerCtrl _playerCtrl;
    [SerializeField] PlayerRenderer _playerRenderer;
    [SerializeField] PlayerStats _playerStats;

    private void Awake()
    {
        _playerCtrl.Initialize(_playerStats, _playerRenderer);
    }

    void Start()
    {
        
    }

    void Update()
    {

    }
}
