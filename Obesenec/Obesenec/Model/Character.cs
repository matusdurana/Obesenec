using System.ComponentModel;
using System.Runtime.CompilerServices;

public class Character : INotifyPropertyChanged
{
    private string text;
    private bool isShown;
    private const string hiddenText = "_";

    public Character(string text)
    {
        OriginalText = text;
        Text = hiddenText;
    }

    public string OriginalText { get; }

    public bool IsShown
    {
        get => isShown;
        set
        {
            isShown = value;
            if (isShown)
            {
                Text = OriginalText;
            }
            else
            {
               
            }
        }
    }

    public string Text
    {
        get => text;
        set
        {
            if (value == text) return;
            text = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}