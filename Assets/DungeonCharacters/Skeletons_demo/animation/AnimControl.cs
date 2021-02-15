using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimControl : MonoBehaviour
{
    private Animator mAnimator;
    // Start is called before the first frame update
    void Start()
    {
        mAnimator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        mAnimator.SetFloat("Horizontal", Input.GetAxisRaw("Horizontal"));
        mAnimator.SetFloat("Vertical", Input.GetAxisRaw("Vertical"));

        bool walking = Input.GetKey(KeyCode.W);

        mAnimator.SetBool("walking", walking);

        if (Input.GetKeyDown(KeyCode.X))
        {
            mAnimator.SetTrigger("attack");
        }
        
    }
}
