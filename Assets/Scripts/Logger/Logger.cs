using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Logger : MonoBehaviour, ILogger
{
    protected StreamWriter logWriter, newLogger;

    public void Start()
    {
        logWriter = new StreamWriter(Path.Combine(Application.persistentDataPath, "logs.txt"), true);
    }
    /// <summary>
    /// Getting log file and push information
    /// </summary>
    public void Log(string message)
    {
        logWriter.WriteLine(message);
        logWriter.Flush();
    }

    public void Log(string message, string path)
    {
        newLogger = new StreamWriter(Path.Combine(Application.persistentDataPath, path), true);
        newLogger.WriteLine(message);
        newLogger.Flush();
    }
    
    
    /// <summary>
    /// On application closed or off focus close a writer
    /// </summary>
    /// <param name="pauseStatus"></param>
    /// <returns></returns>
    void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            logWriter.Close();
            newLogger.Close();
        }
    }
}
