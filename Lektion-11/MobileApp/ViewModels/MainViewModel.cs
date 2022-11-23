using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MobileApp.Models;
using MobileApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        public MainViewModel()
        {
            items = new ObservableCollection<Todo>();
        }

        [ObservableProperty]
        private string text;

        [ObservableProperty]
        private ObservableCollection<Todo> items;

        [RelayCommand]
        private void Add()
        {
            if (string.IsNullOrWhiteSpace(Text))
                return;

            Items.Add(new Todo { Text = text });
            Text = string.Empty;
        }

        [RelayCommand]
        private void Delete(Todo todo)
        {
            Console.WriteLine("Delete Triggered");
            Console.WriteLine(todo.Text);
            
            if (Items.Contains(todo))
                Items.Remove(todo);

        }


        [RelayCommand]
        private async Task Tap(Todo todo)
        {
            await Shell.Current.GoToAsync($"{nameof(DetailsPage)}", new Dictionary<string, object>
            {
                { nameof(Todo), todo }
            });
        }

        [RelayCommand]
        private async Task Qr()
        {
            await Shell.Current.GoToAsync(nameof(QrPage));
        }
    }
}
