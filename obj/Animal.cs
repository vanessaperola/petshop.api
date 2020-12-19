
namespace petshop.api.obj
{
    public class Animal
    {
        public string Id{get; set;} = Guid.NewGuid().ToString();
        public string Nome {get; set;}
        public int Idade {get; set;}
        public string Cor {get; set;}
    }
}