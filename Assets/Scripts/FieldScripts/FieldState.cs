
[System.Serializable]
public struct FieldState
{
    public bool IsOpen;
    public bool IsEmpty;
    public int Health;

    public FieldState(bool isOpen, bool isEmpty,int health)
    {
        IsOpen = isOpen;
        IsEmpty = isEmpty;
        Health = health;
    }
}
