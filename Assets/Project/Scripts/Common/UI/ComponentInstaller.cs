using UnityEngine.AI;
using UnityEngine.UI;
using Zenject;

namespace WonderGame.Common.UI {
    public class ComponentInstaller : MonoInstaller<ComponentInstaller> {
        public override void InstallBindings() {
            Container.Bind<Button>().FromComponentSibling();        // minden Button ugyanarról a GameObjectről
            Container.Bind<NavMeshAgent>().FromComponentSibling();  // minden NavMeshAgentet ugyanarról a GameObjectről  
        }
    }
}