using UnityEngine;
using System.Collections;
using System.Xml;
using System.Text;

public static class UserData
{

	private static string pathToXml = Application.persistentDataPath + "/userData.xml";

	private static bool _musicOnTrigger;
	public static bool musicOnTrigger
	{
		get 
		{
			parseXML();
			return _musicOnTrigger;
		}
		set
		{
			_musicOnTrigger = value;
			changeXml();
		}
	}

	private static bool _soundsOnTrigger;
	public static bool soundsOnTrigger
	{
		get
		{
			parseXML();
			return _soundsOnTrigger;
		}
		set
		{
			_soundsOnTrigger = value;
			changeXml();
		}
	}

	public static void parseXML()
	{
		if(!System.IO.File.Exists(pathToXml))
		{
			createXml();
		}

		XmlDocument document = new XmlDocument();
		document.Load(pathToXml);

		XmlNode xnode = document.SelectSingleNode("Parts/dataType");
		
		if(xnode != null)
		{
			foreach(XmlNode childnode in xnode)
			{
				if(childnode.Name == "musicOnTrigger")
				{
				_musicOnTrigger = System.Convert.ToBoolean(childnode.InnerText);
					Debug.Log (childnode.Name+": "+childnode.InnerText);
				}
				if (childnode.Name == "soundsOnTrigger")
				{
				_soundsOnTrigger = System.Convert.ToBoolean(childnode.InnerText);
				Debug.Log (childnode.Name+": "+childnode.InnerText);
				}
			}
		}
		else
		{
			createXml();
			parseXML();
		}
	}

	public static void changeXml()
	{
		XmlDocument document = new XmlDocument();
		document.Load(pathToXml);
		
		XmlNode xnode = document.SelectSingleNode("userData/dataType");
		
		if(xnode != null)
		{
			foreach(XmlNode childnode in xnode)
			{
				if(childnode.Name == "musicOnTrigger")
				{
					childnode.InnerText = _musicOnTrigger.ToString();
				}
				if (childnode.Name == "soundsOnTrigger")
				{
					childnode.InnerText = _soundsOnTrigger.ToString();
				}
			}
			document.Save(pathToXml);
		}
	}

	private static void createXml()
	{
		XmlDocument document = new XmlDocument();

		XmlTextWriter textWritter = new XmlTextWriter(pathToXml, Encoding.UTF8);
		textWritter.WriteStartDocument();
		textWritter.WriteStartElement("userData");
		textWritter.WriteEndElement();
		textWritter.Close();
		Debug.Log("Xml created");
		
		document.Load(pathToXml);
		
		XmlNode element = document.CreateElement("dataType");
		document.DocumentElement.AppendChild(element);
		
		XmlAttribute attribute = document.CreateAttribute("type");
		attribute.Value = "soundSettings";
		element.Attributes.Append(attribute);
		
		XmlNode musicOnTriggerElement = document.CreateElement("musicOnTrigger");
		musicOnTriggerElement.InnerText = "true";
		element.AppendChild(musicOnTriggerElement);
		
		XmlNode soundsOnTriggerElement = document.CreateElement("soundsOnTrigger");
		soundsOnTriggerElement.InnerText = "true";
		element.AppendChild(soundsOnTriggerElement);
		
		document.Save(pathToXml);
		Debug.Log("Xml saved");
	}
}
