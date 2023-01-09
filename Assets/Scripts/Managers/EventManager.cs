using System;
using UnityEngine;

public static class EventManager
{
    public static Action<Transform> Harvest;
    public static Action GameOver;
    
    public static Action CollectGold;
    public static Action<int> UpdateUI;

    public static Action OnFieldBuy;
}
