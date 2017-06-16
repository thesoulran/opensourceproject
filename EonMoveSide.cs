using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class EonMoveSide : NetworkBehaviour {
    Rigidbody2D rigid;
    Animator m_Anim2;
    public float forwardSpeed = 0f;
    /*
    public GameObject energymissile;
    public GameObject energymissile2;
    public GameObject energymissileini;
    public GameObject energymissileini2;
    */
    public GameObject bulletPrefab;
    public GameObject bulletPrefab2;
    public GameObject bulletPrefab3;
    public GameObject bulletPrefab4;
    public Transform bulletSpawn;
    public Transform bulletSpawn2;
    public Transform bulletSpawn3;
    public Transform bulletSpawn4;

    int amount = 5;
    int amount2 = 1;


    public int side;

    float UpForce = 200;





    Vector3 oldPosition;
    Vector3 currentPosition;

    public const int maxHP = 100;
    public bool destroyOnDeath;

    [SyncVar] public int currentHP = maxHP;

    public RectTransform HPbar;



    void Start () {
        m_Anim2 = GetComponent<Animator>();
//        oldPosition = transform.position;
  //      currentPosition = oldPosition;
   

    }
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        
        rigid.velocity = new Vector2(forwardSpeed, 0);
    }	

	void Update () {


        if (!isLocalPlayer)
        {
            return;
        }


        //player movement

        if (Input.GetKey(KeyCode.LeftArrow)) 
        {
            Vector3 vec = this.transform.position;
            vec.x -= 0.02f;
            this.transform.position = vec;
            m_Anim2.SetInteger("Side", 2);
            side = 1;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 vec = this.transform.position;
            vec.x += 0.02f;
            this.transform.position = vec;
            m_Anim2.SetInteger("Side", 1);
            side = 2;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (side == 2)
            CmdEnergyShoot1();
            if (side == 1)
            CmdEnergyShoot2();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (side == 2)
                CmdEnergyShoot3();
            if (side == 1)
                CmdEnergyShoot4();
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigid.velocity = new Vector2(rigid.velocity.x, 0);
            rigid.AddForce(new Vector2(0, UpForce));
        }

/*
        currentPosition = transform.position;


        if(currentPosition != oldPosition)
        {
            oldPosition = currentPosition;
        }

/*
        EonMoveSide pc = this.GetComponent<EonMoveSide>();
        Health h = this.GetComponent<Health>();
        h.currentHP = 100;
        h.OnChangeHP();
        */


        //  HPbar.sizeDelta = new Vector2(currentHP, HPbar.sizeDelta.x);




        if (currentHP <= 0)
        {

                Destroy(gameObject);


        }
        OnChangeHP();





    }
    /*
        public void OnCollisionStay2D (Collision2D other)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rigid.velocity = new Vector2(rigid.velocity.x, 0);
                rigid.AddForce(new Vector2(0, UpForce));
            }
        }
        public void OnCollisionEnter2D(Collision2D other)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rigid.velocity = new Vector2(rigid.velocity.x, 0);
                rigid.AddForce(new Vector2(0, UpForce));
            }
        }
        */
    /*   public void OnCollisionExit2D(Collision2D other)
       {
           if (Input.GetKeyDown(KeyCode.Space))
           {
               rigid.velocity = new Vector2(0, 0);
               rigid.AddForce(new Vector2(0, 0));
           }
       }
       */

    [Command]
    void CmdEnergyShoot1()
    {
       
        GameObject bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.forward * 6.0f;

        
        NetworkServer.Spawn(bullet);

        //  if (side == 2)
        //Instantiate(energymissile, energymissileini.transform.position, Quaternion.identity);
        //   if (side == 1)
        // Instantiate(energymissile2, energymissileini2.transform.position, Quaternion.identity);
    }
    [Command]
    void CmdEnergyShoot2()
    {
        GameObject bullet2 = (GameObject)Instantiate(bulletPrefab2, bulletSpawn2.position, Quaternion.identity);
        bullet2.GetComponent<Rigidbody2D>().velocity = bullet2.transform.forward * -6.0f;
        NetworkServer.Spawn(bullet2);
    }

    [Command]
    void CmdEnergyShoot3()
    {
        GameObject bullet3 = (GameObject)Instantiate(bulletPrefab3, bulletSpawn3.position, Quaternion.identity);
        bullet3.GetComponent<Rigidbody2D>().velocity = bullet3.transform.forward * 6.0f;
        NetworkServer.Spawn(bullet3);
        currentHP -= amount2;
    }

    [Command]
    void CmdEnergyShoot4()
    {
        GameObject bullet4 = (GameObject)Instantiate(bulletPrefab4, bulletSpawn4.position, Quaternion.identity);
        bullet4.GetComponent<Rigidbody2D>().velocity = bullet4.transform.forward * -6.0f;
        NetworkServer.Spawn(bullet4);
        currentHP -= amount2;
    }


    public void OnChangeHP()
    {
        Vector2 scale = transform.localScale;

        if (currentHP == 90)
        {
            scale.x = 0.9f;
            HPbar.transform.localScale = scale;
        }
        if (currentHP == 80)
        {
            scale.x = 0.8f;
            HPbar.transform.localScale = scale;
        }
        if (currentHP == 70)
        {
            scale.x = 0.7f;
            HPbar.transform.localScale = scale;
        }
        if (currentHP == 60)
        {
            scale.x = 0.6f;
            HPbar.transform.localScale = scale;
        }
        if (currentHP == 50)
        {
            scale.x = 0.5f;
            HPbar.transform.localScale = scale;
        }
        if (currentHP == 40)
        {
            scale.x = 0.4f;
            HPbar.transform.localScale = scale;
        }
        if (currentHP == 30)
        {
            scale.x = 0.3f;
            HPbar.transform.localScale = scale;
        }
        if (currentHP == 20)
        {
            scale.x = 0.2f;
            HPbar.transform.localScale = scale;
        }
        if (currentHP == 10)
        {
            scale.x = 0.1f;
            HPbar.transform.localScale = scale;
        }
        if (currentHP == 0)
        {
            scale.x = 0;
            HPbar.transform.localScale = scale;
        }

    }
    public void TakeDamage()
    {
        if (!isServer)
        {
            return;
        }
        currentHP -= amount;
        
        

        // TODO network

    }

    public void OnTriggerEnter2D()
    {
       OnChangeHP();
        TakeDamage();
        if (currentHP <= 0)
        {

            Destroy(gameObject);


        }
    }

    public override void OnStartLocalPlayer()
    {
        GetComponent<SpriteRenderer>().color = Color.blue;
    }

    
}
