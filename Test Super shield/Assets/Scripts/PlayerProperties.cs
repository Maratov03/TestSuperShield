using UnityEngine;

[CreateAssetMenu(menuName = "Player/properties")]
public class PlayerProperties : ScriptableObject
{
    public int enemy;
    public int bullet = 3;
    public bool menu;
    public bool menuPause;
}
