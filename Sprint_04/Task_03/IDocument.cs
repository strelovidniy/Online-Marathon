namespace Sprint_04.Task_03
{
    public interface IDocument
    {
        public static string defaultText = "Lorem ipsum";

        public string Name { get; set; }

        public int Pages 
        { 
            get => 0;
            set => Pages = value;
        }

        public void AddPages(int pages) 
            => this.Pages += pages;

        public void Rename(string name) 
            => this.Name = name;
    }
}
