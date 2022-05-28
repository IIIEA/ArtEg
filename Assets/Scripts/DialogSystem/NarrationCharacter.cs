using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable objects/Narration/Character", order = 51)]
public class NarrationCharacter : ScriptableObject
{
    [SerializeField] private string _name;

    public string Name => _name;
}
