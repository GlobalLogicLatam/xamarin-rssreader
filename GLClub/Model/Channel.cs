using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Core.Model
{
    public class Channel
    {
		[XmlElement("item")]
		public List<Item> Items { get; set; }

		[XmlElement("title")]
		public string Title { get; set; }
    }
}
