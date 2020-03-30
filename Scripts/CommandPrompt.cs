using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using MessageWindowSystem;

public class CommandPrompt : MonoBehaviour
{
    private TMP_InputField inputField;
    private string command_text;
    public MessageWindow commandLog;
    private CommandParser parser;
    public void SubmitCommand()
    {
        command_text = inputField.text;
        inputField.text = "";
        //commandLog.AddMessage("unknown command", command_text);
        parser.ParseCommand(command_text);
    }
    
    public void FocusPrompt()
    {
        inputField.ActivateInputField();
    }
    // Start is called before the first frame update
    void Start()
    {
        inputField = GetComponent<TMP_InputField>();
        parser = GetComponent<CommandParser>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
