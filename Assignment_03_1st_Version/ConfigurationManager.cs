using System;
using System.Collections.Generic;

public class ConfigurationManager : IConfigurationManager
{
    private static readonly ConfigurationManager _instance = new ConfigurationManager();
    public static ConfigurationManager Instance => _instance;

    private readonly Dictionary<string, string> _settings;

    // Private constructor to enforce singleton
    private ConfigurationManager()
    {
        _settings = new Dictionary<string, string>();
        // Set default settings
        _settings["DatabaseConnection"] = "localhost";
        _settings["ApiKey"] = "default-api-key";
    }

    public string GetSetting(string key)
    {
        return _settings.ContainsKey(key) ? _settings[key] : null;
    }

    public void SetSetting(string key, string value)
    {
        _settings[key] = value;
    }
}
