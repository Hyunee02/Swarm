using System.Collections.Generic;
using UnityEngine;

public class LevelUpUI : MonoBehaviour
{
    public enum UpgradeType
    {
        PlayerStat,
        Skill
    }

    public void SelectUpgrade(UpgradeType type)
    {
        switch(type)
        {
            case UpgradeType.PlayerStat:
                break;

            case UpgradeType.Skill:
                break;
        }
    }
}
