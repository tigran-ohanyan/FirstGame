using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public interface ISave
{
    /// <summary>
    /// Save user data
    /// </summary>
    public void SaveGame(string data);

    /// <summary>
    /// Get user save
    /// </summary>
    public void GetSave(string data);
}
