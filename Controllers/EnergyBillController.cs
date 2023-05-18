using Microsoft.AspNetCore.Mvc;

namespace EnergyBill.Controllers;

[ApiController]
[Route("[controller]")]
public class EnergyBillController : ControllerBase
{

    [HttpGet]
    public string Get(){
        return "success";
    }

    [HttpGet]
    [Route("GetRates/{Consumption}")]
    public EnergyBillDTO GetRates(float Consumption){

        if (Consumption < 0)
        {
            return new EnergyBillDTO{ Status = "error", Data = null };
        }
        else
        {
            //calculation for basic tariff
            float basicTariff = (5*12f) + (Consumption * .22f);
            
            //calculation for Packaged tariff
            float PackagedTariff;
            if(Consumption <= 4000) PackagedTariff = 800;
            else
            {
                float extraConsumption = Consumption - 4000;
                PackagedTariff = 800f + (extraConsumption * .30f);
            }

            return new EnergyBillDTO{ Status = "success", Data = new EnergyBill { Consumption = Consumption,  basicTariff = basicTariff, PackagedTariff = PackagedTariff } };
        }
    }
}