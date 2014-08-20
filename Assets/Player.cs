using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
   private float speedModifier = 0f;
   private float speed = 3f;
   private float strafeSpeed = 1.5f;
   private float jumpForce = 2f;
   private float rotationSpeed = 400f;
   private bool onGround = true;
   private int sprinting = 1;
    
   void Start () 
   {
      Screen.showCursor = false;
   }
   
   void OnCollisionEnter (Collision col) 
   {
      if(col.gameObject.tag == "ground")
      {
         onGround = true;
      }
   }
   
   void OnCollisionExit (Collision col) 
   {
      if(col.gameObject.tag == "ground")
      {
         onGround = false;
      }
   }
   
   bool OnGround ()
   {
      return onGround;
   }
   
   void Sprint ()
   {
      sprinting = (sprinting + 1) % 2;
   }
   
   bool OnSprinting ()
   {
      bool result = false;
      if(sprinting == 1)
      {
         result = true;
      }
      else 
      {
         result = false;
      }
      return result;
   }
   
   void Update () 
   {
      if(Input.GetKey(KeyCode.LeftShift))
      {
         speedModifier = 2f;
      }
      else
      {
         speedModifier = 1f;
      }
      
      if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
      {
         rigidbody.MovePosition(rigidbody.transform.position + transform.forward * speed * speedModifier * Time.deltaTime);
      }
      
      if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
      {
         rigidbody.MovePosition(rigidbody.transform.position + transform.forward * -speed * speedModifier * Time.deltaTime);
      }
      
      if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
      {
         rigidbody.MovePosition(rigidbody.transform.position + transform.right * -strafeSpeed * speedModifier * Time.deltaTime);
      }
      
      if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
      {
         rigidbody.MovePosition(rigidbody.transform.position + transform.right * strafeSpeed * speedModifier * Time.deltaTime);
      }
      
      if(Input.GetKeyDown(KeyCode.Space) && OnGround())
      {
         rigidbody.AddForce(transform.up * jumpForce, ForceMode.Impulse);
      }
      transform.Rotate(transform.up * Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime);
   }
}
