using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] Transform _player;

    private void Update()
    {
        Vector3 playerPos = _player.position;
        Vector3 cameraPos = transform.position;

        cameraPos.x = playerPos.x;
        cameraPos.y = playerPos.y;

        transform.position = cameraPos;
    }
}
