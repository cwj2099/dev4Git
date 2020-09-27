using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class Script_movement : MonoBehaviour
{
    public DragonBones.UnityArmatureComponent thisSprite;
    public Rigidbody2D thisRigidbody2d;
    public float force = 10f;
    public float grav_ground = 7;
    public float grav_air = 7;
    public Script_manager manager;
    public Script_GroundCheck groundScript;
    public Boolean fly = true;
    public GameObject tele;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if (groundScript.grounded){
            fly = true;
            if (!(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
            {
                if (thisSprite.animationName != "idle") { thisSprite.animationName = "idle"; thisSprite.animation.FadeIn("idle", 0.2f, 0); }
            }
            else {
                if (thisSprite.animationName != "ground") { thisSprite.animationName = "ground"; thisSprite.animation.FadeIn("ground", 0.2f, 0); }
            }
            
            thisRigidbody2d.gravityScale = grav_ground;
            if (Input.GetKeyDown(KeyCode.Space)) {
                thisRigidbody2d.AddForce(Vector2.up * force, ForceMode2D.Impulse);
            }
        }
        else {
            thisRigidbody2d.gravityScale = grav_air;
            if (thisSprite.animationName != "float") { thisSprite.animationName = "float"; thisSprite.animation.FadeIn("float", 0.2f, 0); }
            if (Input.GetKeyDown(KeyCode.Space)&&manager.flyable&&fly)
            {
                thisSprite.animation.Play("float");
                fly = false;
                thisRigidbody2d.AddForce(Vector2.up * force *1.5f, ForceMode2D.Impulse);
            }
        }

        if (Input.GetKeyDown(KeyCode.Q)) {
            transform.position = tele.transform.position;
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A)) {
            thisRigidbody2d.AddForce(Vector2.left * force * Time.fixedDeltaTime, ForceMode2D.Impulse);
            thisSprite.armature.flipX = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            thisRigidbody2d.AddForce(Vector2.right * force * Time.fixedDeltaTime, ForceMode2D.Impulse);
            thisSprite.armature.flipX = false;
        }

        /*
        if (manager.flyable) {
            if (Input.GetMouseButtonDown(0)) {
                //print("attempted flying");

                cPosition = new Vector2(transform.position.x, transform.position.y);
                
                mPosistion = Mcamera.ScreenToWorldPoint(Input.mousePosition);
                mPosistion = new Vector2(mPosistion.x, mPosistion.y);
                print(cPosition);
                thisRigidbody2d.AddForce(Vector2.MoveTowards(cPosition, mPosistion,1) * force * Time.fixedDeltaTime, ForceMode2D.Impulse);
            }
        }
        */

    }
}
