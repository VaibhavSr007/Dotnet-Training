using firstapi.Models;
using Microsoft.AspNetCore.Mvc;
namespace firstapi.Repository
{

    public interface IFlight<VsFlight>
    {
        List<VsFlight> GetAllFlights();
        void AddFlight(VsFlight f);
        void UpdateFlight(int id, VsFlight f);
        VsFlight GetFlightById(int id);
        List<VsFlight> GetFlightsBySrcDest(string s);
        void DeleteFlight(int id);
    }
}