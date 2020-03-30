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
        string arguments = "";
        if(args.Length > 1)
        {
            arguments = args[1];
            for (int i = 2; i < args.Length; i++)
            {
                arguments += " " + args[i];
            }
        }
        bool valid = false;
        if (cmd.StartsWith("help"))
        {
            Help();
            valid = true;
        }
        if (cmd.StartsWith("quit"))
        {
            commandLog.AddMessage("Exiting game", "<#0000ff><b><i>" + cmd + "</i></b></color> " + arguments);
            StartCoroutine("Quit");
            valid = true;
        }
        if (cmd.StartsWith("reload"))
        {
            commandLog.AddMessage("Reloading current scene", "<#0000ff><b><i>" + cmd + "</i></b></color> " + arguments);
            StartCoroutine("Reload");
            valid = true;
        }
        if (cmd.StartsWith("ping"))
        {
            commandLog.AddMessage("pong", "<#00ff00><b><i>" + cmd + "</i></b></color> " + arguments);
            Reload();
            valid = true;
        }
        if (!valid)
        {
            commandLog.AddMessage("<#ff0000><i>Error</i></color> : Unkown Command. type 'help' for list of commands.", "<#ff0000><i>"+cmd+ "</i></color> " + arguments);
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
