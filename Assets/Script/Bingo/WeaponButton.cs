using UnityEngine;
using UnityEngine.UI;

public class WeaponButton : MonoBehaviour
{
    public WeaponType weaponType;
    public Text weaponName;

    bool isOn = false;


    public void SetWeaponType(WeaponType weaponType)
    {
        this.weaponType = weaponType;
        weaponName.text = ConvertExtension.ConvertWeaponTypeToName(weaponType);
        isOn = false;
    }

    public void UpdateButtonColor(bool isOn)
    {
        this.isOn = isOn;
        gameObject.GetComponent<Image>().color = isOn ? Color.cyan : Color.white;
    }

    public void OnClickButton()
    {
        isOn = !isOn;
        gameObject.GetComponent<Image>().color = isOn ? Color.cyan : Color.white;

        InGame.instance.UpdateWeaponSelectDic(weaponType, isOn);
        InGame.instance.CheckAllKanWeapon(weaponType, isOn);
    }
}
