using System;
using System.Threading.Tasks;
using Autofac;

namespace PokemonDetector.iOS
{
    public class iOSBootstrapper : IBootstrapper
    {
        public iOSBootstrapper()
        {
        }

        public void Init(ContainerBuilder builder)
        {
            builder.RegisterType<CoreMLClassifier>().Named<IClassifier>("OfflineClassifier");
        }
    }
}
