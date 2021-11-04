using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireShoop : MonoBehaviour
{

    public Transform FirePoint;
    public GameObject Bullet;
    public GameObject effect;
    public GameObject effectMusic;
    public float shoot;
    public float bullet;
    public bool Shootihg;
    public bool TimeS = false;
    public float WhatShoot;
    public float WhatShootTime;
    public float Shoot_Time;
    private bool Shoot_Time_Bool;
    public float Start_Shoot_Time;
    public Text textBullet;

    private void Start()
    {
        Shootihg = true;
        WhatShootTime = WhatShoot;
        bullet = shoot;
    }
    public void Shoot()
    {
        if(Shootihg == true && bullet != 0) {
            if(Shoot_Time <= 0)
            {
                Instantiate(effect, FirePoint.position, FirePoint.rotation);
                Instantiate(Bullet, FirePoint.position, FirePoint.rotation);
                Instantiate(effectMusic, FirePoint.position, FirePoint.rotation);
                bullet--;
                Shoot_Time = Start_Shoot_Time;
                Shoot_Time_Bool = true;

            }
            else
            {
                Shoot_Time_Bool = false;
            }
            
        }
    }

    void Update()
    {
        textBullet.text = bullet + "/" + shoot;
        if (bullet <= 0)
            shooting();
        if (TimeS == true)
            Buttonshooting();
        if (bullet > shoot)
            bullet = shoot;
        if(Shoot_Time_Bool == false)
        {
            Shoot_Time -= Time.deltaTime;
        }
    }

    public void shooting()
    {
        Shootihg = false;
        WhatShootTime -= Time.deltaTime;
        if(WhatShootTime <= 0)
        {
            bullet = shoot;
            WhatShootTime = WhatShoot;
            Shootihg = true;
        }
    }
    public void Buttonshooting()
    {
        TimeS = true;
        Shootihg = false;
        WhatShootTime -= Time.deltaTime;
        if (WhatShootTime <= 0)
        {
            bullet = shoot;
            WhatShootTime = WhatShoot;
            Shootihg = true;
            TimeS = false;
        }
            
    }
}
