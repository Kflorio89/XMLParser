using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace XMLBuilder
{
    public partial class Form1 : Form
    {
        public List<string> itemNumbers = new List<string>();

        public Form1()
        {
            InitializeComponent();

            /*string dtm = "23-Sep-2020 22:00 (UTC)";
            string[] doms = SplitDateTime(dtm);*/
            Input.Text = CreateStartUnitMessage();
        }

        private string[] SplitDateTime(string DOM)
        {
            // Split this shit: 23-Sep-2020 22:00 (UTC)
            string[] rslts = new string[2];
            try
            {
                string[] cut1 = DOM.Split(' ');
                string[] cut2 = cut1[0].Split('-');
                if (cut2.Length > 2)
                {
                    rslts[1] = cut2[2];
                    switch (cut2[1].ToLower())
                    {
                        case "jan":
                            rslts[0] = "1";
                            break;
                        case "feb":
                            rslts[0] = "2";
                            break;
                        case "mar":
                            rslts[0] = "3";
                            break;
                        case "apr":
                            rslts[0] = "4";
                            break;
                        case "may":
                            rslts[0] = "5";
                            break;
                        case "jun":
                            rslts[0] = "6";
                            break;
                        case "jul":
                            rslts[0] = "7";
                            break;
                        case "aug":
                            rslts[0] = "8";
                            break;
                        case "sep":
                            rslts[0] = "9";
                            break;
                        case "oct":
                            rslts[0] = "10";
                            break;
                        case "nov":
                            rslts[0] = "11";
                            break;
                        case "dec":
                            rslts[0] = "12";
                            break;
                        default:
                            rslts[0] = "N/A";
                            break;
                    }
                }
                else
                {
                    rslts[0] = "N/A";
                    rslts[1] = "N/A";
                }
            }
            catch (Exception ex)
            {
                rslts[0] = "N/A";
                rslts[1] = "N/A";
            }
            return rslts;
        }

        public string CreateGetUnitInfoMessage()
        {
            string password = "Password";
            string serialNumber = "SerialNumber";
            string userID = "UserID";

            StringBuilder xml = new StringBuilder();
            xml.Append(@"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:mes=""http://mes.health.ge.com"" xmlns:get=""http://getUnitInfo.mes.health.ge.com"">");
            xml.Append("<soapenv:Header/>");
            xml.Append("<soapenv:Body>");
            xml.Append("<mes:getUnitInfo>");
            xml.Append("<mes:in0>");
            xml.Append($"<get:password>{password}</get:password>");
            xml.Append($"<get:serialNumber>{serialNumber}</get:serialNumber>");
            xml.Append($"<get:userID>{userID}</get:userID>");
            xml.Append("</mes:in0>");
            xml.Append("</mes:getUnitInfo>");
            xml.Append("</soapenv:Body>");
            xml.Append("</soapenv:Envelope>");

            return xml.ToString();
        }

        public string CreateStartUnitMessage()
        {
            StringBuilder xml = new StringBuilder();

            // Data used in message
            string operationName = "USA_ALL_Init Packet/ Decon";
            string partName = "SVC 2418093";
            string partRevision = "01";
            string password = "D1FaLMLucoDS.CLN1WA3GM6UCLN1WA3GM6UCLN1WA3GM6U";
            string routeName = "USA_ALL_Repair_Ops";
            string serialNumber = "51160-301495090";
            string userID = "202123456";
            string workCenter = "test";

            // Start the frame
            xml.Append(@"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:mes=""http://mes.health.ge.com"" xmlns:get=""http://getUnitInfo.mes.health.ge.com"">");
            xml.Append("<soapenv:Header/>");
            xml.Append("<soapenv:Body>");
            xml.Append("<mes:getUnitInfo>");
            xml.Append("<mes:in0>");

            // The guts
            xml.Append($"<star:operationName>{operationName}</star:operationName>");
            xml.Append($"<star:partName>{partName}</star:partName>");
            xml.Append($"<star:partRevision>{partRevision}</star:partRevision>");
            xml.Append($"<star:password>{password}</star:password>");
            xml.Append($"<star:routeName>{routeName}</star:routeName>");
            xml.Append($"<star:serialNumber>{serialNumber}</star:serialNumber>");
            xml.Append($"<star:userID>{userID}</star:userID>");
            xml.Append($"<star:workCenter>{workCenter}</star:workCenter>");

            // End the frame
            xml.Append("</mes:in0>");
            xml.Append("</mes:getUnitInfo>");
            xml.Append("</soapenv:Body>");
            xml.Append("</soapenv:Envelope>");

            return xml.ToString();
        }

        private void Convert_Click(object sender, EventArgs e)
        {
            /*string xmldoc = "N/A";
            using (var sw = new StringWriter())
            {
                XNamespace schEnvelope = "http://schemas.xmlsoap.org/soap/envelope";
                XNamespace mesEnvelope = "http://mes.health.ge.com";
                XNamespace savEnvelope = "http://saveDCP.mes.health.ge.com";

                XNamespace soapenv = "soapenv";

                var doc = new XDocument(
                    new XElement(schEnvelope + "Envelope",
                        new XAttribute(XNamespace.Xmlns + "soapenv", schEnvelope),
                        new XAttribute(XNamespace.Xmlns + "mes", mesEnvelope),
                        new XAttribute(XNamespace.Xmlns + "sav", savEnvelope),
                        new XElement(schEnvelope + "Header"),
                        new XElement(schEnvelope + "Body",
                            new XElement(mesEnvelope + "saveDCP",
                            new XElement(mesEnvelope + "in0",
                            new XElement(savEnvelope + "dcps",
                            new XElement(savEnvelope + "DCP"
                                ))))))) ;

                doc.Save(sw);
                xmldoc = sw.ToString();
            }*/
            MoreShit();
        }

        /// <summary>
        /// For getUnitInfo
        /// </summary>
        public void MoreShit()
        {
            string input = Input.Text.Trim();

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(input);
                XmlNodeList propertyNames = doc.GetElementsByTagName("propertyName");
                XmlNodeList propertyValues = doc.GetElementsByTagName("propertyValue");
                XmlNodeList currOp = doc.GetElementsByTagName("currentOperation");
                XmlNodeList rev = doc.GetElementsByTagName("partRevision");
                XmlNodeList preOp = doc.GetElementsByTagName("previousOperation");
                XmlNodeList postOp = doc.GetElementsByTagName("nextOperation");
                XmlNodeList state = doc.GetElementsByTagName("state");

                List<string> data = new List<string>();

                for (int i = 0; i < propertyNames.Count; ++i)
                { 
                    switch (propertyNames[i].InnerText.ToLower())
                    {
                        case "partnumber":
                            data.Add("PartNumber: " + propertyValues[i].InnerText);
                            break;
                        case "partrevision":
                            data.Add("PartRevision: " + propertyValues[i].InnerText);
                            break;
                        case "serialnumber":
                            data.Add("SerialNumber: " + propertyValues[i].InnerText);
                            break;
                        case "status":
                            data.Add("Status: " + propertyValues[i].InnerText);
                            break;
                        case "currentroute":
                            data.Add("CurrentRoute: " + propertyValues[i].InnerText);
                            break;
                        case "dateofmanufacturing":
                            data.Add("DOM: " + propertyValues[i].InnerText);
                            break;
                        case "mdpartnumberrev":
                            data.Add("PN/Rev: " + propertyValues[i].InnerText);
                            break;
                    }
                }

                string currentOperation = currOp[0].InnerText;
                string previousOperation = preOp[0].InnerText;
                string nextOperation = postOp[0].InnerText;
                string currState = state[0].InnerText;

                Output.Text = "Data parsed: " + Environment.NewLine;
                foreach(string strr in data)
                {
                    Output.Text += strr + Environment.NewLine;
                }


                int it = data.Count;
                /*
                XElement str = XElement.Parse(input);
                foreach (XElement XE in str.Elements("properties"))
                {
                    string number = XE.Descendants("propertyName").FirstOrDefault()?.Value;
                    string xmltag = XE.Descendants("propertyValue").FirstOrDefault()?.Value;
                    
                }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
            }
        }


        public void ThatShit()
        {
            //string input = Input.Text.Trim().Replace("&", "&amp;");
            string input = Input.Text.Trim();
            List<string> activationList = new List<string>();

            while (true)
            {
                int startIndex = input.IndexOf("<ACTIVATION_CODE>");
                if (startIndex < 0)
                {
                    break;
                }
                int endIndex = input.IndexOf("</ACTIVATION_CODE>");
                int length = endIndex - (startIndex + 17);
                activationList.Add(input.Substring(startIndex + 17, length));
                input = input.Remove(startIndex, length + 35);
            }

            try
            {
                XElement str = XElement.Parse(input);
                // find specific tag
                foreach (XElement XE in str.Elements("ITEM_DETAILS"))
                {
                    string number = XE.Descendants("ITEM_NUMBER").FirstOrDefault()?.Value;
                    string xmltag = XE.Descendants("XML_TAG").FirstOrDefault()?.Value;
                    itemNumbers.Add(number);
                }
                Output.Text += "Item Numbers found:" + Environment.NewLine;
                foreach (string item in itemNumbers)
                {
                    Output.Text += item + Environment.NewLine;
                }
                Output.Text += "End of item numbers found." + Environment.NewLine + Environment.NewLine;
                Output.Text += "Start of activation code list." + Environment.NewLine;
                foreach (string act in activationList)
                {
                    Output.Text += act + Environment.NewLine;
                }
                Output.Text += "End of activation code list." + Environment.NewLine;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception thrown when parsing. Message: " + ex.Message.ToString());
            }
        }

        public string ThisShit()
        {
            StringBuilder xml = new StringBuilder();
            IDictionary<string, string> dict = new Dictionary<string, string>();

            for (int i = 1; i <= 4; ++i)
            {
                dict.Add($"TAG00{i}", $"{i}");
            }


            //Frame of message
            xml.Append(@"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:mes=""http://mes.health.ge.com"" xmlns:sav=""http://saveDCP.mes.health.ge.com"">");
            xml.Append("<soapenv:Header/>");
            xml.Append("<soapenv:Body>");
            xml.Append("<mes:saveDCP>");
            xml.Append("<mes:in0>");
            xml.Append("<sav:completeOperation>0</sav:completeOperation>");
            xml.Append("<sav:consumedParts>");
            xml.Append("</sav:consumedParts>");
            xml.Append("<sav:dcps>");
            // Fill in dcp tags and values here
            for (int i = 0; i < dict.Count; i++)
            {
                xml.Append(CreateDCP(dict.Keys.ElementAt(i), dict[dict.Keys.ElementAt(i)]));
            }
            // End filling dcp tags and values
            xml.Append("</sav:dcps>");
            xml.Append("<sav:operationName>CTM_Gan-SubA</sav:operationName>");
            xml.Append("<sav:partNumber>5454001-170-SUBSA</sav:partNumber>");
            xml.Append("<sav:partRevision>N/A</sav:partRevision>");
            xml.Append("<sav:password>D1NPnWPE5WwnE9vatgdNzUFICLN1WA3GM6UCLN1WA3GM6U</sav:password>");
            xml.Append("<sav:reasonCode>PASS</sav:reasonCode>");
            xml.Append("<sav:routeName>CTM_Gan_SubA</sav:routeName>");
            xml.Append("<sav:serialNumber>WebTestAME001</sav:serialNumber>");
            xml.Append("<sav:userID>555333333</sav:userID>");
            xml.Append("</mes:in0>");
            xml.Append("</mes:saveDCP>");
            xml.Append("</soapenv:Body>");
            xml.Append("</soapenv:Envelope>");
            return xml.ToString();
        }

        public string CreateDCP(string tag, string value)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<sav:DCP>");
            sb.Append($"<sav:dcpImportTag>{tag}</sav:dcpImportTag>");
            sb.Append($"<sav:dcpValue>{value}</sav:dcpValue>");
            sb.Append("</sav:DCP>");
            return sb.ToString();
        }
        private string GetUnitExample()
        {
            return @"";
        }

        /*
         * 
         * <soapenv:Envelope xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/" xmlns:mes="http://mes.health.ge.com" xmlns:sav="http://saveDCP.mes.health.ge.com">
   <soapenv:Header/>
   <soapenv:Body>
      <mes:saveDCP>
         <mes:in0>
            <sav:completeOperation>0</sav:completeOperation>
            <sav:consumedParts>
            </sav:consumedParts>
            <sav:dcps>
               <sav:DCP>
                  <sav:dcpImportTag>TAG003</sav:dcpImportTag>
                  <sav:dcpValue>3</sav:dcpValue>
               </sav:DCP>
               <sav:DCP>
                  <sav:dcpImportTag>TAG002</sav:dcpImportTag>
                  <sav:dcpValue>2</sav:dcpValue>
               </sav:DCP>
               <sav:DCP>
                  <sav:dcpImportTag>TAG001</sav:dcpImportTag>
                  <sav:dcpValue>1</sav:dcpValue>
               </sav:DCP>
            </sav:dcps>
            <sav:operationName>CTM_Gan-SubA</sav:operationName>
            <sav:partNumber>5454001-170-SUBSA</sav:partNumber>
            <sav:partRevision>N/A</sav:partRevision>
            <sav:password>D1NPnWPE5WwnE9vatgdNzUFICLN1WA3GM6UCLN1WA3GM6U</sav:password>
            <sav:reasonCode>PASS</sav:reasonCode>
            <sav:routeName>CTM_Gan_SubA</sav:routeName>
            <sav:serialNumber>WebTestAME001</sav:serialNumber>
            <sav:userID>555333333</sav:userID>
         </mes:in0>
      </mes:saveDCP>
   </soapenv:Body>
</soapenv:Envelope>
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * XNamespace nsEnvelope = "http://schemas.xmlsoap.org/soap/envelope";
            XNamespace nsCuBoffAk = "CuBoffAk";

            var doc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement(nsEnvelope + "Envelope",
                    new XAttribute(nsEnvelope + "encodingStyle", "http://schemas.xmlsoap.org/encoding/"),
                    new XAttribute(XNamespace.Xmlns + "SOAP-ENV", nsEnvelope),
                    new XElement(nsEnvelope + "body",
                        new XElement(nsCuBoffAk + "MySillySoapService..doThisThing",
                            new XAttribute(XNamespace.Xmlns + "rs5", nsCuBoffAk),
                            new XComment("actual response of SOAP request here")
                            ))));

            doc.Save("../../Test.xml");
         * 
         * 
               using(var sw = new StringWriter())
               {
                   using (var xw = XmlWriter.Create(sw))
                   {
                       xw.WriteStartElement("Foo");
                   xw.WriteAttributeString("Bar", "Some & value");
                   xw.WriteElementString("Nested", "data");
                   xw.WriteEndElement();
                   }
                   xmldoc = sw.ToString();
               }

                */

    }
}
