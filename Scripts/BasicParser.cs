using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MessageWindowSystem;
using UnityEngine.SceneManagement;

public class BasicParser : CommandParser
{
    public MessageType commandTemplate;
    public MessageType helpTemplate;
    public MessageWindow commandLog;

    public BasicParser()
    {
    }

    
    public override void ParseCommand(string command)
    {
        string[] args = command.Split(' ');
        string cmd = args[0].ToLower();
        bool valid = false;
        if (cmd.StartsWith("help"))
        {
            Help();
            valid = true;
        }
        if (cmd.StartsWith("quit"))
        {
            commandLog.AddMessage("Exiting game", "<b><i>" + cmd + "</b>");
            StartCoroutine("Quit");
            valid = true;
        }
        if (cmd.StartsWith("reload"))
        {
            commandLog.AddMessage("Reloading current scene", "<b><i>" + cmd + "</b>");
            StartCoroutine("Reload");
            valid = true;
        }
        if (cmd.StartsWith("ping"))
        {
            commandLog.AddMessage("pong", "<b><i>" + cmd + "</b>");
            Reload();
            valid = true;
        }
        if (!valid)
        {
            commandLog.AddMessage("Unkown Response", command);
        }
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(commandTemplate.display_time);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator Quit()
    {
        yield return new WaitForSeconds(commandTemplate.display_time);
        Application.Quit();
    }

    void Help()
    {

    }
}
