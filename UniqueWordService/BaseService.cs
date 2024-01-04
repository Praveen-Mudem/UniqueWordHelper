using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniqueWordService
{
    public interface IWordService
    {
        void AddWord(string word);
        List<KeyValuePair<string,int>> GetWords();
    }
    public abstract class BaseService : IDisposable, IWordService
    {
        public abstract void AddWord(string word);
        public abstract List<KeyValuePair<string, int>> GetWords();
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
