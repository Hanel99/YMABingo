using UnityEngine;
using UnityEngine.UI;

public class BingoKan : MonoBehaviour
{
    public Image bg;
    public Text indexText;

    WeaponType weaponType;
    bool isOn = false;
    public bool IsOn => isOn;


    public void SetWeaponType(WeaponType type)
    {
        weaponType = type;
    }

    public void SetWeaponType(string weaponName)
    {
        var type = ConvertExtension.ConvertWeaponNameToWeaponType(weaponName);
        weaponType = type;
    }
    public void UpdateWeaponIndex()
    {
        var index = InGame.instance.GetWeaponTypes().FindIndex(x => x == weaponType);
        indexText.text = $"{index + 1}";
    }



    public void CheckAndShowWeapon(WeaponType type)
    {
        isOn = isOn || weaponType == type;
        ShowLight(isOn);
    }

    public void OffWeapon(WeaponType type)
    {
        if (weaponType == type)
            isOn = false;
        ShowLight(isOn);
    }

    public void ShowLight(bool show)
    {
        isOn = show;
        bg.color = isOn ? Color.cyan : Color.white;
    }

    public void ShowBingoLight()
    {
        bg.color = Color.yellow;
    }

}
