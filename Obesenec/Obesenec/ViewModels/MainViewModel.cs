using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using Xamarin.Forms;
using Obesenec.Model;


namespace Obesenec.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public string ImageSource { get; set; }
        private int _index;
        private int _charactersFound;
        private const int MaxNumberOfWrongGuesses = 14;

        public MainViewModel()
        {
            var word = WordSource.GetRandomWord();
            var characterList = word.GetListOfCharacters();
            List = new ObservableCollection<Character>(characterList);
            CharacterPressedCommand = new Command<string>(CharacterPressed);
            PressedCharacters = new List<string>();
            ImageSource = "HangMan1.png";
            _index = 2;
        }

        public ObservableCollection<Character> List { get; }
        public Command CharacterPressedCommand { get; }
        public List<string> PressedCharacters { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async void CharacterPressed(string character)
        {
            if (PressedCharacters.Contains(character))
                return;

            PressedCharacters.Add(character);

            var isFound = false;
            foreach (var item in List)
            {
                if (item.OriginalText.ToLower() == character.ToLower())
                {
                    item.IsShown = true;
                    isFound = true;
                    _charactersFound++;
                }
            }

            //win
            if (_charactersFound == List.Count)
            {
                await HandleGameResultAsync(true);
            }

            if (!isFound)
            {
                //lose
                if (_index == MaxNumberOfWrongGuesses)
                {
                    await HandleGameResultAsync(false);
                }

                //continue
                ChangeImage(_index);
                _index++;
            }

        }

        private async Task HandleGameResultAsync(bool isWin)
        {
            var gameResult = isWin ? "WON" : "LOST";
            var resultTask = await Application.Current.MainPage.DisplayAlert($"You {gameResult}!", "You can play NEW GAME or BACK TO MENU and select new category!", "NEW GAME", "BACK TO MENU");

            if (!resultTask)
            {
                //back to menu
                await Application.Current.MainPage.Navigation.PushAsync(new MainMenu());
                ResetRound();
            }

            //TODO: retry button   
            await Application.Current.MainPage.Navigation.PushAsync(new MainPage());

        }

        private void ResetRound()
        {
            _index = 1;
            _charactersFound = 0;
            ChangeImage(_index);
        }

        private void ChangeImage(int imageIndex)
        {
            ImageSource = $"HangMan{imageIndex}.png";
            OnPropertyChanged(nameof(ImageSource));
        }
    }
}
