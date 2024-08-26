namespace Portfolio.Core.Models
{
    public class PortfolioModel
    {
        public static int MAX_NAME_LENGTH = 96;
        public static int MAX_DESCRIPTION_LENGTH = 256;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Description { get; set; }

        private PortfolioModel(int id, string name, string surname, string description)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Description = description;
        }

        public static (PortfolioModel portfolio, string errorMessage) Create(int id, string name, string surname, string description)
        {
            string errorMessage = string.Empty;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(surname))
            {
                errorMessage = $"Name or surname can not be empty";
            }
            else if (name.Length > MAX_NAME_LENGTH || surname.Length > MAX_NAME_LENGTH)
            {
                errorMessage = $"Max length of {nameof(Name)}/{nameof(Surname)} is {MAX_NAME_LENGTH}";
            }
            else if (description.Length > MAX_DESCRIPTION_LENGTH)
            {
                errorMessage = $"Max length of {nameof(Description)} is {MAX_DESCRIPTION_LENGTH}";
            }

            var result = new PortfolioModel(id, name, surname, description);

            return (result, errorMessage);
        }
    }
}
