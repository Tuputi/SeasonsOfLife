using UnityEngine;
using System.Collections;

public class GrabberScript : MonoBehaviour {

    public bool grabbed;
    RaycastHit2D hit;
    public float distance = 3f;
    public Transform holdpoint;
    public float throwforce;
    public LayerMask notgrabbed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.B))
        {

            if (!grabbed)
            {
                Physics2D.queriesStartInColliders = false;

				hit = Physics2D.Raycast(transform.position + Vector3.up, new Vector2(transform.localScale.x, -0.5f).normalized, distance);
                if (hit.collider != null && hit.collider.tag == "grabbable")
                {
                    grabbed = true;

                }







                //grab
            }
            else
            {
                grabbed = false;

                if (hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
                {

                    hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x, 1) * throwforce;
                }

                //throw
            }


        }



        if (grabbed)
            hit.collider.gameObject.transform.position = holdpoint.position;




    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Vector3 v = transform.position;


		Gizmos.DrawLine(transform.position + Vector3.up, transform.position + Vector3.up*0.5f + Vector3.right * transform.localScale.x * distance);
    }
}
