using System.Xml;
using Verse;

namespace RailsAndRoadsOfTheRim;

public class RotR_cost
{
    public int count;
    public string name;

    public void LoadDataFromXmlCustom(XmlNode xmlRoot)
    {
        if (xmlRoot.ChildNodes.Count != 1)
        {
            Log.Error($"Misconfigured RotR_cost: {xmlRoot.OuterXml}");
            return;
        }

        name = xmlRoot.Name;
        count = (int)ParseHelper.FromString(xmlRoot.FirstChild.Value, typeof(int));
    }
}