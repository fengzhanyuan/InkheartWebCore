using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InkheartWeb.Entities.ChapterEntity
{
    public class Chapter
    {
        /// <summary>
        /// Id
        /// </summary>		
        private long _id;
        public long Id
        {
            get;
            set;
        }
        /// <summary>
        /// VolumeNo
        /// </summary>		
        private int  _volumeno;
        public int VolumeNo
        {
            get;
            set;
        }
        /// <summary>
        /// ChapterNo
        /// </summary>		
        private int _chapterno;
        public int ChapterNo
        {
            get;
            set;
        }
        /// <summary>
        /// ChapterTxt
        /// </summary>		
        private string _chaptertxt;
        public string ChapterTxt
        {
            get;
            set;
        }
        /// <summary>
        /// FatherId
        /// </summary>		
        private long _fatherid;
        public long FatherId
        {
            get;
            set;
        }

        /// <summary>
        /// Date
        /// </summary>
        private DateTime _date;
        public DateTime Date
        {
            get;
            set;
        }

        private string  _body;
        public string Body
        {
            get;
            set;
        }
    }
}
