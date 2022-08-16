using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebFrontEnd.Data;
using WebFrontEnd.Models;

namespace WebFrontEnd.ViewModels
{
    public class VehicleCargoViewModel
    {
        private readonly ApplicationDbContext db;
        public string UserId { get; private set; }
        public int SelectedVehicleToAdd { get; set; }
        public int SelectedPlateToAdd { get; set; }

        public VehicleCargoViewModel(ApplicationDbContext injectedContext, string userId)
        {
            db = injectedContext;
            UserId = userId;
        }

        public IEnumerable<UserVcVehicle> GetUserVehicles()
        {
            IEnumerable<UserVcVehicle> data = db.UserVcVehicles
                .Include(t => t.Plate)
                .ThenInclude(t => t.Vehicle)
                .Where(t => t.UserId == UserId);
            return data;
        } // method GetUsersVehicles

        public List<VcVehicle> GetAllVehicles()
        {
            return db.VcVehicles.ToList();
        } // method GetAllVehicles

        public List<SelectListItem> GetAllVehiclesForDropdown()
        {
            List<SelectListItem> data = new List<SelectListItem>();
            foreach (VcVehicle vehicle in GetAllVehicles())
            {
                data.Add(new SelectListItem { Text = vehicle.Name, Value = vehicle.ID.ToString() });
            }
            return data;
        } // method GetAllVehicles

        public List<VcPlate> GetPlatesForVehicle(VcVehicle vehicle)
        {
            return db.VcPlates
                .Where(t => t.VehicleId == vehicle.ID)
                .ToList();
        } // method GetPlatesForVehicle

        public List<SelectListItem> GetPlatesForVehicleForDropdown()
        {
            List<SelectListItem> data = new List<SelectListItem>();

            foreach (VcPlate plate in db.VcPlates.Where(t => t.VehicleId == SelectedVehicleToAdd))
            {
                data.Add(new SelectListItem { Text = plate.Name, Value = plate.ID.ToString() });
            }
            return data;
        } // method GetPlatesForVehicleForDropdown
    } // class VehicleCargoViewModel
}
