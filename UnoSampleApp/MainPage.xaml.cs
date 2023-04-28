using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UnoSampleApp;

/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public partial class MainPage : Page, INotifyPropertyChanged
{
    private bool _isOrdering;

    public MainPage()
    {
        this.InitializeComponent();
    }

    void ToggleReorder(object sender, RoutedEventArgs e)
    {
        IsOrdering = !IsOrdering;
    }

    public bool IsOrdering
    {
        get => _isOrdering;
        set
        {
            _isOrdering = value;
            OnPropertyChanged(nameof(IsOrdering));
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
