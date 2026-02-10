using UnityEngine;

[CreateAssetMenu(fileName = "MonsterData", menuName = "Data/Monster")]
public class MonsterStats : ScriptableObject
{
    public float speed;
    public float power;
    public float hp;
    public float xp;
    public int level;
}
