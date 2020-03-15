using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace XMLParser
{
    public class DCP
    {
        public string tagNumber;
        public string result;
        public DCP(string tag, string rslt)
        {
            tagNumber = tag;
            result = rslt;
        }
    }

    public partial class Form1 : Form
    {
        public List<DCP> dcps;
        public string xml;
        private List<string> errorCode;
        private List<string> errorMessage;
        public Form1()
        {
            InitializeComponent();
            dcps = new List<DCP>();
            errorCode = new List<string>();
            errorMessage = new List<string>();
        }

        private void Parsebtn_Click(object sender, EventArgs e)
        {
            string rawData = Raw.Text;
            if (rawData.Trim() == "")
            {
                return;
            }
            try
            {
                XDocument doc = XDocument.Parse(rawData);
                XNamespace ns = "http://mes.health.ge.com";
                XNamespace dcpns = "http://saveDCP.mes.health.ge.com";
                IEnumerable<XElement> responses = doc.Descendants(dcpns + "OutputDCP");

                foreach (XElement response in responses)
                {
                    string str1 = response.Descendants(dcpns + "dcpResult").Single().Value;
                    string str2 = response.Descendants(dcpns + "dctTag").Single().Value;
                    dcps.Add(new DCP(str2, str1));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Parse failed: " + ex.Message.ToString());
            }
            /*
             <dCPResults xmlns="http://saveDCP.mes.health.ge.com">
                    <OutputDCP>
                        <dcpResult>ACCEPT</dcpResult>
                        <dctTag>TAG003</dctTag>
                    </OutputDCP>
                    <OutputDCP>
                        <dcpResult>ACCEPT</dcpResult>
                        <dctTag>TAG002</dctTag>
                    </OutputDCP>
                    <OutputDCP>
                        <dcpResult>ACCEPT</dcpResult>
                        <dctTag>TAG001</dctTag>
                    </OutputDCP>
                </dCPResults>
             */
        }


        public void fillxml(out string XML)
        {
            XML = @"<soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">
    <soap:Body>
         <ns1:saveDCPResponse xmlns:ns1=""http://mes.health.ge.com"">
              <ns1:out>
                   <consumedPartsResults xmlns =""http://saveDCP.mes.health.ge.com""xsi:nil=""true""/>
                       <dCPResults xmlns=""http://saveDCP.mes.health.ge.com"">
                            <OutputDCP>
                                <dcpResult>ACCEPT</dcpResult>
                                <dctTag>TAG003</dctTag>
                            </OutputDCP>
                            <OutputDCP>
                                <dcpResult>ACCEPT</dcpResult>
                                <dctTag>TAG002</dctTag>
                            </OutputDCP>
                            <OutputDCP>
                                <dcpResult>ACCEPT</dcpResult>
                                <dctTag>TAG001</dctTag>
                            </OutputDCP>
                        </dCPResults>
                        <errorCode xmlns=""http://saveDCP.mes.health.ge.com"">500</errorCode>
                         <errorMessage xmlns=""http://saveDCP.mes.health.ge.com"">DCP saved without complete </ errorMessage >
                          </ns1:out>
                       </ns1:saveDCPResponse>
                    </soap:Body>
                 </soap:Envelope>";
        }
    }
}
/* Random examples
 
string xml = @"<messages> 
                  <message subclass=""a"" context=""d"" key=""g""/> 
                  <message subclass=""b"" context=""e"" key=""h""/> 
                  <message subclass=""c"" context=""f"" key=""i""/> 
               </messages>";

var messagesElement = XElement.Parse(xml);
var messagesList = (from message in messagesElement.Elements("message")
                   select new 
                    {
                        Subclass = message.Attribute("subclass").Value,
                        Context = message.Attribute("context").Value,
                        Key = message.Attribute("key").Value
                    }).ToList();     
     
     <soap:Envelope xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
    <soap:Body>
        <ns1:saveDCPResponse xmlns:ns1="http://mes.health.ge.com">
            <ns1:out>
                <consumedPartsResults xmlns="http://saveDCP.mes.health.ge.com" xsi:nil="true"/>
                <dCPResults xmlns="http://saveDCP.mes.health.ge.com">
                    <OutputDCP>
                        <dcpResult>INVALID DCP IMPORT TAG</dcpResult>
                        <dctTag>TAG009</dctTag>
                    </OutputDCP>
                </dCPResults>
                <errorCode xmlns="http://saveDCP.mes.health.ge.com">-504</errorCode>
                <errorMessage xmlns="http://saveDCP.mes.health.ge.com">Cannot save one or more DCP lines because of invalid DCP Import Tag</errorMessage>
            </ns1:out>
        </ns1:saveDCPResponse>
    </soap:Body>
</soap:Envelope>

    <soap:Envelope xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
    <soap:Body>
        <ns1:saveDCPResponse xmlns:ns1="http://mes.health.ge.com">
            <ns1:out>
                <consumedPartsResults xmlns="http://saveDCP.mes.health.ge.com" xsi:nil="true"/>
                <dCPResults xmlns="http://saveDCP.mes.health.ge.com">
                    <OutputDCP>
                        <dcpResult>ACCEPT</dcpResult>
                        <dctTag>TAG002</dctTag>
                    </OutputDCP>
                </dCPResults>
                <errorCode xmlns="http://saveDCP.mes.health.ge.com">500</errorCode>
                <errorMessage xmlns="http://saveDCP.mes.health.ge.com">DCP saved without complete</errorMessage>
            </ns1:out>
        </ns1:saveDCPResponse>
    </soap:Body>
</soap:Envelope>
*/

/************************************** MESSAGE & RESPONSE **************************************
    
    * 
    * MESSAGE- 
    * 
<soapenv:Envelope xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/" xmlns:mes="http://mes.health.ge.com" xmlns:sav="http://saveDCP.mes.health.ge.com">
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

    * RESPONSE - 
    * 
<soap:Envelope xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
    <soap:Body>
        <ns1:saveDCPResponse xmlns:ns1="http://mes.health.ge.com">
            <ns1:out>
                <consumedPartsResults xmlns="http://saveDCP.mes.health.ge.com" xsi:nil="true"/>
                <dCPResults xmlns="http://saveDCP.mes.health.ge.com">
                    <OutputDCP>
                        <dcpResult>ACCEPT</dcpResult>
                        <dctTag>TAG003</dctTag>
                    </OutputDCP>
                    <OutputDCP>
                        <dcpResult>ACCEPT</dcpResult>
                        <dctTag>TAG002</dctTag>
                    </OutputDCP>
                    <OutputDCP>
                        <dcpResult>ACCEPT</dcpResult>
                        <dctTag>TAG001</dctTag>
                    </OutputDCP>
                </dCPResults>
                <errorCode xmlns="http://saveDCP.mes.health.ge.com">500</errorCode>
                <errorMessage xmlns="http://saveDCP.mes.health.ge.com">DCP saved without complete</errorMessage>
            </ns1:out>
        </ns1:saveDCPResponse>
    </soap:Body>
</soap:Envelope>





    ************************** WORKS FOR ERROR CODE ************************
    *                 XDocument doc = XDocument.Parse(rawData);
                XNamespace ns = "http://mes.health.ge.com";
                XNamespace dcpns = "http://saveDCP.mes.health.ge.com";
                IEnumerable<XElement> responses = doc.Descendants(dcpns + "errorCode");
                
                foreach (XElement response in responses)
                {
                    if (Int32.TryParse(response.Value, out int i))
                    { 
                        if (i == 500 || i == 0)
                        {
                            // Success
                            // return
                            errorCode.Add(response.Value);
                        }
                        else
                        {
                            // Error status returned
                        }
                    }
                    // Error occured

                }


*/
