using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Image _hpBar;
    [SerializeField] Image _expGage;
    [SerializeField] Canvas _levelUpCanvas;

    public void UpdateHpBar(float hp, float maxHp)
    {
        _hpBar.fillAmount = hp / maxHp;
    }

    public void UpdateExpGage(float xp, float needXp)
    {
        _expGage.fillAmount = xp / needXp;
    }

    public void ActiveLevelUpCanv()
    {
        _levelUpCanvas.enabled = true;
        Time.timeScale = 0;
    }

    public void DeActiveLevelUpCanv()
    {
        _levelUpCanvas.enabled = false;
        Time.timeScale = 1f;
    }
}
