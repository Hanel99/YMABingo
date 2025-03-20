using System.Collections;
using System.Collections.Generic;
using Coffee.UIExtensions;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class WeaponRoulettePanel : MonoBehaviour
{

    public Text numberText;
    public Text weaponText;
    public Text rerollText;
    public GameObject rerollObject;
    public GameObject nextButton;
    public List<UIParticle> particles = new List<UIParticle>();
    public List<Image> dotImages = new List<Image>();


    int count = -1;
    bool isAnimation = false;


    void Start()
    {
        numberText.text = $"";
        weaponText.text = $"연모아 무기빙고";

        foreach (var particle in particles)
        {
            particle.Stop();
            particle.gameObject.SetActive(false);
        }
        foreach (var image in dotImages)
        {
            image.sprite = ResourceManager.Instance.GetRandomSprite();
            image.gameObject.SetActive(false);
        }
    }

    public void UpdateUI()
    {
        StartCoroutine(Co_RouletteAnimation());
    }

    IEnumerator Co_RouletteAnimation()
    {
        foreach (var particle in particles)
        {
            particle.Stop();
            particle.gameObject.SetActive(false);
        }
        nextButton.SetActive(false);
        foreach (var image in dotImages)
        {
            image.sprite = ResourceManager.Instance.GetRandomSprite();
            image.SetNativeSize();
            image.gameObject.SetActive(false);
        }

        numberText.text = "";
        weaponText.text = "";
        // weaponText.text = ".";
        dotImages[0].gameObject.SetActive(true);
        SoundManager.Instance.PlaySound(SoundType.eggSound);
        yield return new WaitForSeconds(0.5f);

        // weaponText.text = ". .";
        dotImages[1].gameObject.SetActive(true);
        SoundManager.Instance.PlaySound(SoundType.eggSound);
        yield return new WaitForSeconds(0.5f);

        // weaponText.text = ". . .";
        dotImages[2].gameObject.SetActive(true);
        SoundManager.Instance.PlaySound(SoundType.eggSound);
        yield return new WaitForSeconds(0.5f);

        SoundManager.Instance.PlaySound(SoundType.puuu);
        foreach (var image in dotImages)
            image.gameObject.SetActive(false);

        numberText.text = $"No.{count + 1}";
        numberText.transform.DOScale(1f, 0.4f).From(1.5f).SetEase(Ease.InOutBack);

        weaponText.text = ConvertExtension.ConvertWeaponTypeToName(InGame.instance.GetWeaponTypes(count));
        weaponText.transform.DOScale(1f, 0.7f).From(0.5f).SetEase(Ease.OutBack);

        foreach (var particle in particles)
        {
            particle.gameObject.SetActive(true);
            particle.Play();
        }

        yield return new WaitForSeconds(1f);

        nextButton.SetActive(true);
        isAnimation = false;
    }




    public void OnClickNextButton()
    {
        if (isAnimation) return;

        if (count + 1 >= (int)WeaponType.Count)
        {
            numberText.text = "";
            weaponText.text = "모든 무기가 등장했습니다!";
            return;
        }
        count++;

        rerollObject.SetActive(false);
        isAnimation = true;
        UpdateUI();
    }

    public void OnClickShuffleWeapon()
    {
        InGame.instance.ShuffleWeapon();
        rerollText.text = InGame.instance.GetRouletteCount().ToString();
    }
}
