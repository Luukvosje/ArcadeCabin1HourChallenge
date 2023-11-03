using UnityEngine;

[CreateAssetMenu(menuName = "Player/Players")]
public class Player : ScriptableObject
{
    public int _Health;
    public int _Speed;
    public int _Lives;

    public Armor Helmet;
    public Armor ChestPlate;
    public Gun weapon;



    public void AssignArmor()
    {
        _Lives = 5;
        _Health = 100;
        _Speed = 100;

        _Health += Helmet._Health + ChestPlate._Health;
        _Speed += Helmet._Speed + ChestPlate._Speed;
        Debug.Log(_Speed);
    }
}
