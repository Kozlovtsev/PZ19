using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;


namespace pz_19.Services
{
    public static class RepoContainer
    {
        private static readonly Unity.IUnityContainer _container;

        static RepoContainer()
        {
            _container = new Unity.UnityContainer();
            _container.RegisterType<IUserRepository, UserRepository>(new Unity.Lifetime.ContainerControlledLifetimeManager());
            _container.RegisterType<IRequestRepository, RequestRepository>(new Unity.Lifetime.ContainerControlledLifetimeManager());
        }

        public static Unity.IUnityContainer Container => _container;
    }
}
