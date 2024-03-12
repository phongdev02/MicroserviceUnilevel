namespace ReadFile.Models.Dto
{
    public class TypeFileDto
    {
        public Boolean _typeFile {  get; set; } 

        public enum typeFile
        {
            xlsx,
            csv
        }
    }
}
