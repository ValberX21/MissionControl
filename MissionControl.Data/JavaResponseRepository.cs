using MissionControl.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionControl.Data
{
    public class JavaResponseRepository
    {
        private readonly ApplicationDbContext _db;
        protected ResponseDto _response;

        public JavaResponseRepository(ApplicationDbContext db)
        {
            _db = db;
            _response = new ResponseDto();
        }

        public async Task<bool> confirmJava(JavaResponseModel mission)
        {
            try
            {          

                _db.JavaResponse.Add(mission);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
