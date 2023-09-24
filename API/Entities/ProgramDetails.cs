using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class ProgramDetails : BaseEntity
    {
        public string ProgramTitle { get; set; }

        public string Summary { get; set; }

        public string Description { get; set; }

        public string KeySkills { get; set; }

        public string Benefits { get; set; }

        public string ApplicationCriteria { get; set; }

        public AdditionalProgramInformation AdditionalProgramInformation { get; set; }
    }

    public class AdditionalProgramInformation
    {
        public ProgramType ProgramType { get; set; }

        public DateTime ProgramStart { get; set; }

        public DateTime ApplicationOpen { get; set; }

        public DateTime ApplicationClose { get; set; }

        public string Duration { get; set; }

        public string ProgramLocation { get; set; }

        public bool FullyRemote { get; set; }

        public MinQualifications MinQualifications { get; set; }

        public int MaxNumberOfApplications { get; set; }
    }

    public enum ProgramType
    {
        FullTime,
        PartTime
    }

    public enum MinQualifications
    {
        HighSchool,
        Graduation
    }
}