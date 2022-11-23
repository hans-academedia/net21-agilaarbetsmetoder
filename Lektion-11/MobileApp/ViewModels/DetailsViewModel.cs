using CommunityToolkit.Mvvm.ComponentModel;
using MobileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.ViewModels
{
    [QueryProperty(nameof(Todo), "Todo")]
    public partial class DetailsViewModel : ObservableObject
    {
        [ObservableProperty]
        private Todo todo;
    }
}
