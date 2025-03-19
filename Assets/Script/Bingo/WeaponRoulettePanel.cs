using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class WeaponRoulettePanel : MonoBehaviour
{

    public Text numberText;
    public Text weaponText;
    public Text rerollText;
    public GameObject rerollObject;

    int count = -1;
    bool isAnimation = false;


    void Start()
    {
        numberText.text = $"No.0";
        weaponText.text = $"무슨 무기가 나올까?";
    }

    public void UpdateUI()
    {
        StartCoroutine(Co_RouletteAnimation());
    }

    IEnumerator Co_RouletteAnimation()
    {
        numberText.text = "";
        weaponText.text = ".";
        yield return new WaitForSeconds(0.5f);
        weaponText.text = ". .";
        yield return new WaitForSeconds(0.5f);
        weaponText.text = ". . .";
        yield return new WaitForSeconds(0.5f);

        numberText.text = $"No.{count + 1}";
        numberText.transform.DOScale(1f, 0.4f).From(1.5f).SetEase(Ease.InOutBack);

        weaponText.text = ConvertExtension.ConvertWeaponTypeToName(InGame.instance.GetWeaponTypes(count));
        weaponText.transform.DOScale(1f, 0.7f).From(0.5f).SetEase(Ease.OutBack);

        isAnimation = false;
    }




    public void OnClickNextButton()
    {
        if (isAnimation) return;

        rerollObject.SetActive(false);
        isAnimation = true;
        count++;
        UpdateUI();
    }

    public void OnClickShuffleWeapon()
    {
        InGame.instance.ShuffleWeapon();
        rerollText.text = InGame.instance.GetRouletteCount().ToString();
    }
}
