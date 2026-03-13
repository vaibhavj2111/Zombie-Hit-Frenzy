using UnityEngine;

public class ZombieAi : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed = 1.5f;
    Vector3 direction;

    void Start()
    {
        PickDirection();
        InvokeRepeating("PickDirection", 0f, 2f);    
    }

    void PickDirection()
    {
        direction = new Vector3(
            Random.Range(-1f,1f), 0f, Random.Range(-1f,1f)
        ).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction*speed*Time.deltaTime);
    }
}
