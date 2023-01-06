using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    [SerializeField] float moveSpeed = 1f;
    //[SerializeField] float timeBetweenAttacks = 3f;
    private Vector2 bossScale;

    private float timeBeforeMoving = 3f;
    private Transform target;
    private Rigidbody2D rb2;
    private Vector2 moveDirection;

    private void Awake()
    {
            rb2 = GetComponent<Rigidbody2D>();

    }

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        bossScale = new Vector2(transform.localScale.x, transform.localScale.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBeforeMoving <= 0)
        {
            if (target)
            {
                Vector3 direction = (target.position - transform.position);
                //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                //rb2.rotation = angle;
                moveDirection = direction;
                FlipBoss();
            }
        }
        else
        {
            timeBeforeMoving -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        rb2.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
    }

    void FlipBoss()
    {
        bool bossHasHorizontalSpeed = Mathf.Abs(rb2.velocity.x) > Mathf.Epsilon;
        if (bossHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(rb2.velocity.x) * bossScale.x, 1f * bossScale.y);
        }
    }
}
