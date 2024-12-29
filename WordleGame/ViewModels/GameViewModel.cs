using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WordleGame
{
    public class GameViewModel :INotifyPropertyChanged
    {
        private GetWordList getWords;
        private Random word;

        private string _currentWord;
        public ObservableCollection<string> Words { get; set; }
        
        public string currentWord
        {
            get => _currentWord;

            set
            {
                if (_currentWord != value)
                {
                    _currentWord = value;
                    OnPropertyChanged();
                }
            }

        }
           

        public GameViewModel()
        {
            getWords = new GetWordList();
            word = new Random();
            Words = new ObservableCollection<string>();
        }

        //method to load words into memory and store them in list
        public async Task MakeWordList()
        {
            await getWords.EnsureWordListExistsAsync();

            
            List<string> wordList = await getWords.LoadWordsAsync();

            foreach (var word in wordList)
            {
                 Words.Add(word);
            }
                 RandomiseWords();
            }

        //method to randomise the words 
        public void RandomiseWords()
        {
            if (Words.Count > 0)
            {
                currentWord = Words[word.Next(Words.Count)];
            }
        }

         public event PropertyChangedEventHandler PropertyChanged;
         protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
         {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
         }
        }
    }





