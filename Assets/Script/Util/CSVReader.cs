using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using UnityEngine;

public class CSVReader
{
    private static readonly string SPLIT_RE = @",(?=(?:[^""]*""[^""]*"")*(?![^""]*""))";
    private static readonly string LINE_SPLIT_RE = @"\r\n|\n\r|\n|\r";
    private static readonly char[] TRIM_CHARS = { '\"' };

    public static List<Dictionary<string, object>> Read(string file, bool isAssetDataLoading = false)
    {
        TextAsset data =
            //isAssetDataLoading  ? AssetDatabase.LoadAssetAtPath<TextAsset>(file) : 
            Resources.Load<TextAsset>(file);

        return Read(data);
    }

    public static List<Dictionary<string, object>> Read(TextAsset data)
    {
        var lines = Regex.Split(data.text, LINE_SPLIT_RE);
        return ReadProcess(lines);

        // const NumberStyles style = NumberStyles.Any;
        // var invariantCulture = CultureInfo.InvariantCulture;

        // var list = new List<Dictionary<string, object>>();

        // var lines = Regex.Split(data.text, LINE_SPLIT_RE);
        // if (lines.Length <= 1) return list;

        // var header = Regex.Split(lines[0], SPLIT_RE);
        // for (var i = 1; i < lines.Length; i++)
        // {
        //     var values = Regex.Split(lines[i], SPLIT_RE);
        //     if (values.Length == 0 || values[0] == "") continue;

        //     var entry = new Dictionary<string, object>();
        //     for (var j = 0; j < header.Length && j < values.Length; j++)
        //     {
        //         string value = values[j];
        //         //value = value.TrimStart(TRIM_CHARS).TrimEnd(TRIM_CHARS).Replace("\\", "");
        //         value = value.TrimStart(TRIM_CHARS).TrimEnd(TRIM_CHARS);
        //         object finalvalue = value;
        //         if (int.TryParse(value, style, invariantCulture, out int n))
        //         {
        //             finalvalue = n;
        //         }
        //         else if (float.TryParse(value, style, invariantCulture, out float f))
        //         {
        //             finalvalue = f;
        //         }
        //         entry[header[j]] = finalvalue;
        //     }
        //     list.Add(entry);
        // }
        // return list;
    }


    public static List<Dictionary<string, object>> Read(string textData)
    {
        var lines = Regex.Split(textData, LINE_SPLIT_RE);
        return ReadProcess(lines);


        // const NumberStyles style = NumberStyles.Any;
        // var invariantCulture = CultureInfo.InvariantCulture;

        // var list = new List<Dictionary<string, object>>();

        // var lines = Regex.Split(textData, LINE_SPLIT_RE);
        // if (lines.Length <= 1) return list;

        // var header = Regex.Split(lines[0], SPLIT_RE);
        // for (var i = 1; i < lines.Length; i++)
        // {
        //     var values = Regex.Split(lines[i], SPLIT_RE);
        //     if (values.Length == 0 || values[0] == "") continue;

        //     var entry = new Dictionary<string, object>();
        //     for (var j = 0; j < header.Length && j < values.Length; j++)
        //     {
        //         string value = values[j];
        //         //value = value.TrimStart(TRIM_CHARS).TrimEnd(TRIM_CHARS).Replace("\\", "");
        //         value = value.TrimStart(TRIM_CHARS).TrimEnd(TRIM_CHARS);
        //         object finalvalue = value;
        //         if (int.TryParse(value, style, invariantCulture, out int n))
        //         {
        //             finalvalue = n;
        //         }
        //         else if (float.TryParse(value, style, invariantCulture, out float f))
        //         {
        //             finalvalue = f;
        //         }
        //         entry[header[j]] = finalvalue;
        //     }
        //     list.Add(entry);
        // }
        // return list;
    }

    public static List<Dictionary<string, object>> ReadProcess(string[] lines)
    {
        const NumberStyles style = NumberStyles.Any;
        var invariantCulture = CultureInfo.InvariantCulture;
        var list = new List<Dictionary<string, object>>();

        if (lines.Length <= 1) return list;

        var header = Regex.Split(lines[0], SPLIT_RE);
        for (var i = 1; i < lines.Length; i++)
        {
            var values = Regex.Split(lines[i], SPLIT_RE);
            if (values.Length == 0 || values[0] == "") continue;

            var entry = new Dictionary<string, object>();
            for (var j = 0; j < header.Length && j < values.Length; j++)
            {
                string value = values[j];
                //value = value.TrimStart(TRIM_CHARS).TrimEnd(TRIM_CHARS).Replace("\\", "");
                value = value.TrimStart(TRIM_CHARS).TrimEnd(TRIM_CHARS);
                object finalvalue = value;
                if (int.TryParse(value, style, invariantCulture, out int n))
                {
                    finalvalue = n;
                }
                else if (float.TryParse(value, style, invariantCulture, out float f))
                {
                    finalvalue = f;
                }
                entry[header[j]] = finalvalue;
            }
            list.Add(entry);
        }
        return list;
    }
}