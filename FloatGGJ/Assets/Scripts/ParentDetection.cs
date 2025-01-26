using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentDetection : MonoBehaviour
{
    private bool lookDown = true;
    public float detectionRange;
    public Animator parentAnimator;
    LayerMask layerMask;
    public int waitPeriod;
    AnimatorStateInfo stateInfo;
    void Start(){
        layerMask = LayerMask.GetMask("Player");
    }
    // Update is called once per frame
    void Update()
    {
        stateInfo = parentAnimator.GetCurrentAnimatorStateInfo(0);
        if(lookDown && (stateInfo.IsName("Mom_LookDown") || stateInfo.IsName("Dad_LookDown"))) {
            StartCoroutine(LookUp());
        }
    }

    IEnumerator LookUp() {
        yield return new WaitForSeconds(waitPeriod);
        lookDown = false;
        StartCoroutine(LookDown());
    }

    IEnumerator LookDown() {
        yield return new WaitForSeconds(waitPeriod);
        lookDown = true;
    }

    void FixedUpdate()
    {
        if(lookDown == false) {
            for(float i = 0; i < detectionRange; i+=0.2f) {
                ShootRaycast(i);
            }
        }
    }

    void ShootRaycast(float xPosition) {
        RaycastHit hit;
        Vector3 rotatedDirection = Quaternion.Euler(-90, 0, 0) * transform.forward;
        Vector3 position = new Vector3(transform.position.x - 2.5f + xPosition, transform.position.y - 3.5f, transform.position.z);
        if (Physics.Raycast(position, rotatedDirection, out hit, Mathf.Infinity, layerMask))
        { 
            Debug.DrawRay(position, rotatedDirection * hit.distance, Color.yellow); 
            Debug.Log("Parents noticed you!"); 
        }
        else
        { 
            Debug.DrawRay(position, rotatedDirection * 1000, Color.white); 
        }
    }
}
