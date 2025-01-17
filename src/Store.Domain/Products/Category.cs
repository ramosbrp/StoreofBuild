namespace Store.Domain.Products
{
    public class Category
    {
        //Encapsular com private
        public int Id { get; private set; }
        public string Name { get; private set; }

        public Category(string name)
        {
            //Valida��o da classe
            ValidateNameAndSetName(name);
        }
        public void Update(string name)
        {
            ValidateNameAndSetName(name);
        }

        private void ValidateNameAndSetName(string name)
        {
            DomainException.When(string.IsNullOrEmpty(name), "Name is required");

            Name = name;
        }

    }
    
}