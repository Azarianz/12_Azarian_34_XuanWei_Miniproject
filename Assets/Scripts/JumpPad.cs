using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (anim.GetBool("isActivate") == false)
        {
            //anim.SetBool("isActivate", true);
            other.attachedRigidbody.AddForce(other.gameObject.transform.up * 45, ForceMode.Impulse);
            StartCoroutine("triggerJump");                  
        }
    }

    IEnumerator triggerJump()
    {
        anim.SetBool("isActivate", true);
        yield return new WaitForSeconds(0.3f);
        anim.SetBool("isActivate", false);
    }
}
