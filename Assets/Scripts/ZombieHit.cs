using UnityEngine;

public class ZombieHit : MonoBehaviour
{
    public ZombieSpawner spawner;

    bool isDead = false;

    void OnCollisionEnter(Collision col)
    {
        if (isDead) return;
        // if(!col.transform.root.CompareTag("Car")) return;
        Debug.Log("Hit by: " + col.gameObject.name);
        if (!col.transform.root.CompareTag("Car"))
            return;

        if (col.transform.root.CompareTag("Car"))
        {
            isDead = true;

            GameManager.instance.AddScore();

            // notify spawner
            if (spawner != null)
                spawner.ZombieKilled();

            // disable zombie movement
            ZombieAi ai = GetComponent<ZombieAi>();
            if (ai != null)
                ai.enabled = false;

            EnableRagdoll(col);
        }
    }

    void EnableRagdoll(Collision col)
    {
        // Disable animator
        Animator animator = GetComponent<Animator>();
        if (animator != null)
            animator.enabled = false;

        // Disable main collider
        Collider mainCollider = GetComponent<Collider>();
        if (mainCollider != null)
            mainCollider.enabled = false;

        // Enable ragdoll rigidbodies
        Rigidbody[] bodies = GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody rb in bodies)
        {
            rb.isKinematic = false;
            rb.useGravity = true;
            rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
            rb.AddForce(col.relativeVelocity*1.1f, ForceMode.Impulse);
        }

        // // Enable ragdoll colliders
        // Collider[] colliders = GetComponentsInChildren<Collider>();

        // foreach (Collider coli in colliders)
        // {
        //     coli.enabled = true;
        // }

        // change layer
        // gameObject.layer = LayerMask.NameToLayer("DeadZombie");
        SetLayerRecursively(gameObject, LayerMask.NameToLayer("DeadZombie"));
    }

    void SetLayerRecursively(GameObject obj, int newLayer)
    {
        obj.layer = newLayer;

        foreach (Transform child in obj.transform)
        {
            SetLayerRecursively(child.gameObject, newLayer);
        }
    }
}