
[System.Serializable]
public struct FieldState
{
    public bool IsOpen;
    public bool IsEmpty;
    public int Cost;

    public FieldState(bool isOpen, bool isEmpty,int cost)
    {
        IsOpen = isOpen;
        IsEmpty = isEmpty;
        Cost = cost;
    }
}
