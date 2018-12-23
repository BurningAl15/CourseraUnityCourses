using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

/// <summary>
/// A container for the configuration data
/// </summary>
public class ConfigurationData
{
    #region Fields

    const string ConfigurationDataFileName = "ConfigurationData.csv";

    // configuration data with default values
    static float teddyBearMoveUnitsPerSecond = 5;
    static float cooldownSeconds = 1;

    static float teddyBearProjectileImpulseforce=8f;
    static int teddyBearProjectileDamage=5;
    static float frenchFriesProjectileImpulseForce=10f;
    static int frenchFriesProjectileDamage=5;

    static int maxBears=5;
    static int bearPoints=10;
    static int bearDamage=10;
    static float bearMaxImpulseForce=5f;
    static float bearMinImpulseForce=2f;

    static float bearFiringDelay=.5f;
    static float bearFiringRateRange=1f;

    static float burgerMoveUnitsPerSecond=2f;
    static float burgerCooldownSeconds=1f;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the teddy bear move units per second
    /// </summary>
    /// <value>teddy bear move units per second</value>
    public float TeddyBearMoveUnitsPerSecond
    {
        get { return teddyBearMoveUnitsPerSecond; }
    }
        
    /// <summary>
    /// Gets the cooldown seconds for shooting
    /// </summary>
    /// <value>cooldown seconds</value>
    public float CooldownSeconds
    {
        get { return cooldownSeconds; }    
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Constructor
    /// Reads configuration data from a file. If the file
    /// read fails, the object contains default values for
    /// the configuration data
    /// </summary>
    public ConfigurationData()
    {
        // read and save configuration data from file
        StreamReader input=null;
        try
        {
            input=File.OpenText(Path.Combine(Application.streamingAssetsPath,ConfigurationDataFileName));

            string name=input.ReadLine();
            string values=input.ReadLine();

            SetConfigurationDataFields(values);
        }
        catch(System.Exception e)
        {
        }
        finally
        {
            if(input!=null)
                input.Close();
        }
    }


    /// <summary>
    /// Sets the configuration data fields from the provided
    /// csv string
    /// </summary>
    /// <param name="csvValues">csv string of values</param>
    static void SetConfigurationDataFields(string csvValues)
    {
        string[] values=csvValues.Split(',');
        teddyBearMoveUnitsPerSecond=float.Parse(values[0]);
        cooldownSeconds=float.Parse(values[1]);
        //teddyBearProjectileImpulseforce=float.Parse(values[0]);
        //teddyBearProjectileDamage=int.Parse(values[1]);
       
        //frenchFriesProjectileImpulseForce=float.Parse(values[2]);
        //frenchFriesProjectileDamage=int.Parse(values[3]);

        //maxBears=int.Parse(values[4]);
        //bearPoints=int.Parse(values[5]);
        //bearDamage=int.Parse(values[6]);
        //bearMaxImpulseForce=float.Parse(values[7]);
        //bearFiringDelay=float.Parse(values[8]);
        //bearFiringRateRange=float.Parse(values[9]);

        //burgerMoveUnitsPerSecond=float.Parse(values[10]);
        //burgerCooldownSeconds=float.Parse(values[11]);
    }

    #endregion
}
