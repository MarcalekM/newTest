// Move.cs
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 2.0f;

    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
        Destroy(gameObject, 15);
    }
}

