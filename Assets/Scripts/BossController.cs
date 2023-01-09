using UnityEngine;

public class BossController : MonoBehaviour
{
    private Animator _animator;

    private void OnEnable()
    {
        EventManager.Completed += PlayBossWinAnimation;
    }

    private void OnDisable()
    {
        EventManager.Completed -= PlayBossWinAnimation;
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void PlayBossWinAnimation()
    {
        _animator.SetTrigger("Cheer");
    }
}
