using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Narration/Dialogue/Dialogue Channel")]
public class DialogueChannel : ScriptableObject
{
    public delegate void DialogueCallback(Dialogue dialogue);
    public DialogueCallback DialogueRequested;
    public DialogueCallback DialogueStart;
    public DialogueCallback DialogueEnd;

    public delegate void DialogueNodeCallback(DialogueNode node);
    public DialogueNodeCallback DialogueNodeRequested;
    public DialogueNodeCallback DialogueNodeStart;
    public DialogueNodeCallback DialogueNodeEnd;

    public void RaiseRequestDialogue(Dialogue dialogue)
    {
        DialogueRequested?.Invoke(dialogue);
    }

    public void RaiseDialogueStart(Dialogue dialogue)
    {
        DialogueStart?.Invoke(dialogue);
    }

    public void RaiseDialogueEnd(Dialogue dialogue)
    {
        DialogueEnd?.Invoke(dialogue);
    }

    public void RaiseRequestDialogueNode(DialogueNode node)
    {
        DialogueNodeRequested?.Invoke(node);
    }

    public void RaiseDialogueNodeStart(DialogueNode node)
    {
        DialogueNodeStart?.Invoke(node);
    }

    public void RaiseDialogueNodeEnd(DialogueNode node)
    {
        DialogueNodeEnd?.Invoke(node);
    }
}