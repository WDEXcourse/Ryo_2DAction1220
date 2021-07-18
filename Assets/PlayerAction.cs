using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAction : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    private bool Grounded;
    public float floatHeight;
    public float liftForce;
    public float damping;
    public LayerMask layerMask;
    private Vector2 Muki;
    public string nextscene;
    public Vector3 firstpos;
    public SpriteRenderer sr;
    public float alpha;
    public bool alphafrag;
    public bool jump;
    public GameObject RootObject;
    public float xScale;
    public float yScale;
    public Sprite[] playerSprite;
	
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Muki = Vector2.right;

        firstpos = transform.position;

        sr = GetComponent<SpriteRenderer>();

        alpha = sr.color.a;

        alphafrag = false;

        xScale = 0.2f;

        yScale = 0.2f;

        if(ChooseColor.name == "blue")
        {
            sr.sprite = playerSprite[0];
        }

        if (ChooseColor.name == "black")
        {
            sr.sprite = playerSprite[1];
        }

        if (ChooseColor.name == "red")
        {
            sr.sprite = playerSprite[2];
        }

        if (ChooseColor.name == "yellow")
        {
            sr.sprite = playerSprite[3];
        }

        if (ChooseColor.name == "green")
        {
            sr.sprite = playerSprite[4];
        }
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKey(KeyCode.D))
        {
            //transform.localScale = new Vector3(1, 1, 1);

            transform.position += new Vector3(0.1f, 0, 0);

            transform.rotation = Quaternion.Euler(new Vector3(0, 180f, 0));
        }

        if (Input.GetKey(KeyCode.A))
        {
            //transform.localScale = new Vector3(-1, 1, 1);

            transform.position += new Vector3(-0.1f, 0, 0);

            transform.rotation = Quaternion.Euler(new Vector3(0, -180f, 0));
        }

        if (Input.GetButtonDown("Jump"))
        {
            //Debug.Log("jump");
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            //Debug.Log("W key");
        }

        if ((Input.GetKeyDown(KeyCode.W) || Input.GetButtonDown("Jump")) && Grounded == true)
        {
            //Debug.Log("GetButton");
            rb.AddForce(Vector2.up * 450);
        }

        if (Input.GetKeyDown(KeyCode.S) && Grounded == true)
        {
            yScale = 0.1f;
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            yScale = 0.2f;
        }
        //else
        //{
        //    yScale = 1;
        //}

        if (Input.GetKeyDown(KeyCode.S) && Grounded == false)
        {
            rb.AddForce(Vector2.down * 450);
        }

        float horizontal = Input.GetAxis("Horizontal");

        if ((horizontal > 0.3f) || (horizontal < -0.3f))
        {
            transform.position += new Vector3(horizontal * 5, 0, 0) * Time.deltaTime;
            //rb.AddForce(new Vector2(horizontal * 5, 0) * 1.5f);
        }

        //Debug.Log("Horizontal"+horizontal);

        if (horizontal > 0)
        {
            xScale = 1;
        }
        if (horizontal < -0)
        {
            xScale = -1;
            yScale = 1;
        }
        float vertical = Input.GetAxis("Vertical");

        if (gameObject.transform.position.y <= -200)
        {
            Restart();
        }

        if (horizontal < 0)
        {
            transform.rotation = new Quaternion(0, 180, 0, 0);
        }

        //sr.color = new Color(255, 255, 255, alpha);

        //if (alphafrag)
        //{
        //    alpha -= Time.deltaTime;
        //}
        //else
        //{
        //    alpha += Time.deltaTime;
        //}

        transform.localScale = new Vector3(xScale, yScale, 1);


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Grounded = true;
        }

        if (collision.gameObject.tag == "Obstacle")
        {
            Restart();
        }

        if (collision.gameObject.tag == "Goal")
        {
            SceneManager.LoadScene(nextscene);
        }

        if (collision.gameObject.tag == "Jampramp")
        {
            rb.AddForce(Vector2.up * 550);
        }
        if (collision.gameObject.tag == "FS")
        {
            Grounded = true;
        }


        //collision.
    }

private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Transparent")
        {
            alpha = 1;
            alphafrag = true;
            Debug.Log("ok");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Grounded = false;            
        }
        if (collision.gameObject.tag == "FS")
        {
            Grounded = false;
            xScale = 0.2f;
        }

        transform.parent = null;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Transparent")
        {
            alphafrag = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        this.gameObject.transform.parent = collision.gameObject.transform;

        //transform.localScale = new Vector3(1, 1, 1);
        if(collision.gameObject.tag == "FS")
        {
            xScale = 0.1f;
        }
        
        if(collision.gameObject.tag == "Ground")
        {
            xScale = 0.2f;

            Grounded = true;
        }
    }

    void Restart()
    {
        transform.position = transform.position = firstpos;
    }

    private void FixedUpdate()
    {
        
        Ray ray = new Ray(transform.position, Muki);

        // layerMask =1<< 9;

        //layerMask = ~layerMask;

        RaycastHit2D lefthit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction, 1, layerMask);

        //&& lefthit.collider.gameObject.layer == LayerMask.NameToLayer("Nowalljump")

        Debug.DrawRay((Vector2)ray.origin, (Vector2)ray.direction, Color.red);

        if (lefthit.collider != null )
        {
            float distance = Mathf.Abs(lefthit.point.y - transform.position.y);
            float heightError = floatHeight - distance;
            float force = liftForce * heightError - rb.velocity.y * damping;
            rb.AddForce(Vector3.up * force);
            Debug.Log("hit" + lefthit.collider.name);

            if ((Input.GetKeyDown(KeyCode.W) || Input.GetButtonDown("Jump")) && lefthit.collider != null)
            {
                Debug.Log(rb.velocity);

                //斜め横にジャンプ
                //rb.velocity.x > 0 ? -3 : 3
                rb.velocity = new Vector3(-3, 0, 0);
            }
        }

        Ray ray1 = new Ray(transform.position, -Muki);

        RaycastHit2D righthit = Physics2D.Raycast((Vector2)ray1.origin, (Vector2)ray1.direction, 1, layerMask);

        Debug.DrawRay((Vector2)ray1.origin, (Vector2)ray1.direction, Color.green);

        if (righthit.collider != null)
        {
            float distance = Mathf.Abs(righthit.point.y - transform.position.y);
            float heightError = floatHeight - distance;
            float force = liftForce * heightError - rb.velocity.y * damping;
            rb.AddForce(Vector3.up * force);
            Debug.Log("hit" + righthit.collider.name);

            if ((Input.GetKeyDown(KeyCode.W) || Input.GetButtonDown("Jump")) && righthit.collider != null)
                {
                Debug.Log(rb.velocity);

                //斜め横にジャンプ
                //rb.velocity.x > 0 ? -3 : 3
                rb.velocity = new Vector3(3, 0, 0);
            }
        }
    }
}