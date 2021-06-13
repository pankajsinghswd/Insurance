using System.Collections.Generic;
using System.Data;
using Insurance.Models;
using Insurance.Models.APIModels;
using Insurance.ViewModels;


namespace Insurance.Interface
{
    public interface IAdmin
    {
        DashboardModel GetDashboardData();
        void CreateProfile();
    }
}
