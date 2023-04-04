using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehaviour : MonoBehaviour
{
    private GameObject stickmanBody;

    private Animator stickmanAnim;

    public void Awake()
    {
        stickmanBody = GameObject.Find("Stickman");

        stickmanAnim = stickmanBody.GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 7)
        {
            if (transform.position.y < collision.transform.position.y + collision.transform.localScale.y / 2)
            {
                Destroy(collision.gameObject);

                GameObject stickman = GameObject.Find("Stickman");
                stickman.transform.position += Vector3.up;
                GameObject stackCube = Instantiate(Resources.Load("StackCube"), stickman.transform.position + new Vector3(0, -0.5f, 0), Quaternion.identity) as GameObject;
                stackCube.transform.parent = this.transform.parent;

                //player jumping
                stickmanAnim.SetTrigger("Jump");
            }
        }
        else if(collision.gameObject.layer == 6)
        {
            if ((transform.position.y < collision.transform.position.y + collision.transform.localScale.y && transform.position.y > collision.transform.position.y) || (transform.position.y < collision.transform.position.y && transform.position.y - collision.transform.position.y > 0.25f))
            {
                transform.parent = collision.gameObject.transform;
                Destroy(GetComponent<CubeBehaviour>());
            }
        }
    }

}
