using System.ComponentModel;

namespace TaskTracker.Enums.Enumerators
{
    public enum AuthType
    {
        [Description("Basic")]
        Basic = 1,
        [Description("Oauth1")]
        Oauth1 = 2
    }
}
