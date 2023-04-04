using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
namespace _6002.Model
{
    public class Repo
    {
        private List<Words> _words;
        public List<Words> TheList
        {
            get { return _words; }
            set { _words = value; }
        }
        private int _count;
        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }

      public async void FillWordList()
        {
            String line;
            Words aWord = new Words();
            try
            {
                string DataFile = "words.txt";
                using Stream fileStream = await FileSystem.OpenAppPackageFileAsync(DataFile);
                using StreamReader reader = new StreamReader(fileStream);
                while ((line = reader.ReadLine()) != null)
                {
                    aWord = new Words();
                    aWord.MyWord = line;
                    _words.Add(aWord);
                    
                }
             }
            catch (Exception ex) 
            {
                    Words error = new Words(); 
                    error.MyWord = ex.ToString();
                    _words.Add(error);
            }

        }
        public String RandomWord()
        {
            _words = new List<Words>();
            FillWordList();
            var random = new Random();
            int index = random.Next(_words.Count);
            String word = _words[index].MyWord;
            return word;
        }
        public bool isWord(string Guess)
        {
            _words = new List<Words>();
            FillWordList();
            for(int i=0; i<_words.Count; i++)
            {
                if (Guess == _words[i].MyWord)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
