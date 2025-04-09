using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    /*[SerializeField] float speed;*/

    [SerializeField] Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));

        Vector3 scale = transform.localScale;

        if (horizontalInput < 0)
        {
            scale.x = -Mathf.Abs(scale.x); // Keep it -2 if it was 2
        }
        else if (horizontalInput > 0)
        {
            scale.x = Mathf.Abs(scale.x); // Keep it +2
        }

        transform.localScale = scale;

    }


}
