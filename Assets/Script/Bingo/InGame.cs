using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Collections;
using UnityEngine.Networking;
using System.Text.RegularExpressions;
using System.Linq;
using System;



public class InGame : MonoBehaviour
{
    public static InGame instance;


    List<BingoMetaData> bingoData = new List<BingoMetaData>();
    public GameObject bingoBoardPrefab;
    List<BingoBoard> bingoBoards = new List<BingoBoard>();


    // 무기타입을 순서대로 저장. 해당 무기가 켜졌는지 꺼졌는지 확인용
    Dictionary<WeaponType, bool> weaponSelectDic = new Dictionary<WeaponType, bool>();
    public bool GetWeaponSelectDic(WeaponType type) => weaponSelectDic[type];

    // 노출할 무기타입을 순서대로 저장. 0번부터 순서대로 무기를 표시
    List<WeaponType> weaponTypeList = new List<WeaponType>();
    public List<WeaponType> GetWeaponTypes() => weaponTypeList;
    public WeaponType GetWeaponTypes(int index) => weaponTypeList[index];

    // 셔플을 돌린 횟수
    int rouletteCount = 0;
    public int GetRouletteCount() => rouletteCount;



    int index = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        InitLoadCSVData();
        SetBingoBoardUI();
        Application.targetFrameRate = 60;
    }


    void Start()
    {
        SetBingoBoardUI();
        ShuffleWeapon();
    }


    public void SetBingoBoardUI()
    {
        for (int i = 0; i < bingoData.Count; i++)
        {
            if (bingoBoards.Count <= i)
            {
                var go = Instantiate(bingoBoardPrefab, bingoBoardPrefab.transform.parent);
                bingoBoards.Add(go.GetComponent<BingoBoard>());
                go.SetActive(true);
            }
        }
        bingoBoardPrefab.SetActive(false);

        for (int i = 0; i < bingoBoards.Count; i++)
        {
            if (i < bingoData.Count)
            {
                bingoBoards[i].SetBingoData(bingoData[i]);
            }
            else
            {
                bingoBoards[i].gameObject.SetActive(false);
            }
        }

        weaponSelectDic.Clear();
        weaponTypeList.Clear();
        for (WeaponType type = WeaponType.SH1; type < WeaponType.Count; type++)
        {
            weaponSelectDic.Add(type, false);
            weaponTypeList.Add(type);
        }

        UpdateBoardKanIndexText();
        if (WeaponListPanel.instance != null)
            WeaponListPanel.instance.UpdateWeaponData();
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



    public void InitLoadCSVData()
    {
        LoadCSVDataManager.Instance.LoadDataFromStreamingAsset("BingoData", (data) =>
        {
            List<Dictionary<string, object>> csv = CSVReader.Read(data);
            bingoData = BingoMetaData.Create(csv);
        });
    }


    public void UpdateBingoDataFromSheetData()
    {
        LoadCSVDataManager.Instance.LoadDataFromGoogleSheet((data) =>
        {
            ModeSelectPanel.instance.SetServerUpdateResultText("업데이트 성공!");
            SetBingoBoardUI();
        });
    }
}
