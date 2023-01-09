using Enemy;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 12f;
    [SerializeField] private float rotateSpeed = 200f;
    [SerializeField] private float destroyAfterSeconds = 5f;
    [SerializeField] private Transform rotateObject;
    [SerializeField] private float detectRadius = 4f;
    [SerializeField] private LayerMask whatIsEnemy;

    public int Damage { private get; set; }

    private void Start()
    {
        if (gameObject != null)
        {
            Destroy(gameObject,destroyAfterSeconds);
        }
    }

    private void Update()
    {
        RotateCube();
    }

    private void DetectEnemy()
    {
        var col = Physics.OverlapSphere(transform.position, detectRadius, whatIsEnemy);
        if (col.Length > 0)
        {
            OnPlayer(col);
        }
    }

    private void OnPlayer(Collider[] col)
    {
        col[0].GetComponent<EnemyHealthSystem>().GetDamage(Damage);
        Destroy(gameObject);
    }

    private void RotateCube()
    {
        rotateObject.Rotate(Vector3.one * (200 * rotateSpeed * Time.fixedDeltaTime));
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * (moveSpeed * Time.fixedDeltaTime));
        DetectEnemy();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, detectRadius);
    }
}
