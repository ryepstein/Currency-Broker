using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Assignment3
{
    class TradeBroker
    {
        public float ReadXML()
        {
            bool correctSymbol = false;
            bool isBid = false;
            String URLString = "http://rates.fxcm.com/RatesXML";
            XmlTextReader reader = new XmlTextReader(URLString);

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // Begin element
                        if (reader.Name == "Rate")
                        {
                            while (reader.MoveToNextAttribute())
                            {
                                if (reader.Value == Program.rateSymbol)
                                {
                                    correctSymbol = true;   // Symbol matches user-defined pair
                                }
                                else
                                {
                                    correctSymbol = false;  // Symbol does not match user-defined pair
                                }
                            }
                        }
                        if (reader.Name == "Bid")
                        {
                            isBid = true;   // Element is Bid
                        }
                        else
                        {
                            isBid = false;  // Element is not Bid
                        }
                        break;
                    case XmlNodeType.Text: // Text within element
                        if (isBid && correctSymbol)
                        {
                            return float.Parse(reader.Value);   // Return bid value
                        }
                        break;
                    case XmlNodeType.EndElement: // End element
                        break;
                }
            }
            return 0;   // Return 0 if user-defined pair is not found
        }
    }
}
