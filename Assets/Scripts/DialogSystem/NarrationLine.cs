using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Narration/Line")]
public class NarrationLine : ScriptableObject
{
    [SerializeField] private NarrationCharacter _speaker;
    [SerializeField] private string _text;

    public NarrationCharacter Speaker => _speaker;
    public string Text => _text;
}