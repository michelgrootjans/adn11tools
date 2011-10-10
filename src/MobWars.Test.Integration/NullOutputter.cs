using System.IO;
using System.Text;

namespace MobWars.Test.Integration
{
    internal class NullOutputter : TextWriter
    {
        public override Encoding Encoding
        {
            get { return Encoding.ASCII; }
        }
    }
}