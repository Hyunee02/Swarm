using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentSkills : MonoBehaviour
{
    [SerializeField] Image[] skillImgs;

    public void ShowCurrentSkills(List<SkillData> currentSkill)
    {
        for (int i = 0; i < currentSkill.Count; i++)
        {
            Sprite curSkillImg = currentSkill[i].IconImage;

            skillImgs[i].sprite = curSkillImg;
            skillImgs[i].enabled = true;
        }
    }
}
