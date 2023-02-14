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
    public EnergyBill GetRates(float Consumption){
        float basicTariff = (5*12f) + (Consumption * .22f);
        
        //calculation for Packaged tariff
        float PackagedTariff;
        if(Consumption <= 4000) PackagedTariff = 800;
        else
        {
            float extraConsumption = Consumption - 4000;
            PackagedTariff = 800f + (extraConsumption * .30f);
        }

        return new EnergyBill{ Consumption = Consumption,  basicTariff = basicTariff, PackagedTariff = PackagedTariff };
    }
}