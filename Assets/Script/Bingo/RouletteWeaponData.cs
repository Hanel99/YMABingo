using UnityEngine;
using UnityEngine.UI;

public class RouletteWeaponData : MonoBehaviour
{
    public Text weaponIndex;
    public WeaponButton weaponButton;

    public void SetData(int index, WeaponType weaponType)
    {
        weaponIndex.text = $"{index}.";
        weaponButton.SetWeaponType(weaponType);
    }
}
