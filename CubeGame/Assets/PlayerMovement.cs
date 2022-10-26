using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
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
        rb.AddForce(0, 0, 2000 * Time.deltaTime);  
    }
}
