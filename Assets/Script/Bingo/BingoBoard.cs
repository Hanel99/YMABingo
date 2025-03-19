using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class BingoBoard : MonoBehaviour
{

    public Text userName;
    public Text bingoCountText;
    public Image bg;
    public BingoKan[] bingoKans;

    int bingoCount = 0;

    Color32[] bgColors = new Color32[]
    {
        new Color32(233, 242, 255, 255), //E8F2FF 0
        new Color32(104, 238, 194, 255), //69EFC3 1
        new Color32(55, 168, 255, 255), //36A8FF 2
        new Color32(211, 83, 255, 255), //D353FF 3
    };


    void Awake()
    {
        for (int i = 0; i < bingoKans.Length; i++)
        {
            bingoKans[i].ShowLight(false);
        }
    }

    public void SetBingoData(BingoMetaData data)
    {
        userName.text = data.User;
        bingoCountText.text = $"{bingoCount}";
        bg.color = bgColors[0];

        bingoKans[0].SetWeaponType(data.L11);
        bingoKans[1].SetWeaponType(data.L12);
        bingoKans[2].SetWeaponType(data.L13);
        bingoKans[3].SetWeaponType(data.L14);
        bingoKans[4].SetWeaponType(data.L15);
        bingoKans[5].SetWeaponType(data.L21);
        bingoKans[6].SetWeaponType(data.L22);
        bingoKans[7].SetWeaponType(data.L23);
        bingoKans[8].SetWeaponType(data.L24);
        bingoKans[9].SetWeaponType(data.L25);
        bingoKans[10].SetWeaponType(data.L31);
        bingoKans[11].SetWeaponType(data.L32);
        bingoKans[12].SetWeaponType(data.L33);
        bingoKans[13].SetWeaponType(data.L34);
        bingoKans[14].SetWeaponType(data.L35);
        bingoKans[15].SetWeaponType(data.L41);
        bingoKans[16].SetWeaponType(data.L42);
        bingoKans[17].SetWeaponType(data.L43);
        bingoKans[18].SetWeaponType(data.L44);
        bingoKans[19].SetWeaponType(data.L45);
        bingoKans[20].SetWeaponType(data.L51);
        bingoKans[21].SetWeaponType(data.L52);
        bingoKans[22].SetWeaponType(data.L53);
        bingoKans[23].SetWeaponType(data.L54);
        bingoKans[24].SetWeaponType(data.L55);
    }

    public void UpdateBoardKanIndexText()
    {
        for (int i = 0; i < bingoKans.Length; i++)
        {
            bingoKans[i].UpdateWeaponIndex();
        }
    }



    public void CheckAllKanWeapon(WeaponType weapon, bool isOn)
    {
        for (int i = 0; i < bingoKans.Length; i++)
        {
            if (isOn)
                bingoKans[i].CheckAndShowWeapon(weapon);
            else
                bingoKans[i].OffWeapon(weapon);
        }

        CalcBingoCount();
    }

    void CalcBingoCount()
    {
        int tempBingoCount = 0;
        bool isBingo = true;

        // 1. 가로 빙고 확인
        for (int i = 0; i < 5; ++i)
        {
            isBingo = true;
            for (int j = 0; j < 5; ++j)
            {
                if (!bingoKans[i * 5 + j].IsOn)
                {
                    isBingo = false;
                    break;
                }
            }

            if (isBingo)
            {
                tempBingoCount++;
                for (int j = 0; j < 5; ++j)
                {
                    bingoKans[i * 5 + j].ShowBingoLight();
                }
            }
        }

        // 2. 세로 빙고 확인
        for (int i = 0; i < 5; ++i)
        {
            isBingo = true;
            for (int j = 0; j < 5; ++j)
            {
                if (!bingoKans[i + j * 5].IsOn)
                {
                    isBingo = false;
                    break;
                }
            }

            if (isBingo)
            {
                tempBingoCount++;
                for (int j = 0; j < 5; ++j)
                {
                    bingoKans[i + j * 5].ShowBingoLight();
                }
            }
        }

        // 3. 대각선 빙고 확인
        isBingo = true;
        for (int i = 0; i < 5; ++i)
        {
            if (!bingoKans[i * 6].IsOn)
            {
                isBingo = false;
                break;
            }
        }

        if (isBingo)
        {
            tempBingoCount++;
            for (int i = 0; i < 5; ++i)
            {
                bingoKans[i * 6].ShowBingoLight();
            }
        }

        isBingo = true;
        for (int i = 0; i < 5; ++i)
        {
            if (!bingoKans[4 + i * 4].IsOn)
            {
                isBingo = false;
                break;
            }
        }

        if (isBingo)
        {
            tempBingoCount++;
            for (int i = 0; i < 5; ++i)
            {
                bingoKans[4 + i * 4].ShowBingoLight();
            }
        }


        // 4. 빙고 갯수 업데이트
        bingoCount = tempBingoCount;
        bingoCountText.text = $"{bingoCount}";

        bg.color = bgColors[math.min(bingoCount, 3)];
    }
}
