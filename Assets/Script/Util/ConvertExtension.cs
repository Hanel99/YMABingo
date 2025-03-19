using DG.Tweening;
using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public static class ConvertExtension
{

    public static string ReplaceNewLine(this object obj) => obj.ToString().Replace("\\n", System.Environment.NewLine).Replace("\n", System.Environment.NewLine);

    private static bool IsEmpty(object obj) => string.IsNullOrEmpty(obj.ToString());

    public static bool ToBool(this object obj) => !IsEmpty(obj) && Convert.ToBoolean(obj);

    public static int ToInt(this object obj) => IsEmpty(obj) ? -1 : Convert.ToInt32(obj);

    public static float ToFloat(this object obj)
    {
        if (IsEmpty(obj)) return -1f;
        if (decimal.TryParse(obj.ToString().ToString(CultureInfo.InvariantCulture), NumberStyles.Any, CultureInfo.InvariantCulture, out var result))
            return (float)result;
        return -1f;
    }

    public static double ToDouble(this object obj)
    {
        if (IsEmpty(obj)) return -1;
        if (decimal.TryParse(obj.ToString().ToString(CultureInfo.InvariantCulture), NumberStyles.Any, CultureInfo.InvariantCulture, out var result))
            return (double)result;
        return -1f;
    }

    public static double ToDoubleFullLength(this object obj)
    {
        if (IsEmpty(obj)) return -1;
        if (double.TryParse(obj.ToString().ToString(CultureInfo.InvariantCulture), NumberStyles.Any, CultureInfo.InvariantCulture, out var result))
            return (double)result;
        return -1f;
    }

    public static string ConvertWeaponTypeToName(WeaponType weaponType) =>
        weaponType switch
        {
            WeaponType.SH1 => "새싹 슈터",
            WeaponType.SH2 => "스플랫 슈터",
            WeaponType.SH3 => "프라임 슈터",
            WeaponType.SH4 => "프로모델러",
            WeaponType.SH5 => "N-ZAP",
            WeaponType.SH6 => "볼드 마커",
            WeaponType.SH7 => "샤프 마커",
            WeaponType.SH8 => ".52 갤런",
            WeaponType.SH9 => ".96 갤런",
            WeaponType.SH10 => "L3 릴건",
            WeaponType.SH11 => "H3 릴건",
            WeaponType.SH12 => "제트 스위퍼",
            WeaponType.SH13 => "보틀 가이저",
            WeaponType.SH14 => "스페이스 슈터",
            WeaponType.R1 => "스플랫 롤러",
            WeaponType.R2 => "카본 롤러",
            WeaponType.R3 => "다이너모 롤러",
            WeaponType.R4 => "베리어블 롤러",
            WeaponType.R5 => "와이드 롤러",
            WeaponType.C1 => "스플랫 차저",
            WeaponType.C2 => "스플랫 스코프",
            WeaponType.C3 => "스퀵 클린",
            WeaponType.C4 => "리터 4K",
            WeaponType.C5 => "4K 스코프",
            WeaponType.C6 => "14식 대나무 총",
            WeaponType.C7 => "소이 튜버",
            WeaponType.C8 => "R-PEN",
            WeaponType.BU1 => "버킷 슬로셔",
            WeaponType.BU2 => "물통",
            WeaponType.BU3 => "스크루 슬로셔",
            WeaponType.BU4 => "오버플로셔",
            WeaponType.BU5 => "익스플로셔",
            WeaponType.BU6 => "몹링",
            WeaponType.SP1 => "배럴 스피너",
            WeaponType.SP2 => "스플랫 스피너",
            WeaponType.SP3 => "하이드런트",
            WeaponType.SP4 => "노틸러스 47",
            WeaponType.SP5 => "쿠겔 슈라이버",
            WeaponType.SP6 => "이그재미너",
            WeaponType.M1 => "스플랫 머누버",
            WeaponType.M2 => "듀얼 스위퍼",
            WeaponType.M3 => "스퍼터리",
            WeaponType.M4 => "쿼드 호퍼",
            WeaponType.M5 => "켈빈 525",
            WeaponType.M6 => "소방 FF",
            WeaponType.U1 => "파라 셀터",
            WeaponType.U2 => "캠핑 셀터",
            WeaponType.U3 => "스파이 가젯",
            WeaponType.U4 => "24식 도돌이 우산",
            WeaponType.BL1 => "핫 블래스터",
            WeaponType.BL2 => "롱 블래스터",
            WeaponType.BL3 => "래피드 블래스터",
            WeaponType.BL4 => "R 블래스터 엘리트",
            WeaponType.BL5 => "노바 블래스터",
            WeaponType.BL6 => "크래시 블래스터",
            WeaponType.BL7 => "S-BLAST",
            WeaponType.BT1 => "호쿠사이",
            WeaponType.BT2 => "파블로",
            WeaponType.BT3 => "빈센트",
            WeaponType.H1 => "트라이 스트링거",
            WeaponType.H2 => "LACT-450",
            WeaponType.H3 => "플루이드",
            WeaponType.W1 => "드라이브 와이퍼",
            WeaponType.W2 => "사무 와이퍼",
            WeaponType.W3 => "덴탈 와이퍼",

            _ => weaponType.ToString()
        };

    public static WeaponType ConvertWeaponNameToWeaponType(string name) =>
        name switch
        {
            "새싹 슈터" => WeaponType.SH1,
            "스플랫 슈터" => WeaponType.SH2,
            "프라임 슈터" => WeaponType.SH3,
            "프로모델러" => WeaponType.SH4,
            "N-ZAP" => WeaponType.SH5,
            "볼드 마커" => WeaponType.SH6,
            "샤프 마커" => WeaponType.SH7,
            ".52 갤런" => WeaponType.SH8,
            ".96 갤런" => WeaponType.SH9,
            "L3 릴건" => WeaponType.SH10,
            "H3 릴건" => WeaponType.SH11,
            "제트 스위퍼" => WeaponType.SH12,
            "보틀 가이저" => WeaponType.SH13,
            "스페이스 슈터" => WeaponType.SH14,
            "스플랫 롤러" => WeaponType.R1,
            "카본 롤러" => WeaponType.R2,
            "다이너모 롤러" => WeaponType.R3,
            "베리어블 롤러" => WeaponType.R4,
            "와이드 롤러" => WeaponType.R5,
            "스플랫 차저" => WeaponType.C1,
            "스플랫 스코프" => WeaponType.C2,
            "스퀵 클린" => WeaponType.C3,
            "리터 4K" => WeaponType.C4,
            "4K 스코프" => WeaponType.C5,
            "14식 대나무 총" => WeaponType.C6,
            "소이 튜버" => WeaponType.C7,
            "R-PEN" => WeaponType.C8,
            "버킷 슬로셔" => WeaponType.BU1,
            "물통" => WeaponType.BU2,
            "스크루 슬로셔" => WeaponType.BU3,
            "오버플로셔" => WeaponType.BU4,
            "익스플로셔" => WeaponType.BU5,
            "몹링" => WeaponType.BU6,
            "배럴 스피너" => WeaponType.SP1,
            "스플랫 스피너" => WeaponType.SP2,
            "하이드런트" => WeaponType.SP3,
            "노틸러스 47" => WeaponType.SP4,
            "쿠겔 슈라이버" => WeaponType.SP5,
            "이그재미너" => WeaponType.SP6,
            "스플랫 머누버" => WeaponType.M1,
            "듀얼 스위퍼" => WeaponType.M2,
            "스퍼터리" => WeaponType.M3,
            "쿼드 호퍼" => WeaponType.M4,
            "켈빈 525" => WeaponType.M5,
            "소방 FF" => WeaponType.M6,
            "파라 셀터" => WeaponType.U1,
            "캠핑 셀터" => WeaponType.U2,
            "스파이 가젯" => WeaponType.U3,
            "24식 도돌이 우산" => WeaponType.U4,
            "핫 블래스터" => WeaponType.BL1,
            "롱 블래스터" => WeaponType.BL2,
            "래피드 블래스터" => WeaponType.BL3,
            "R 블래스터 엘리트" => WeaponType.BL4,
            "노바 블래스터" => WeaponType.BL5,
            "크래시 블래스터" => WeaponType.BL6,
            "S-BLAST" => WeaponType.BL7,
            "호쿠사이" => WeaponType.BT1,
            "파블로" => WeaponType.BT2,
            "빈센트" => WeaponType.BT3,
            "트라이 스트링거" => WeaponType.H1,
            "LACT-450" => WeaponType.H2,
            "플루이드" => WeaponType.H3,
            "드라이브 와이퍼" => WeaponType.W1,
            "사무 와이퍼" => WeaponType.W2,
            "덴탈 와이퍼" => WeaponType.W3,

            _ => WeaponType.None
        };
}