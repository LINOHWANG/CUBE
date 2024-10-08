namespace SDCafeOffice.Views
{
    public class UserComboboxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }
 /*       public UserComboboxItem()
        {



        }*/
        public override string ToString()
        {
            return Text;
        }

    }
}