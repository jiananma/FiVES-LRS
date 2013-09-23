using System;
using FIVES;
using System.Collections.Generic;
using KIARA;
using Events;
using Location;

namespace Editing
{
    /// <summary>
    /// Plugin that allows changing the world by the users.
    /// </summary>
    public class EditingPlugin : IPluginInitializer
    {
        #region IPluginInitializer implementation

        public string GetName()
        {
            return "Editing";
        }

        public List<string> GetDependencies()
        {
            return new List<string>() { "Location" };
        }

        public void Initialize()
        {
            PluginManager.Instance.AddPluginLoadedHandler("ClientManager", RegisterEditingAPI);
        }

        #endregion

        /// <summary>
        /// Creates an entity at x, y and z.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="z">The z coordinate.</param>
        public string CreateEntityAt(Vector position)
        {
            Entity entity = new Entity();
            entity["position"]["x"] = position.x;
            entity["position"]["y"] = position.y;
            entity["position"]["z"] = position.z;
            EntityRegistry.Instance.AddEntity(entity);
            return entity.Guid.ToString ();
        }

            EntityRegistry.Instance.AddEntity(entity);
            return entity.Guid.ToString ();
        }

        /// <summary>
        /// Registers editing APIs with the ClientManager plugin.
        /// </summary>
        private void RegisterEditingAPI() {
            var clientManager = ServiceFactory.DiscoverByName("clientmanager", ContextFactory.GetContext("inter-plugin"));
            clientManager.OnConnected += delegate(Connection connection) {
                connection["registerClientService"]("editing", true, new Dictionary<string, Delegate> {
                    {"createEntityAt", (Func<Vector, string>)CreateEntityAt},
                });
        }
    }
}

