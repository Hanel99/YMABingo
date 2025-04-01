using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class WeaponListPanel : MonoBehaviour
{
    public static WeaponListPanel instance;

    public GameObject weaponDataPrefab;
    public Transform weaponDataRoot;

    List<RouletteWeaponData> weaponDataList = new List<RouletteWeaponData>();

    public Text rouletteCountText;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }



    void Start()
    {
        weaponDataList.Clear();
        for (WeaponType type = WeaponType.SH1; type < WeaponType.Count; type++)
        {
            GameObject go = Instantiate(weaponDataPrefab, weaponDataRoot);

            weaponDataList.Add(go.GetComponent<RouletteWeaponData>());
        }

        weaponDataRoot.gameObject.SetActive(false);
        weaponDataRoot.gameObject.SetActive(true);

        weaponDataPrefab.SetActive(false);
    }

    public void OnClickRerollButton()
    {
        InGame.instance.ShuffleWeapon();
    }

    public void UpdateWeaponData()
    {
        SetWeaponData();
        rouletteCountText.text = $"{InGame.instance.GetRouletteCount()}";
        InGame.instance.UpdateBoardKanIndexText();
    }

    void SetWeaponData()
    {
        var weaponTypes = InGame.instance.GetWeaponTypes();

        for (int i = 0; i < weaponDataList.Count; ++i)
        {
            var data = weaponDataList[i].GetComponent<RouletteWeaponData>();

            data.name = ConvertExtension.ConvertWeaponTypeToName(weaponTypes[i]);
            data.SetData(i + 1, weaponTypes[i]);
        }
    }

    void OnEnable()
    {
        // UpdateWeaponData();
        foreach (var weaponData in weaponDataList)
            weaponData.weaponButton.UpdateButtonColor(InGame.instance.GetWeaponSelectDic(weaponData.weaponButton.weaponType));

    }
}
