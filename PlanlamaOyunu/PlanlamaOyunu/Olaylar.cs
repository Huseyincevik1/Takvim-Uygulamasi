using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanlamaOyunu
{
    public class Olaylar
    {
        public int olayId { get; set; }
        public DateTime islemzamani { get; set; }
        public TimeSpan baslangicsaat { get; set; }
        public TimeSpan bitissaat { get; set; }
        public string olaytipi { get; set; }
        public string olayaciklama { get; set; }
        public int kisiId { get; set; }
        public int uyaribildirimi { get; set; }


    }
}
