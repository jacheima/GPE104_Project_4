using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelExitMenu : MonoBehaviour {

    public Animator animator;
    public Text continueText;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player is in the trigger");
            animator.SetBool("isOpen", true);
            continueText.text = "Go to level select?";
        }
        
    }
}
