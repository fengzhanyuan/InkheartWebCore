using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InkheartWeb.Entities.StoryEntity
{
    public class Book
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
        /// Name
        /// </summary>		
        private string _name;
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// Title
        /// </summary>		
        private string _title;
        public string Title
        {
            get;
            set;
        }
        /// <summary>
        /// Introduction
        /// </summary>		
        private string _introduction;
        public string Introduction
        {
            get;
            set;
        }
        /// <summary>
        /// Author
        /// </summary>		
        private string _author;
        public string Author
        {
            get;
            set;
        }
        /// <summary>
        /// Price
        /// </summary>		
        private decimal _price;
        public decimal Price
        {
            get;
            set;
        }
        /// <summary>
        /// Type
        /// </summary>		
        private string _type;
        public string Type
        {
            get;
            set;
        }

        /// <summary>
        /// 频道
        /// </summary>		
        private string _channel;
        public string Channel
        {
            get;
            set;
        }
        /// <summary>
        /// Word_count
        /// </summary>		
        private long _word_count;
        public long Word_count
        {
            get;
            set;
        }
        /// <summary>
        /// Tag
        /// </summary>		
        private string _tag;
        public string Tag
        {
            get;
            set;
        }
        /// <summary>
        /// CreateTime
        /// </summary>		
        private DateTime _createtime;
        public DateTime CreateTime
        {
            get;
            set;
        }
        /// <summary>
        /// GroupId
        /// </summary>		
        private int _groupid;
        public int GroupId
        {
            get;
            set;
        }
        /// <summary>
        /// Url
        /// </summary>		
        private string _url;
        public string Url
        {
            get;
            set;
        }
        /// <summary>
        /// ImageCover
        /// </summary>		
        private string _imagecover;
        public string ImageCover
        {
            get;
            set;
        }
        /// <summary>
        /// VIP
        /// </summary>		
        private bool _vip;
        public bool VIP
        {
            get;
            set;
        }


    }
}
