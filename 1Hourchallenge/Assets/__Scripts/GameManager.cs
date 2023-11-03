using UnityEngine;
using UnityEngine.SceneManagement;

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

    private void Start()
    {
        //Only use in one scene ... need FIX
        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            player1Object = GameObject.FindGameObjectWithTag("Player1");
            player2Object = GameObject.FindGameObjectWithTag("Player2");

            player1Object.GetComponent<PlayerHandler>().EquipInGameArmor(player1);
            player2Object.GetComponent<PlayerHandler>().EquipInGameArmor(player2);
        }
    }
}
