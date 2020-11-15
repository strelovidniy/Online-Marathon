namespace Sprint_04.Task_03
{
    public class ColouredDocument : IColoured, IDocument
    {
        public static string defaultText = "Lorem ipsum";

        public int Pages
        {
            get => 0;
            set => Pages = value;
        }

        public void AddPages(int pages) 
            => this.Pages += pages;

        public void Rename(string name) 
            => this.Name = name;

        public string Name { get; set; }

        public ColourEnum Colour { get; set; }

        public ColouredDocument(ColourEnum colour) 
            => this.Colour = colour;

        public ColouredDocument(string name) 
            => this.Name = name;

        public ColouredDocument() 
            => this.Colour = ColourEnum.Red;
    }
}
