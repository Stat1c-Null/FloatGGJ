using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentDetection : MonoBehaviour
{
    public Material lookDownSprite;
    public Material lookUpSprite;
    private bool lookDown = true;
    MeshRenderer mesh;
    LayerMask layerMask;
    void Start(){
        mesh = GetComponent<MeshRenderer>();
        mesh.material = lookDownSprite;
        layerMask = LayerMask.GetMask("Player");
    }
    // Update is called once per frame
    void Update()
    {
        if(lookDown) {
            StartCoroutine(LookUp());
        }
    }

    IEnumerator LookUp() {
        yield return new WaitForSeconds(3);
        mesh.material = lookUpSprite;
        lookDown = false;
        StartCoroutine(LookDown());
    }

    IEnumerator LookDown() {
        yield return new WaitForSeconds(3);
        mesh.material = lookDownSprite;
        lookDown = true;
    }

    void FixedUpdate()
    {
        if(lookDown == false) {
            for(float i = 0; i < 3; i+=0.2f) {
                ShootRaycast(i);
            }
        }
    }

    void ShootRaycast(float xPosition) {
        RaycastHit hit;
        Vector3 rotatedDirection = Quaternion.Euler(-90, 0, 0) * transform.forward;
        Vector3 position = new Vector3(transform.position.x - 1.5f + xPosition, transform.position.y - 3.5f, transform.position.z);
        if (Physics.Raycast(position, rotatedDirection, out hit, Mathf.Infinity, layerMask))
        { 
            Debug.DrawRay(position, rotatedDirection * hit.distance, Color.yellow); 
            Debug.Log("Did Hit"); 
        }
        else
        { 
            Debug.DrawRay(position, rotatedDirection * 1000, Color.white); 
        }
    }
}
