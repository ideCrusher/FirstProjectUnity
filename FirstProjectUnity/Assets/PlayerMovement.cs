using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D _RB = new Rigidbody2D();
    private const float _multiplaerSpeed = 1000f;
    private float _AxisX = 0f;
    private bool _isPlatform = false;
    private bool _isJump = false;

    // Start is called before the first frame update
    void Start()
    {
        _RB = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        _AxisX = Input.GetAxis("Horizontal");
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _isJump = true;
        }
        
    }

    void FixedUpdate()
    {
        _RB.velocity = new Vector2(_AxisX * _multiplaerSpeed * Time.fixedDeltaTime, _RB.velocity.y);
        if(_isJump && _isPlatform)
        {
            _isPlatform = false;
            _RB.AddForce(new Vector2(0f,500f));
        }
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Platform"))
        {
            _isPlatform = true;
            _isJump = false;
        }
    }
}
