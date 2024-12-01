using UnityEngine;
public class BulletOneBehaviour : MonoBehaviour
{
    public float speed = 5.0f;
    public int damageAmount = 10;

    public Vector3 directionToTarget;
    public float timeAlive;

    private void Start()
    {
        timeAlive = 2;
    }
    void Update()
    {
    
        gameObject.transform.Translate(directionToTarget.normalized * Time.deltaTime * speed);

        timeAlive -= Time.deltaTime;
        if(timeAlive <= 0)
        {
            Destroy(this.gameObject);
        }
    }

     void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Bullet collision");
            if (collision.gameObject.TryGetComponent(out IDamageable damageableObject))
            {
                damageableObject.TakeDamage(damageAmount);
                Destroy(gameObject);
            }
        }

}