using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // public string poolItemName;
    public float speed = 10.0f;
    public float endTime = 2.0f;
    public float lifeTime = 0f;
    public int damage = 1;

    void Start()
    {
        Destroy(this.gameObject, endTime);
    }

    void Update()
    {
        // lifeTime += Time.deltaTime;
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        //if(lifeTime >= endTime)
        //{
        //    lifeTime = 0f;
        //    Destroy(this.gameObject);
        //    // ObjectPool.Instance.PushToPool(poolItemName, GameObject);
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Enemy");

            Enemy enemy = other.GetComponent<Enemy>();
            enemy.SetHp(damage);
            Destroy(this.gameObject);
        }
    }
}