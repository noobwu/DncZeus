using System;

namespace Noob.Settings
{
    [Serializable]
    public class SettingValue : NameValue
    {
        public SettingValue()
        {

        }

        public SettingValue(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }
}