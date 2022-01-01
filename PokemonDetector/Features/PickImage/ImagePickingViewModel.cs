using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using PokemonDetector.Models;
using Newtonsoft.Json;
using Plugin.Media;
using Plugin.Media.Abstractions;
using TinyCacheLib;
using MvvmHelpers;
using TinyMvvm;
using TinyMvvm.IoC;
using Xamarin.Essentials;
using PokemonDetector.Contracts;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace PokemonDetector.ViewModels
{
    public class ImagePickingViewModel : BaseViewModel
    {
        private readonly IClassifier defaultClassifier;
        private readonly IClassifier offlineClassifier;

        public ImagePickingViewModel()
        {
            this.defaultClassifier = Resolver.Resolve<IClassifier>();
            offlineClassifier = Resolver.Resolve<IClassifier>("OfflineClassifier");

        }

        public ICommand PickPhoto => new Command(async () =>
        {
            var file = await CrossMedia.Current.PickPhotoAsync();

            await HandlePhoto(file);
        });

        public ICommand TakePhoto => new Command(async () =>
        {
            var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions()
            {
                CompressionQuality = 50,
                CustomPhotoSize = 50
            });

            await HandlePhoto(file);
        });

        private async Task HandlePhoto(MediaFile file)
        {
            var stream = file.GetStreamWithImageRotatedForExternalStorage();

            var memoryStream = new MemoryStream();

            stream.CopyTo(memoryStream);

            var bytes = memoryStream.ToArray();

            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                try
                {
                    defaultClassifier.ClassificationCompleted += Classifier_ClassificationCompleted;

                    await defaultClassifier.Classify(bytes);
                }
                catch (Exception ex)
                {
                    ToastProvider.LongAlert("Something went wrong");
                }
            }
            else
            {
                try
                {
                    offlineClassifier.ClassificationCompleted += Classifier_ClassificationCompleted;
                    await offlineClassifier.Classify(bytes);
                }
                catch(Exception ex)
                {
                    ToastProvider.LongAlert("Something went wrong");
                }
            }

            
        }

        private void Classifier_ClassificationCompleted(object sender, ClassificationEventArgs e)
        {
            var sortedList = e.Predictions.OrderByDescending(x => x.Probability);

            var top = sortedList.First();

            if (top.Probability >= 0.8)
            {
                var pokemonName = top.TagName;
                ToastProvider.LongAlert("It's "+ pokemonName);
            }
            else
            {
                ToastProvider.LongAlert("Unknown pokemon!");
            }
            var classifier = (IClassifier)sender;
            classifier.ClassificationCompleted -= Classifier_ClassificationCompleted;
        }
    }
}
