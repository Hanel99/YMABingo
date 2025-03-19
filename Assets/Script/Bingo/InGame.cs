using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class InGame : MonoBehaviour
{
    public static InGame instance;


    List<BingoMetaData> bingoData = new List<BingoMetaData>();
    public List<BingoBoard> bingoBoards = new List<BingoBoard>();


    Dictionary<WeaponType, bool> weaponSelectDic = new Dictionary<WeaponType, bool>();
    public bool GetWeaponSelectDic(WeaponType type) => weaponSelectDic[type];
    List<WeaponType> weaponTypeList = new List<WeaponType>();
    public List<WeaponType> GetWeaponTypes() => weaponTypeList;
    public WeaponType GetWeaponTypes(int index) => weaponTypeList[index];
    int rouletteCount = 0;
    public int GetRouletteCount() => rouletteCount;



    int index = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    void Start()
    {
        LoadBingoData();
        Application.targetFrameRate = 60;


        for (int i = 0; i < bingoBoards.Count; i++)
        {
            bingoBoards[i].SetBingoData(bingoData[index]);
            index++;
        }

        for (WeaponType type = WeaponType.SH1; type < WeaponType.Count; type++)
        {
            weaponSelectDic.Add(type, false);
            weaponTypeList.Add(type);
        }

        ShuffleWeapon();

        UpdateBoardKanIndexText();
    }


    public void ShuffleWeapon()
    {
        weaponTypeList.Shuffle();
        rouletteCount++;
        UpdateBoardKanIndexText();

        if (WeaponListPanel.instance != null)
            WeaponListPanel.instance.UpdateWeaponData();
    }




    public void CheckAllKanWeapon(WeaponType weapon, bool isOn)
    {
        for (int i = 0; i < bingoBoards.Count; i++)
        {
            bingoBoards[i].CheckAllKanWeapon(weapon, isOn);
        }
    }



    public void UpdateWeaponSelectDic(WeaponType weapon, bool isOn)
    {
        weaponSelectDic[weapon] = isOn;
    }
    public void UpdateBoardKanIndexText()
    {
        for (int i = 0; i < bingoBoards.Count; i++)
        {
            bingoBoards[i].UpdateBoardKanIndexText();
        }
    }




    public void LoadBingoData()
    {
        TextAsset ta = Resources.Load<TextAsset>("CSV/BingoData");
        if (ta)
        {
            List<Dictionary<string, object>> csv = CSVReader.Read(ta);
            bingoData = BingoMetaData.Create(csv);
        }
    }
}
