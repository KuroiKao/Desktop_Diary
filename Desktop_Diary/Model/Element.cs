using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_Diary.Model
{
    class Element : IEquatable<Element>
    {
        public string Header { get; set; }
        public string Description { get; set; }
        public DateTime Datecompl { get; set; }
        public DateTime Datecreat { get; set; }
        public bool Equals(Element other)
        {
            if (other is null)
                return false;

            return this.Header == other.Header && this.Description == other.Description && this.Datecompl == other.Datecompl;
        }
        public override bool Equals(object obj) => Equals(obj as Element);
        public override int GetHashCode() => (this.Header + this.Description + this.Datecompl + this.Datecreat).GetHashCode();
    }
}