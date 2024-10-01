namespace WebApplication1.Models
{
    public class ProductSampleData
    {
        List<Product> products;
       
        public ProductSampleData()
        {
            products = new List<Product>();

            products.Add(
                    new Product {Id=1,Name ="Killua1",Price=100001,Image= "photo_2024-03-22_00-08-16.jpg",Description="Killua1" }
                    ); 
            products.Add(
                    new Product {Id=2,Name ="Killua2",Price=100001,Image= "159554251690766216.jpg", Description="Killua2" }
                    );
            products.Add(
                    new Product {Id=3,Name ="Killua3",Price=100001,Image= "photo_2023-07-24_13-15-13.jpg", Description="Killua3" }
                    );
            products.Add(
                    new Product {Id=4,Name ="Killua4",Price=100001,Image= "YEkN_h7M_400x400.jpg", Description="Killua4" }
                    );
        }

        public List<Product> GetAll() {  return products; }

        public Product GetProductById(int id) { 

        return products.FirstOrDefault(x=>x.Id==id);    
        
        }


    }
}
