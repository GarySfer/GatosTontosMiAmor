namespace DefaultNamespace.ItemClasses
{
    public class Item
    {
        // change all private to protected
        private string _name;
        private string _description;
        private int _value;

        public Item(string name, string description, int value)
        {
            _name = name;
            _description = description;
            _value = value;
        }
    }
}