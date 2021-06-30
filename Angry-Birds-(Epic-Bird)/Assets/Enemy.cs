using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _cloudPrefab;

   private void OnCollisionEnter2D(Collision2D collision)
    {
        Bird bird = collision.collider.GetComponent<Bird>();
        if (bird != null)
        {
            Instantiate(_cloudPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            return;
        }

        Enemy enemy = collision.collider.GetComponent<Enemy>();
        if (enemy != null)
        {
            return;
        }

        if( collision.contacts[0].normal.y < - 0.5)
        {
            ScoreScripr.scoreValue += 1;
            Instantiate(_cloudPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
