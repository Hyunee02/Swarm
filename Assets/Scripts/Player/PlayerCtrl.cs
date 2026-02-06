using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    PlayerStats _playerStats;
    PlayerRenderer _renderer;
    Map _map;

    [SerializeField] float _dashCoolTime;
    [SerializeField] float _timer;

    float _maxPos = 20000f;
    Vector2 playerPos;

    
    private void Start()
    {
        playerPos = transform.position;
    }

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 _dir = new Vector3(h, v).normalized;

        transform.position += _dir * _playerStats.Speed * Time.deltaTime;

        _renderer.ChangeRenderer(_dir);

        if (playerPos.x > _maxPos)
            transform.position = playerPos;

    }

    public void Dash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            
        }
    }
}
