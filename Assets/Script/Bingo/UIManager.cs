using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public GameObject boardPanel;
    public GameObject weaponButtonPanel;
    public GameObject weaponListPanel;
    public GameObject modeSelectPanel;
    public GameObject weaponRoulettePanel;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        boardPanel.SetActive(true);
        weaponButtonPanel.SetActive(false);
        weaponListPanel.SetActive(false);
        modeSelectPanel.SetActive(true);
        weaponRoulettePanel.SetActive(false);
    }



    public void ShowWeaponButtonPanel(bool show)
    {
        weaponButtonPanel.SetActive(show);
    }

    public void ShowRouletteButtonPanel(bool show)
    {
        weaponListPanel.SetActive(show);
    }

    public void ShowModeSelectPanel(bool show)
    {
        modeSelectPanel.SetActive(show);
    }

    public void ShowWeaponRoulettePanel(bool show)
    {
        weaponRoulettePanel.SetActive(show);
    }



    public void SetAdminMode()
    {
        boardPanel.SetActive(true);
        weaponButtonPanel.SetActive(false);
        weaponListPanel.SetActive(false);
        modeSelectPanel.SetActive(false);
        weaponRoulettePanel.SetActive(false);
    }

    public void SetRouletteMode()
    {
        boardPanel.SetActive(false);
        weaponButtonPanel.SetActive(false);
        weaponListPanel.SetActive(false);
        modeSelectPanel.SetActive(false);
        weaponRoulettePanel.SetActive(true);
    }

    public void SetModeSelect()
    {
        boardPanel.SetActive(true);
        weaponButtonPanel.SetActive(false);
        weaponListPanel.SetActive(false);
        modeSelectPanel.SetActive(true);
        weaponRoulettePanel.SetActive(false);
    }


}
