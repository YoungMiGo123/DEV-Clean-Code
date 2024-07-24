using System.Runtime.Serialization;

namespace Clean_Code_Services.Features.Instructor.Enums
{
    public enum CurriculItemType
    {

            [EnumMember]
            Lecture = 1,

            [EnumMember]
            Quiz = 2,

            [EnumMember]
            CodingExercise = 3,

            [EnumMember]
            PracticeTest = 4,

            [EnumMember]
            Assignment = 5
  
    }
}
