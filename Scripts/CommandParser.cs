using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CommandParser : MonoBehaviour
{
    public abstract void ParseCommand(string command);
}
