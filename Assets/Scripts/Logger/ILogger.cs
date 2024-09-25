using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILogger
{
    ///<summary>
    ///Default Logger
    ///</summary>
    public void Log(string message);

    ///<summary>
    ///Logger With a file realized
    ///</summary>
    public void Log(string message, string path);

}
