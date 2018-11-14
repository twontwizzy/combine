using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Combine
{
    public class Combine
    {
        [PrimaryKey, AutoIncrement]
        public int CombineID { get; set; }

        public string CombineName { get; set; }

        public DateTime CombineDate { get; set; }
    }

    public class Participants
    {
        public int ParticipantID { get; set; }
        public string ParticipantFirstName { get; set; }
        public string ParticipantsLastName { get; set; }
    }

    public class CombineTest
    {
        public int CombineTestID { get; set; }
        public string Test { get; set; }
        public string Result { get; set; }
        public string Measurement { get; set; }
    }
}
