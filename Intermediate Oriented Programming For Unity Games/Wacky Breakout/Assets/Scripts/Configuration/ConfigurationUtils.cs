using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils
{
    #region Properties
    
    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public static float PaddleMoveUnitsPerSecond
    {
        get { return conf.PaddleMoveUnitsPerSecond; }
    }

    public static float BallImpulseForce
    {
        get{ return conf.BallImpulseForce; }
    }

    public static ConfigurationData conf;

    #endregion
    
    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize()
    {
        conf=new ConfigurationData();
    }
}
