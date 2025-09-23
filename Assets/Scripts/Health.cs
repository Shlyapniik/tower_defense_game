using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private int hitPoints = 2;
    [SerializeField] private int currencyWorth = 50;

    [Header("UI")]
    [SerializeField] private Image healthBarFill; // сюда перетаскиваем fill image

    private int maxHitPoints;
    private bool isDestroyed = false;

    private void Start()
    {
        maxHitPoints = hitPoints;

        // если Canvas в world space, следим за камерой
        if (healthBarFill != null && healthBarFill.canvas != null)
        {
            healthBarFill.canvas.worldCamera = Camera.main;
        }
    }

    public void TakeDamage(int damage)
    {
        hitPoints -= damage;

        // обновляем полоску
        if (healthBarFill != null)
        {
            healthBarFill.fillAmount = (float)hitPoints / maxHitPoints;
        }

        if (hitPoints <= 0 && !isDestroyed)
        {
            EnemySpawner.onEnemyDestroy.Invoke();
            LevelManager.main.IncreaseCurrency(currencyWorth);
            isDestroyed = true;
            Destroy(gameObject);
        }
    }
}
