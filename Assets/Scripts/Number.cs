using TMPro;

public struct Number
{
    public Number(TextMeshPro tensLabel, TextMeshPro onenessLabel)
    {
        _tensLabel = tensLabel;
        _onenessLabel = onenessLabel;

        _tensSecondaries = tensLabel.transform.GetComponentsInChildren<TextMeshPro>();
        _onenessSecondaries = _onenessLabel.transform.GetComponentsInChildren<TextMeshPro>();
    }

    public void HideSecondaries()
    {
        foreach (TextMeshPro label in _tensSecondaries)
        {
            label.text = string.Empty;
        }
        foreach (TextMeshPro label in _onenessSecondaries)
        {
            label.text = string.Empty;
        }
    }

    public readonly TextMeshPro _tensLabel, _onenessLabel;
    public readonly TextMeshPro[] _tensSecondaries, _onenessSecondaries;
}