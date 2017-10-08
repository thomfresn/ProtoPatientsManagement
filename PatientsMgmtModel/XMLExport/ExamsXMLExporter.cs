using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace PatientsMgmtModel.XMLExport
{
    public class ExamsXMLExporter : IExamsExporter
    {
        public void Export(string filePath, IEnumerable<Exam> exams)
        {
            XmlSchemaSet schemaSet = new XmlSchemaSet();
            schemaSet.Add("", XmlReader.Create(new StringReader(Properties.Resources.PatientsSchema)));
            
            XElement rootElement = new XElement("exams");
            foreach (Exam exam in exams)
            {
                XAttribute dateAttribute = new XAttribute("date", exam.Date);

                XElement patientElement = new XElement("patient");
                patientElement.Add(new XElement("name", exam.Patient.Name));

                XElement physicianElement = new XElement("physician");
                physicianElement.Add(new XElement("name", exam.Physician.Name));

                XElement reportElement = new XElement("report");
                reportElement.Add(new XElement("report", exam.Report));


                XElement examElement = new XElement("exam");
                examElement.Add(dateAttribute);
                examElement.Add(patientElement);
                examElement.Add(physicianElement);
                examElement.Add(reportElement);
                rootElement.Add(examElement);
            }
            XDocument document = new XDocument(rootElement);
            document.Validate(schemaSet,(o,e) => throw new XMLExportException(e.Exception));
            document.Save(filePath);
        }
    }
}
