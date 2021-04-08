using System;


namespace Asteroids
{
    [Flags]
    internal enum Target
    {
        None     = 0,
        Enemy    = 1,
        Autocast = 2,
        Passive  = 4,
    }
}