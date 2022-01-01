using System;
using System.Reflection;
using Autofac;
using PokemonDetector.Contracts;
using PokemonDetector.ViewModels;
using PokemonDetector.Views;
using TinyCacheLib;
using TinyCacheLib.FileStorage;
using TinyMvvm.Autofac;
using TinyMvvm.IoC;
using TinyNavigationHelper;
using TinyNavigationHelper.Forms;
using Xamarin.Forms;

namespace PokemonDetector
{
    public static class Bootstrapper
    {
        public static IBootstrapper Platform { get; set; }

        public static void Init(Application app)
        {
            var builder = new ContainerBuilder();

            Platform?.Init(builder);

            var navigation = new FormsNavigationHelper(app);
            navigation.RegisterViewsInAssembly(Assembly.GetExecutingAssembly());

            builder.RegisterType<ImagePickingView>();
            builder.RegisterType<PokemonListView>();

            builder.RegisterType<FormsNavigationHelper>().As<INavigationHelper>();

            builder.RegisterType<ImagePickingViewModel>();
            builder.RegisterType<PokemonListViewModel>();

            builder.RegisterType<OnlineClassifier>().As<IClassifier>();
            builder.RegisterType<IToastProvider>();

            var container = builder.Build();

            Resolver.SetResolver(new AutofacResolver(container));

            TinyMvvm.Forms.TinyMvvm.Initialize();

            var cache = TinyCacheHandler.Create("FileCache");

            var fileStorage = new FileStorage();
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            fileStorage.Initialize(path);

            cache.SetCacheStore(fileStorage);
        }
    }

    public interface IBootstrapper
    {
        void Init(ContainerBuilder builder);
    }
}
