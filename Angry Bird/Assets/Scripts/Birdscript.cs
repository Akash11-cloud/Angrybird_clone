using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody))]
public class Birdscript : MonoBehaviour
{
    public Transform pivot;
    public float springRange;
    public float maxVel;

    Rigidbody2D rb;
    Vector3 dis;

    bool canDrag = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    void OnMouseDrag()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dis = mousePosition - pivot.position;
        dis.z = 0;
        if(dis.magnitude > springRange)
        {
            dis = dis.normalized * springRange;
        }
        transform.position = dis + pivot.position;
    }
     void OnMouseUp()
    {
        canDrag = false;
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.velocity = -dis.normalized * maxVel * dis.magnitude / springRange;
    }

}
