namespace Team.Utils
{
    public interface IWritable
    {
        void WriteBinary(string filename);
        void ReadBinary(string filename);
        void WriteXml(string filename);
        void ReadXml(string filename);
    }
}
