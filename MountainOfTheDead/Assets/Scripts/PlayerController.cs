using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
 
    private Rigidbody2D _rigidbody;
    public Animator animator;
    public Transform attackPos;
    public Transform highAttack;
    public Transform normalAttack;
    public LayerMask whatIsEnemies;
    public LayerMask whatIsGrass;
    public float attackRange;
    public bool isImmortal;
    public GameObject Player;
    public BoxCollider2D boxCollider2D;
    public ParticleSystem particle1;
    public ParticleSystem particle2;
    public float comboCount;
    public float comboNumber;


    private bool facingLeft;
    private bool facingnRight;
    private bool isNotRunning;

    private bool isBlocking;
    private float times;
    public float speed;
    public float slowerSpeed;

    public float MovementSpeed;
    private float JumpForce = 8f;
    public float timeBtwRoll;
    public float startTimeBtwRoll;
    public float timeBtwAttack;
    public float startTimeBtwAttack;
    public float damage;
    private float time = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        speed = 9;
        slowerSpeed = 6;
        comboCount = 0;
        boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
        isImmortal = false;
        times = 0.2f;
        facingLeft = false;
        facingnRight = true;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
      if(comboCount >= 2)
        {
            comboCount = 0;
        }
        Moving();
        Attacking();
        Jumping();
        Roll();
        Combo();
       
    }

    private void FixedUpdate()
    {
        //Move our character

    }
    private void Attacking() 
    {
        if (timeBtwAttack <= 0) // Making it impossible to attack every frame
        {

            if (Input.GetKeyDown(KeyCode.Mouse0) && isNotRunning == true)
            {
                comboCount += 1;
                if (comboCount == 1)
                {
                    Instantiate(particle1, attackPos.position, Quaternion.identity);
                }
                else if (comboCount > 1)
                {
                    Instantiate(particle2, attackPos.position, Quaternion.identity);
                }



                animator.SetTrigger("attack");
                Collider2D[] grassToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsGrass);
                for (int i = 0; i < grassToDamage.Length; i++)
                {
                    grassToDamage[i].GetComponent<Grass>().Destruction(time);
                }

                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for (int i = 0; i <enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<EnemiesHealth>().TakeDamage(damage);
                    






                }
                if(facingLeft == true) // Moving player a little when he attack
                {
                    transform.position += new Vector3(-1f, 0, 0) * Time.deltaTime * MovementSpeed;
                }
                else if (facingnRight == true)
                {
                    transform.position += new Vector3(1f, 0, 0) * Time.deltaTime * MovementSpeed;
                }

                MovementSpeed = 0;
                timeBtwAttack = startTimeBtwAttack;

            }
           
        }

        else
        {
            timeBtwAttack -= Time.deltaTime;
            MovementSpeed = 9;
        }

        if (Input.GetKey(KeyCode.Mouse1)) //Blocking
        {

            MovementSpeed = 0;
            animator.SetTrigger("Blocking");
            
            isBlocking = true;

        }
        else
        {
            
            isBlocking = false;
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            animator.SetTrigger("Unblock");
        }

        




    }




    private void Moving()
    {



        if (Input.GetKey("w"))
        {
            attackPos.position = highAttack.position;
        }
        else
        {
            attackPos.position = normalAttack.position;
        }
        if (Input.GetKey("a") && Mathf.Abs(_rigidbody.velocity.y) < 0.005f && isBlocking == false)
        {
            animator.SetTrigger("RunAnimation");
            
            isNotRunning = false;
            MovementSpeed = speed;

        }

        else if (Input.GetKey("d") && Mathf.Abs(_rigidbody.velocity.y) < 0.005f && isBlocking == false)
        {
            isNotRunning = false;
            MovementSpeed = speed;
            animator.SetTrigger("RunAnimation");

        }
        else
        {
            animator.SetTrigger("Idle");
            isNotRunning = true;
        }
        if (Mathf.Abs(_rigidbody.velocity.y) > 0.005f)
        {
            MovementSpeed = slowerSpeed;
        }
       
       
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;
        if (Input.GetKey("a") && facingLeft == false)
        {
            
            transform.Rotate(Vector3.up, 180);
            facingLeft = true;
            facingnRight = false;

        }
        if (Input.GetKey("d") && facingnRight == false)
        {
            transform.Rotate(Vector3.up, 180);
            facingnRight = true;
            facingLeft = false;
            

        }

    }

    private void Jumping()
    {

        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f) //Making it impossibe to double or tripple or etc jump.
        {
            StartCoroutine(immortal(times));
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            animator.SetTrigger("Jump");



        }






    }


    private void Roll() // Rolling like in Dark Souls, later to add immortality during it
    {
        if (timeBtwRoll <= 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && isBlocking == false)
            {
                StartCoroutine(immortal(times));
                
                animator.SetTrigger("Roll");
                MovementSpeed = 5;
                timeBtwRoll = startTimeBtwRoll;
            }




           
        }
        else
        {
            
            timeBtwRoll -= Time.deltaTime;
            MovementSpeed = 9;
            
        }


    }

     void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }


    void Combo()
    {
       
    }

    IEnumerator immortal(float times)
    {
        isImmortal = true;
        boxCollider2D.size = new Vector2(13.95f, 1.5f);
        yield return new WaitForSeconds(times);
        boxCollider2D.size = new Vector2(13.95f, 2.96f);
        isImmortal = false;
        
            
        
    }


}
    
