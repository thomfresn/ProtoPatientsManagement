using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatientsMgmtModel;
using PatientsMgmtModel.XMLExport;

namespace PatientsMgntModelUnitTests
{
    [TestClass]
    public class ExamsXMLExporterUnitTests
    {
        [TestMethod]
        public void TestExamIsExportedAsXMLWithNoException()
        {
            const string filePath = @"C:\Temp\exams.xml";
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            Assert.IsFalse(File.Exists(filePath));

            var exams = new []
            {
                new Exam(new Patient("Thomas Fresneau"), new Physician("Yves Dupont"), new Report("HCC diagnosed"), new DateTime(2017,10,16)),
                new Exam(new Patient("Thomas Fresneau"), new Physician("Pierre Dupont"), new Report("Healthy patient"), new DateTime(2014,07,4)),
                new Exam(new Patient("Pierre-Paul Jacques"), new Physician("Bob Maurane"), new Report("Cyrhose"), new DateTime(2016,06,06))
            };

            ExamsXMLExporter exporter = new ExamsXMLExporter();
            exporter.Export(filePath, exams);

            Assert.IsTrue(File.Exists(filePath));
        }
    }
}
