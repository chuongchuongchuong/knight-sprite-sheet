using UnityEngine;

// chỗ này là tạo scriptable object
[CreateAssetMenu(menuName = "CharactorData")]
public class CharactorData : ScriptableObject
{
    public int maxHealth;
    public int moveSpeed;
    public int jumpForce;
}


