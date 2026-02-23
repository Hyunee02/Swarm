using UnityEngine;

public class MapCtrl : MonoBehaviour
{
    [Header("----- Scripts -----")]
    [SerializeField] PlayerCtrl _player;

    [Header("----- Components -----")]
    [SerializeField] Transform[] _tiles;

    [SerializeField] int _tileSize;
}
