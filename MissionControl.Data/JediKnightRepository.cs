using MissionControl.Data;
using MissionControl.Shared;
using MissionControl.Shared.Models;

namespace JediKnightControl
{
    public class JediKnightRepository
    {
        private readonly ApplicationDbContext _db;
        protected ResponseDto _response;

        public JediKnightRepository(ApplicationDbContext db)
        {
            _db = db;
            _response = new ResponseDto();
        }

        public async Task<bool> CreateJediKnight(JediKnightModel jediKnight)
        {
            try
            {
                _db.JediKnight.Add(jediKnight);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<JediKnightModel> loginJediKnights(LoginModel jediKnight)
        {
            try
            {
                JediKnightModel? dtJediKnight =
                    _db.JediKnight.FirstOrDefault(j => j.JediName == jediKnight.JediName
                                                    &&
                                                    j.Password == jediKnight.Password);

                
                if (dtJediKnight == null)
                {
                    throw new Exception("Jedi not found");
                }
                else
                {
                    dtJediKnight.Password = "";
                    return dtJediKnight;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
