using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromptAutohide : MonoBehaviour
{
    private CommandPrompt commandPrompt;
    private Animator animator;

    public bool showPrompt;

    public void ShowPrompt()
    {
        showPrompt = true;
        animator.SetBool("Show", showPrompt);
        commandPrompt.FocusPrompt();
    }
    public void HidePrompt()
    {
        showPrompt = false;
        animator.SetBool("Show", showPrompt);
    }

    // Start is called before the first frame update
    void Start()
    {
        commandPrompt = GetComponentInChildren<CommandPrompt>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.BackQuote))
        {
            ShowPrompt();
        }
    }
}
