using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public Player player1;
    public Player player2;

    public GameObject player1Object, player2Object;

    [Header("Weapons")]
    public GameObject Bullet;
    public GameObject ShootPoint;
    public GameObject BloodEffect;

    public Image WinScreen;
    public TextMeshProUGUI winText;
    public bool MatchEnded;

    private void Start()
    {
        //Only use in one scene ... need FIX
        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            WinScreen.gameObject.SetActive(false);
            player1Object = GameObject.FindGameObjectWithTag("Player1");
            player2Object = GameObject.FindGameObjectWithTag("Player2");

            player1Object.GetComponent<PlayerHandler>().EquipInGameArmor(player1);
            player2Object.GetComponent<PlayerHandler>().EquipInGameArmor(player2);
        }
    }

    public void WinScren()
    {
        WinScreen.gameObject.SetActive(true);
        if (player1._Lives <= 0)
            winText.text = "Player 2 wins";
        else if (player2._Lives <= 0)
            winText.text = "Player 1 wins";

    }
}
