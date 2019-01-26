using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody myRigidbody;
    public float speed;
    private bool faceRight;
    private Sprite mySprite;
    public bool inAir = false;
    public int nbAir = 0;
    public float jumpForce = 300;
    // Start is called before the first frame update
    void Start()
    {
        faceRight = true;
        myRigidbody = GetComponent<Rigidbody>();
       
    }



    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal") ;
   
        movementPlayer(horizontal);
        Flip(horizontal);
        if (inAir == false && Input.GetKeyDown(KeyCode.Z))
        {
            inAir = true;
            myRigidbody.AddForce(new Vector3(0, 1 * jumpForce,0), ForceMode.Impulse);
            Debug.Log("nsmmmmmmmmmmmmzertynhtnoizreboerhipugzenboiunrtboizuentgboiurtngiourengt");
            //transform.rotation = new Quaternion(transform.rotation.x,trans)
            
            /*if(nbAir > 2)
            {
                inAir = false;
            }*/
           
        }
       
    }

    private void movementPlayer(float horizontal)
    {
        transform.Translate(new Vector3(horizontal * speed, 0, 0));
    }
    private void Flip(float horizontal)
    {
        if(horizontal > 0 && !faceRight || horizontal < 0 && faceRight)
        {
            faceRight = !faceRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        inAir = false;
        myRigidbody.velocity= new Vector3(myRigidbody.velocity.x, 0,0);
        Debug.Log("Touché");
    }
}
