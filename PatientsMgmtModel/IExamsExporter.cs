using System.Collections.Generic;

namespace PatientsMgmtModel
{
    public interface IExamsExporter
    {
        void Export(string filePath, IEnumerable<Exam> exams); 
    }
}