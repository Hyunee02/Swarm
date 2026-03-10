using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelUpCard : MonoBehaviour
{
    [SerializeField] TMP_Text _nameText;
    [SerializeField] TMP_Text _explainText;
    [SerializeField] Image _iconImage;

    public void ChangeCardInfo(string name, string explain, Sprite icon)
    {
        _nameText.text = name;
        _explainText.text = explain;
        _iconImage.sprite = icon;
    }
}
