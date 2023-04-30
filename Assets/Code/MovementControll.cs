using UnityEngine;
using UnityEngine.AI;

public class MovementControll : MonoBehaviour {
    public Camera cam;
    public NavMeshAgent agent;
    public Animator animator;
    [SerializeField] SpriteRenderer spriteObject;
    private void Update() {
        if (Input.GetMouseButtonDown(1)) {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) {
                agent.SetDestination(hit.point);
            }
        }
    }

    private void FixedUpdate() {
        WalkIdleChange();
        MirrorSprite();
    }

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

    float lastPos;
    void MirrorSprite() {
        float direction = agent.nextPosition.x;

        if (direction < lastPos) {
            spriteObject.flipX = true;
        }
        else if (direction > lastPos) {
            spriteObject.flipX = false;
        }
        lastPos = direction;
    }

    public GameObject[] cameraObj;
    private void Awake() {
        cameraObj = GameObject.FindGameObjectsWithTag("MainCamera");
        cam = cameraObj[0].GetComponent<Camera>();
    }

}
