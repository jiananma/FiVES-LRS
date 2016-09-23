using FIVES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LangRenShaPlugin
{
    class LangRenShaPluginInitializer : IPluginInitializer
    {

        private Entity thisEntity;
        private bool gameCreated = false;


        public string Name
        {
            get { return "LangRenSha"; }
        }

        public List<string> PluginDependencies
        {
            get { return new List<string>(); }
        }

        public List<string> ComponentDependencies
        {
            get { return new List<string>(); }
        }

        public void Initialize()
        {
            while (!gameCreated)
            {

            }
            DefineComponents();
            AddEntity();
        }

        private void DefineComponents()
        {
            ComponentDefinition statusComponent = new ComponentDefinition("status");
            statusComponent.AddAttribute<int>("day");
            statusComponent.AddAttribute<string>("step");
            statusComponent.AddAttribute<bool>("witch_medicine_used");
            statusComponent.AddAttribute<bool>("witch_poison_used");
            statusComponent.AddAttribute<int>("wolf_killed");
            statusComponent.AddAttribute<int>("witch_poisoned");
            ComponentRegistry.Instance.Register(statusComponent);
        }

        private void AddEntity()
        {
            Entity e = new Entity();
            e["status"]["day"].Suggest(0);




            this.thisEntity = e;
        }

        public void Shutdown()
        {
        }

        public void InputGameConfig(int gamers, string config)
        {
            //TODO
            this.gameCreated = true;
        }

    }
}
