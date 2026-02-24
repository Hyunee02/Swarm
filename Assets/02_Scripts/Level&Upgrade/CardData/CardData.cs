using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "CardData", menuName = "Data/Card")]
public class CardData : ScriptableObject
{
    [SerializeField] string _name;
    [SerializeField] string _info;
    [SerializeField] Image _icon;

    public string Name => _name;
    public string Info => _info;
    public Image Icon => _icon;


}
