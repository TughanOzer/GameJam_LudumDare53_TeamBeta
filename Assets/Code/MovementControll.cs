using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovementControll : MonoBehaviour
{

    public Camera cam;
    public NavMeshAgent agent;
    public Animator animator;
    private void Update() {
        if (Input.GetMouseButtonDown(1)) {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if( Physics.Raycast(ray, out hit)) {
                agent.SetDestination(hit.point);
            }
        }
    }

    private void FixedUpdate() {
        WalkIdleChange();
        MirrorSprite();
    }


    float currentPos;
    float lastPos;
    void WalkIdleChange() {
        float velocity = agent.velocity.magnitude;
        if (velocity > .1f) {
            // parameter im Animator
            animator.SetBool("Walking", true);
        }
        else {
            animator.SetBool("Walking", false);
        }
    }

    void MirrorSprite() {
        float direction = agent.nextPosition.x;
        Debug.Log(direction);

        if(direction < lastPos) {
            spriteObject.flipX = true;
            Debug.Log("mirrored");
        }
        else if(direction > lastPos) {
            spriteObject.flipX = false;
        }
        lastPos = direction;
    }


    [SerializeField] SpriteRenderer spriteObject;
    void MirrorTheSprite() {
        if (spriteObject.flipX) {
            spriteObject.flipX = false;
        }
        else if (!spriteObject.flipX) {
            spriteObject.flipX = true;
        }
    }
}
