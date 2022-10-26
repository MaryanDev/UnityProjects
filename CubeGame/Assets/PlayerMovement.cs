using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    // Start is called before the first frame update
    //void Start()
    //{
    //    Debug.Log("Hello World!");    
    //    //rb.useGravity = false;
    //    rb.AddForce(0, 200, 500);
    //}

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(0, 0, GetForceWithDelta(forwardForce));

        if (Input.GetKey("d"))
        {
            rb.AddForce(GetForceWithDelta(sidewaysForce), 0, 0);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(GetForceWithDelta(-sidewaysForce), 0, 0);
        }
    }

    private float GetForceWithDelta(float initialForce) => initialForce * Time.deltaTime;
}
