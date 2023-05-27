using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApp.Database.Repository
{
    public abstract class BaseRepository
    {
        protected string _fileName;

        public abstract void LoadFromFile();
        public abstract void SaveToFile();
    }
}
