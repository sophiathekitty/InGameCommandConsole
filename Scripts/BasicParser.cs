﻿using System.Collections;
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
            foreach (MessageDisplay msg in commandLog.messages)
                msg.life_time = 0;
            string help_txt = "<#0f0><b><i>cls</i></b></color>		clears command log\n";
            help_txt += "<#0f0><b><i>help</i></b></color>		shows this list\n";
            help_txt += "<#0f0><b><i>ping</i></b></color>		pong\n";
            help_txt += "<#00f><b><i>reload</i></b></color>	reloads current scene\n";
            help_txt += "<#00f><b><i>exit</i></b></color>		shut down game";
            commandLog.AddMessage(help_txt, "<#0f0><b><i>help</i></b></color> " + arguments);

            //commandLog.AddMessage(help_txt, "<#0000ff><b><i>" + cmd + "</i></b></color> " + arguments, helpTemplate);
            valid = true;
        }
        if (cmd.StartsWith("cls"))
        {
            foreach(MessageDisplay msg in commandLog.messages)
                msg.life_time = 0;
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

}
