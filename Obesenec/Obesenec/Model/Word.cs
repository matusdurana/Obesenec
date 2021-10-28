using System.Collections.Generic;

namespace Obesenec.Model
{
    internal class Word
    {
        private string word;
        private List<Character> listOfCharacters;

        public Word(string word)
        {
            this.word = word;
        }

        public List<Character> GetListOfCharacters()
        {
            listOfCharacters = new List<Character>();
            foreach (var c in word.ToCharArray())
            {
                listOfCharacters.Add(new Character(c.ToString()));
            }

            return listOfCharacters;
        }
    }
}