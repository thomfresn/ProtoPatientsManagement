using System;
using System.Xml.Schema;

namespace PatientsMgmtModel.XMLExport
{
    public class XMLExportException : Exception
    {
        public XMLExportException(XmlSchemaException eException) : base("Validation failed during export to XML file", eException)
        {
        }
    }
}