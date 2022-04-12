using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    [Header("Lifetime")]
    public float lifetime;


    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
