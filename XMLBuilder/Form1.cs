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
        public Form1()
        {
            InitializeComponent();
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
            Output.Text = Thisshit();
        }


        public string Thisshit()
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
