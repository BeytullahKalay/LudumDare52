using System;
using UnityEngine;

public static class EventManager
{
    public static Action<Transform> Harvest;

    public static Action Completed;
    public static Action GameOver;

    public static Action<int> CollectGold;
    public static Action<int> UpdateUI;

    public static Action<float> CollectMoveSpeed;
    public static Action<float> CollectAttackSpeed;
    public static Action UpdateAnimationSpeed;

    public static Action OnFieldBuy;
}
