using TMPro;
using Unity.VisualScripting;
using UnityEngine;
public class SpikeBullet : MonoBehaviour
{
    public float speed = 3.0f;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Bullet collision");
        if (collision.CompareTag("Enemy"))
        {
            if (collision.gameObject.TryGetComponent(out IDamageable damageableObject))
            {
                damageableObject.TakeDamage(10);
            }
        }
    }

}