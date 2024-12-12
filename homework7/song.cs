using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace homework7
{
    internal class Song
    {
        public string name { get; private set; }
        public string author { get; private set; }
        public Song? prev { get; private set; } = null;

        public Song(string name, string author)
        {
            this.name = name;
            this.author = author;
        }

        /// <summary>
        /// изменение значений
        /// </summary>
        public void SetName(string name)
        {
            this.name = name;
        }
        public void SetAuthor(string author)
        {
            this.author = author;
        }
        public void SetPrev(Song prev)
        {
            this.prev = prev;
        }

        /// <summary>
        /// вывод даннхы песни
        /// </summary>
        public string Title()
        {
            return $"{name} - {author}";
        }

        /// <summary>
        /// переопределение  equals
        /// </summary>
        public override bool Equals(object obj)
        {
            if (obj is Song otherSong)
            {
                return (name == otherSong.name && author == otherSong.author);
            }
            return false;
        }
        
        /// <summary>
        /// переопределение hashcode
        /// </summary>
        public override int GetHashCode()
        {
            return HashCode.Combine(name, author);
        }
    }
}
