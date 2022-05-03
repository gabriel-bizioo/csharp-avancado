namespace DTO;
public class StoreDTO
{
    public string name;
    public string cnpj;
    public OwnerDTO owner;  
    public List<PurchaseDTO> purchases = new List<PurchaseDTO>();
}
