using System.Collections;
using UnityEngine;

public class TowerSlomo : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private Transform auraVisual;

    [Header("Attributes")]
    [SerializeField] private float targetingRange = 5f;
    [SerializeField] private float attacksPerSecond = 4f;
    [SerializeField] private float freezeTime = 1f;

    private float timeUntilFire;

    private void Start()
    {
        UpdateAura();
        if (auraVisual != null) auraVisual.gameObject.SetActive(false); // по умолчанию скрыта
    }

    private void Update()
    {
        UpdateAura();

        timeUntilFire += Time.deltaTime;
        if (timeUntilFire >= 1f / attacksPerSecond)
        {
            FreezeEnemies();
            timeUntilFire = 0f;
        }
    }

    private void OnValidate()
    {
        UpdateAura();
    }

    private void UpdateAura()
    {
        if (auraVisual != null)
        {
            auraVisual.localScale = new Vector3(targetingRange * 2f, targetingRange * 2f, 1f);
        }
    }

    private void FreezeEnemies()
    {
        if (auraVisual != null) auraVisual.gameObject.SetActive(true);

        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange, Vector2.zero, 0f, enemyMask);

        if (hits.Length > 0)
        {
            for (int i = 0; i < hits.Length; i++)
            {
                EnemyMovement em = hits[i].transform.GetComponent<EnemyMovement>();
                if (em != null)
                {
                    em.UpdateSpeed(0.5f);
                    StartCoroutine(ResetEnemySpeed(em));
                }
            }
        }

        StartCoroutine(HideAura());
    }

    private IEnumerator HideAura()
    {
        yield return new WaitForSeconds(freezeTime);
        if (auraVisual != null) auraVisual.gameObject.SetActive(false);
    }

    private IEnumerator ResetEnemySpeed(EnemyMovement em)
    {
        yield return new WaitForSeconds(freezeTime);
        em.ResetSpeed();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, targetingRange);
    }
}
