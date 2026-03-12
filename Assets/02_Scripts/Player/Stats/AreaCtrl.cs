using UnityEngine;

public class AreaCtrl : MonoBehaviour
{
    [SerializeField] PlayerStats _stats;

    public void Init()
    {
        transform.position.Scale(new Vector2(_stats.BaseArea, _stats.BaseArea));
    }

    void ApplyArea()
    {
        transform.position.Scale(new Vector2(_stats.Area, _stats.Area));
    }
}
