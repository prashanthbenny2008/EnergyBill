namespace EnergyBill;

public class EnergyBill
{
    public float Consumption { get; set; }
    public float basicTariff { get; set; }
    public float PackagedTariff { get; set; }
}

public class EnergyBillDTO
{
    public string? Status { get; set; }
    public EnergyBill? Data { get; set; }
}