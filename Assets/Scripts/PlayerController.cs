using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    AudioSource PlayerFx;

    Vector2 moveInput;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        PlayerFx = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       moveInput.x = Input.GetAxis("Horizontal");
       moveInput.y = Input.GetAxis("Vertical");

       transform.Translate(moveInput * Time.deltaTime * moveSpeed);

       anim.SetBool("IsWalking", (Mathf.Abs(moveInput.x) > 0 || Mathf.Abs(moveInput.y) > 0));
    }

    private void OnCollisionEnter2D(Collision2D collision){

         if(collision.gameObject.CompareTag("Monster"))
         {
             PlayerFx.Play();
             Destroy(gameObject);

         }
    }    
}