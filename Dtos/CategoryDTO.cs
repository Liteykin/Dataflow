namespace Dataflow.Dtos
{
    public class CategoryDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class GetCategoryDTO : CategoryDTO
    {
        public int Id { get; set; }
    }

    public class CreateCategoryDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class UpdateCategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}