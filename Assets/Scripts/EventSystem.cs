using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("EventSystem")]
public class EventSystem{

    [XmlArray("Events"),XmlArrayItem("Event")]
    private EventContainer eventContainer;
    private Event currentEvent;
    private Event baseEvent;
    private float eventChance;
    

    public EventSystem(float _eventChance)
    {
        eventChance = _eventChance;
        eventContainer = new EventContainer();
        eventContainer = eventContainer.Load(Application.dataPath + "/Events.xml");
        baseEvent = new Event();
        //eventContainer.debugTabEvent();

    }

    private Event GenerateEvent()
    {
        int x = Random.Range(0, eventContainer.events.Count);
        return eventContainer.events[x];

    }

    public void newTurn()
    {
        if (Random.Range(0.0f, 1.0f) < eventChance)
        {
            currentEvent = GenerateEvent();

        }
        else
            currentEvent = baseEvent;

    }

    public Event GetCurrentEvent()
    {
        return currentEvent;

    }

}

[XmlRoot("EventContainer")]
public class EventContainer
{
    [XmlArray("Events")]
    [XmlArrayItem("Event")]
    public List<Event> events = new List<Event>();

    public EventContainer Load(string path)
    {
        var serializer = new XmlSerializer(typeof(EventContainer));
        using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            return serializer.Deserialize(stream) as EventContainer;
        }
    }

    public void debugTabEvent()
    {
        if (events.Count == 0)
            Debug.LogWarning("Ta liste d'event est vide crisse de fife");
        else
        {
            foreach (Event x in events)
            {
                Debug.Log(x.id + " " + x.FlavorText + " " + x.teamArtEffect + " " + x.teamProgEffect + " " + x.teamSaltEffect + " " + x.teamSleepEffect);
            }
        }

    }

}

public class Event
{
    [XmlAttribute("id")]
    public int id = -1;

    public string FlavorText = "kek";
    public float teamProgEffect = 1;
    public float teamArtEffect = 1;
    public float teamSaltEffect = 1;
    public float teamSleepEffect = 1;

}
