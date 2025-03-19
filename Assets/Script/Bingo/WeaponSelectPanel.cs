using System.Collections.Generic;
using UnityEngine;

public class WeaponSelectPanel : MonoBehaviour
{
    public GameObject weaponButtonPrefab;
    public Transform buttonRoot;


    List<WeaponButton> buttonList = new List<WeaponButton>();



    void Start()
    {
        for (WeaponType type = WeaponType.SH1; type < WeaponType.Count; type++)
        {
            GameObject go = Instantiate(weaponButtonPrefab, buttonRoot);
            go.name = ConvertExtension.ConvertWeaponTypeToName(type);
            go.GetComponent<WeaponButton>().SetWeaponType(type);

            buttonList.Add(go.GetComponent<WeaponButton>());
        }

        weaponButtonPrefab.SetActive(false);
    }

    void OnEnable()
    {
        foreach (var button in buttonList)
            button.UpdateButtonColor(InGame.instance.GetWeaponSelectDic(button.weaponType));

    }


}
