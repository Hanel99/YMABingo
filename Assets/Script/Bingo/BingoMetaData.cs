using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BingoMetaData
{
    public int No;
    public string User;

    public string L11;// Line 1
    public string L12;
    public string L13;
    public string L14;
    public string L15;

    public string L21;// Line 2
    public string L22;
    public string L23;
    public string L24;
    public string L25;

    public string L31;// Line 3
    public string L32;
    public string L33;
    public string L34;
    public string L35;

    public string L41;// Line 4
    public string L42;
    public string L43;
    public string L44;
    public string L45;

    public string L51; // Line 5
    public string L52;
    public string L53;
    public string L54;
    public string L55;

    public static List<BingoMetaData> Create(List<Dictionary<string, object>> csv)
    {
        List<BingoMetaData> list = new List<BingoMetaData>();
        int cnt = csv.Count;
        int index = 0;

        for (int i = 0; i < cnt; i++)
        {
            index = 0;
            List<object> values = new List<object>(csv[i].Values);

            //이름 값이 빈칸이면 스킵
            if (string.IsNullOrEmpty(values[1].ToString()))
                continue;

            list.Add(new BingoMetaData
            {
                No = values[index++].ToInt(),
                User = values[index++].ToString(),

                L11 = values[index++].ToString(),
                L12 = values[index++].ToString(),
                L13 = values[index++].ToString(),
                L14 = values[index++].ToString(),
                L15 = values[index++].ToString(),

                L21 = values[index++].ToString(),
                L22 = values[index++].ToString(),
                L23 = values[index++].ToString(),
                L24 = values[index++].ToString(),
                L25 = values[index++].ToString(),

                L31 = values[index++].ToString(),
                L32 = values[index++].ToString(),
                L33 = values[index++].ToString(),
                L34 = values[index++].ToString(),
                L35 = values[index++].ToString(),

                L41 = values[index++].ToString(),
                L42 = values[index++].ToString(),
                L43 = values[index++].ToString(),
                L44 = values[index++].ToString(),
                L45 = values[index++].ToString(),

                L51 = values[index++].ToString(),
                L52 = values[index++].ToString(),
                L53 = values[index++].ToString(),
                L54 = values[index++].ToString(),
                L55 = values[index++].ToString(),
            });
        }

        return list;
    }
}
