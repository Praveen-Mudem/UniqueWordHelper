using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniqueWordService
{
    public sealed class MemoryService : BaseService
    {
        object _lock = new object();
        private List<string> _uniqueWordsList = new List<string>();

        public override void AddWord(string word)
        {
            lock (_lock)
            {
                _uniqueWordsList.Add(word);
            }
        }

        public override List<KeyValuePair<string, int>> GetWords()
        {
            return (from word in _uniqueWordsList.GroupBy(uword => uword)
                    select new KeyValuePair<string, int>(word.Key, word.ToList().Count)).ToList();
        }
    }
}
