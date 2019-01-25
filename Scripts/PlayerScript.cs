using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    float speed = 6f;
    float sensitivy = 10f;

    Rigidbody rigidbody;
    Vector3 move;
    public Camera camera;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovePlayer();
        RotateCamera();

        RaycastHit hit;
        Ray r = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(r, out hit))
        {
            Transform t = hit.transform;

            print(t.gameObject);
        }
    }

    private void MovePlayer()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        move.Set(h, 0f, v);
        rigidbody.MovePosition(transform.position + (move.normalized * speed * Time.deltaTime));
    }

    private void RotateCamera()
    {
        

        //camera.main.transform
    }
}
