using UnityEngine;

public class AreaCtrl : MonoBehaviour
{
    [SerializeField] PlayerStats _stats;
    [SerializeField] StatCalculator _statCal;

    public void Init()
    {
        transform.position.Scale(new Vector2(_stats.BaseArea, _stats.BaseArea));
    }

    void ApplyArea()
    {
        transform.position.Scale(new Vector2(_statCal.Area, _statCal.Area));
    }
}
