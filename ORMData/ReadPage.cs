namespace ORMData
{
    public class ReadOrder
    {
        public string Column { get; set; }
        public bool Ascending { get; set; }
    }

    public class ReadPage
    {
        public int Take { get; set; }
        public int Skip { get; set; }
        public ReadOrder[] OrderBy { get; set; }
    }
}