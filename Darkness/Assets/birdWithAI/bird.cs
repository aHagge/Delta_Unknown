using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird : MonoBehaviour
{

    GameObject birdOBJ;

    public float speed;

    Transform target;

     bool flyToTarget;
     bool isFlyingtoSky;
     bool isFlyingAround;
     bool isGliding;
     bool isIdling;
     bool onBranch;
     bool onGround;

     GameObject[] landPoints;
     Animator anim;
    public bool DEBUG;
   // Transform closestBrench;

    private void Start()
    {
        birdOBJ = this.gameObject;
        target = GameObject.FindGameObjectWithTag("birdTarget").transform;
        StartCoroutine(wait());
        landPoints = GameObject.FindGameObjectsWithTag("landPoint");
        anim = GetComponent<Animator>();

    }
    private void OnDrawGizmos()
    {
        if (DEBUG)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(birdOBJ.transform.position, target.position);
        }
    }
    float distanceToTarget()
    {
        return Vector3.Distance(birdOBJ.transform.position, target.position);
    }
    void flyToSky()
    {
        target.position = birdOBJ.transform.position + new Vector3(Random.Range(1f, 2.0f), Random.Range(2.5f, 5.5f), Random.Range(3f,6f));
        anim.SetBool("takeoff",true);
        anim.SetBool("landing", false);
        isFlyingtoSky = true;
        flyToTarget = true;
        anim.SetBool("glide", false);

    }
    void flyToBranch()
    {
        
        target.position = GetClosestBranch().position;

        onBranch = true;
    }
        
        
    void flyAround()
    {

        isFlyingAround = true;
        target.position = birdOBJ.transform.position + new Vector3(Random.Range(-15f, 15f),birdOBJ.transform.position.y, Random.Range(-16f, 15f));

    }
    Transform GetClosestBranch()
    {
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        
        foreach (GameObject t in landPoints)
        {


            float dist = Vector3.Distance(t.transform.position, birdOBJ.transform.position);
            if (dist < minDist)
            {
                tMin = t.transform;
                minDist = dist;
            }


        }
        return tMin;
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(3);
        flyToSky();
    }

    void GoToIdleState()
    {
        anim.SetBool("takeoff", false);
    
        isFlyingAround = false;
        isGliding = false;
        isIdling = true;
        birdOBJ.transform.Rotate(0, 0, 0);
        flyToTarget = false;
    }
    IEnumerator waitAfterLand()
    {
        onBranch = false;
        isIdling = false;
        yield return new WaitForSeconds(5);
        flyToSky();

    }
    private void Update()
    {
        if(isIdling && onBranch)
        {    
            StartCoroutine(waitAfterLand());
        }
        if(isGliding) 
        {
            if(distanceToTarget() < 0.35f) 
            {
                anim.SetBool("landing", true);

                GoToIdleState();

               

            }
        }
        if(isFlyingtoSky)
        {
            if(distanceToTarget() < 0.5f)
            {
                isFlyingtoSky = false;
                flyAround();

            }

        }
        if(isFlyingAround)
        {
            if(distanceToTarget() < 0.5f)
            {
                
                anim.SetBool("glide", true);
                isFlyingAround = false;
                isGliding = true;
                
                flyToBranch();



            }
        }
        if (flyToTarget)
        {

            birdOBJ.transform.LookAt(target);
            birdOBJ.transform.position = Vector3.MoveTowards(birdOBJ.transform.position, target.position, Time.deltaTime * speed);


        }



    }






}
