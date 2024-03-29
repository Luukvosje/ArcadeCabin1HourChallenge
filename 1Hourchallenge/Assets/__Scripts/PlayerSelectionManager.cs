using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerSelectionManager : MonoBehaviour
{
    public List<Armor> helmets = new List<Armor>();
    public List<Armor> chestplates = new List<Armor>();
    public List<Gun> weapons = new List<Gun>();


    [Header("Player1Keys")]

    [SerializeField] private KeyCode Helmet1;
    [SerializeField] private KeyCode Chestplate1;
    [SerializeField] private KeyCode Weapon1;
    [SerializeField] private KeyCode Ready1;


    public Image helmetSprite;
    public Image chestplateSprite;


    private int currentHelmetIndex1 = 0;
    private int currentChestplateIndex1 = 0;
    private int currentWeaponIndex1 = 0;

    [SerializeField] private TextMeshProUGUI WeaponText1;
    [SerializeField] private GameObject readyScreen1;

    public Player player1;
    bool canSwitch1 = true;

    [Header("Player2Keys")]

    [SerializeField] private KeyCode Helmet2;
    [SerializeField] private KeyCode Chestplate2;
    [SerializeField] private KeyCode Weapon2;
    [SerializeField] private KeyCode Ready2;

    public Image helmetSprite2;
    public Image chestplateSprite2;


    private int currentHelmetIndex2 = 0;
    private int currentChestplateIndex2 = 0;
    private int currentWeaponIndex2 = 0;


    [SerializeField] private TextMeshProUGUI WeaponText2;
    [SerializeField] private GameObject readyScreen2;

    public Player player2;
    bool canSwitch2 = true;


    private void Awake()
    {
        readyScreen1.SetActive(false);
        readyScreen2.SetActive(false);
    }

    private void Update()
    {
        if (!canSwitch1 && !canSwitch2)
        {
            Debug.Log("TEST");
            SceneManager.LoadScene(2);

        }

        if (canSwitch1)
        {
            if (Input.GetKeyDown(Helmet1))
            {
                currentHelmetIndex1 = (currentHelmetIndex1 + 1) % helmets.Count;
                helmetSprite.sprite = helmets[currentHelmetIndex1].Sprite;
                if (helmets[currentHelmetIndex1].Sprite != null)
                    helmetSprite.color = new Color(255, 255, 255, 255);
                else
                    helmetSprite.color = new Color(255, 255, 255, 0);
            }
            else if (Input.GetKeyDown(Chestplate1))
            {
                currentChestplateIndex1 = (currentChestplateIndex1 + 1) % chestplates.Count;
                chestplateSprite.sprite = chestplates[currentChestplateIndex1].Sprite;
                if (chestplates[currentChestplateIndex1].Sprite != null)
                    chestplateSprite.color = new Color(255, 255, 255, 255);
                else
                    chestplateSprite.color = new Color(255, 255, 255, 0);
            }
            else if (Input.GetKeyDown(Weapon1))
            {
                currentWeaponIndex1 = (currentWeaponIndex1 + 1) % weapons.Count;
                WeaponText1.text = weapons[currentWeaponIndex1].name;
            }
        }
        if (Input.GetKeyDown(Ready1))
        {
            canSwitch1 = false;
            player1.Helmet = helmets[currentHelmetIndex1];
            player1.ChestPlate = chestplates[currentChestplateIndex1];
            player1.weapon = weapons[currentWeaponIndex1];
            player1.AssignArmor();
            readyScreen1.SetActive(true);
            player1.weapon = weapons[currentWeaponIndex1];
        }

        if (canSwitch2)
        {
            if (Input.GetKeyDown(Helmet2))
            {
                currentHelmetIndex2 = (currentHelmetIndex2 + 1) % helmets.Count;
                helmetSprite2.sprite = helmets[currentHelmetIndex2].Sprite;
                if (helmets[currentHelmetIndex2].Sprite != null)
                    helmetSprite2.color = new Color(255, 255, 255, 255);
                else
                    helmetSprite2.color = new Color(255, 255, 255, 0);
            }
            else if (Input.GetKeyDown(Chestplate2))
            {
                currentChestplateIndex2 = (currentChestplateIndex2 + 1) % chestplates.Count;
                chestplateSprite2.sprite = chestplates[currentChestplateIndex2].Sprite;
                if (chestplates[currentChestplateIndex2].Sprite != null)
                    chestplateSprite2.color = new Color(255, 255, 255, 255);
                else
                    chestplateSprite2.color = new Color(255, 255, 255, 0);
            }
            else if (Input.GetKeyDown(Weapon2))
            {
                currentWeaponIndex2 = (currentWeaponIndex2 + 1) % weapons.Count;
                WeaponText2.text = weapons[currentWeaponIndex2].name;
            }
        }
        if (Input.GetKeyDown(Ready2))
        {
            canSwitch2 = false;
            player2.Helmet = helmets[currentHelmetIndex2];
            player2.ChestPlate = chestplates[currentChestplateIndex2];
            player2.AssignArmor();
            readyScreen2.SetActive(true);
            player2.weapon = weapons[currentWeaponIndex2];

        }


    }
}