using System;
using System.Linq;
using UnityEngine;

[Serializable]
public class DialogueChoice
{
    [SerializeField] private string _choicePreview;
    [SerializeField] private DialogueNode _choiceNode;

    public string ChoicePreview => _choicePreview;
    public DialogueNode ChoiceNode => _choiceNode;
}


[CreateAssetMenu(menuName = "Scriptable Objects/Narration/Dialogue/Node/Choice")]
public class ChoiceDialogueNode : DialogueNode
{
    [SerializeField]
    private DialogueChoice[] _choices;

    public DialogueChoice[] Choices => _choices;

    public override bool CanBeFollowedByNode(DialogueNode node)
    {
        return _choices.Any(x => x.ChoiceNode == node);
    }

    public override void Accept(DialogueNodeVisitor visitor)
    {
        visitor.Visit(this);
    }
}