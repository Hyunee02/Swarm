using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentSkills : MonoBehaviour
{
    [SerializeField] Image[] skillImgs;

    public void ShowOwnedSkills(HashSet<SkillData> ownedSkills)
    {
        foreach (SkillData skill in ownedSkills)
        {
            Sprite curSkillImg = skill.IconImage;

            for (int i = 0; i < ownedSkills.Count; i++)
            {
                skillImgs[i].sprite = curSkillImg;
                skillImgs[i].enabled = true;
            }
        }
    }
}
