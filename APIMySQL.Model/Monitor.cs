using System;
using System.Collections.Generic;
using System.Text;

namespace APIMySQL.Model
{
    public class Monitor
    {
        public int Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string Year { get; set; }

        public float Inches { get; set; }

        public string Color { get; set; }
    }
}
