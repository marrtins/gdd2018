namespace FrbaHotel.AbmHotel
{
    internal class Filter
    {
        public string PropertyName { get; set; }
        public string PropertyValue { get; set; }
        public string FilterType { get; set; }

        public Filter(string propertyName, string propertyValue, string filterType)
        {
            PropertyName = propertyName;
            PropertyValue = propertyValue;
            FilterType = filterType;
        }
    }
}