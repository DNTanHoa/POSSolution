using System;
using System.Collections.Generic;
using System.Text;

namespace POSSolution.Application.Models
{
    public class Table
    {
        public int tableId { get; set; }

        public string tableName { get; set; }

        public string tableCode { get; set; }

        public string status { get; set; }

        public int currentPeople { get; set; }

        public Region region { get; set; }

        public string createUser { get; set; }

        public DateTime? createDate { get; set; }

        public DateTime? updateDate { get; set; }
    }
}
