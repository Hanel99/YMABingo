using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Collections;
using UnityEngine.Networking;


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
    }


    void Start()
    {
        // LoadBingoData();
        LoadData();
        Application.targetFrameRate = 60;

        SetBingoBoardUI();
        ShuffleWeapon();
    }


    public void SetBingoBoardUI()
    {
        for (int i = 0; i < bingoData.Count; i++)
        {
            var go = Instantiate(bingoBoardPrefab, bingoBoardPrefab.transform.parent);
            bingoBoards.Add(go.GetComponent<BingoBoard>());
        }
        bingoBoardPrefab.SetActive(false);

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




    // Resources.Load 방식
    public void LoadBingoData()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, "data.csv");


        TextAsset ta = Resources.Load<TextAsset>("CSV/BingoData");
        if (ta)
        {
            List<Dictionary<string, object>> csv = CSVReader.Read(ta);
            bingoData = BingoMetaData.Create(csv);
        }
    }



    //StreamingAsset 방식
    public void LoadData()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, "BingoData.csv");

        // Android, WebGL 같은 환경에서 파일을 읽을 때 WWW 사용
        if (filePath.Contains("://") || filePath.Contains(":///"))
            StartCoroutine(Co_ReadCSV(filePath));
        else
            ReadCSV(filePath);
    }

    IEnumerator Co_ReadCSV(string filePath)
    {
        string result = "";
        using (UnityWebRequest www = UnityWebRequest.Get(filePath))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                result = www.downloadHandler.text;
            }
            else
            {
                Debug.LogError($"Failed to load CSV file: {www.error}");
                yield break;
            }
        }

        ParseCSV(result);
    }

    void ReadCSV(string filePath)
    {
        string result = File.ReadAllText(filePath);
        ParseCSV(result);
    }


    void ParseCSV(string csvText)
    {
        List<Dictionary<string, object>> csv = CSVReader.Read(csvText);
        bingoData = BingoMetaData.Create(csv);
    }


}
