using System.Xml.Linq;

public interface IEventListener<TData>
{ 
    void OnEventRaised(TData data);
}

public interface IEventListener
{
    void OnEventRaised();
}
