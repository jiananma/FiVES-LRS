using System;
using System.Collections.Generic;
using FIVES;


namespace ClientManagerPlugin {

    /// <summary>
    /// Implements a plugin that can be used to communicate with clients using KIARA.
    /// </summary>
    public class ClientManagerPluginInitializer : IPluginInitializer
    {
        #region IPluginInitializer implementation

        public string Name
        {
            get
            {
                return "ClientManager";
            }
        }

        public List<string> RequiredPlugins
        {
            get
            {
                return new List<string> { "Auth" };
            }
        }

        public List<string> RequiredComponents
        {
            get
            {
                return new List<string>();
            }
        }
        public void Initialize()
        {
        }

        #endregion
    }

}