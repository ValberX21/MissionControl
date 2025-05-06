using JediKnightControl;
using MissionControl.Shared.Models;
using System.Security.Cryptography;
using System.Text;

namespace JediKnight.Business
{
    public class JediKnightValidator
    {
        private readonly JediKnightRepository _knightRepository;
        protected ResponseDto _response;

        public JediKnightValidator(JediKnightRepository knightRepository)
        {
            _knightRepository = knightRepository;
            _response = new ResponseDto();
        }

        public async Task<ResponseDto> addKnight(JediKnightModel knight)
        {
            try
            {
                using var sha256 = SHA256.Create();
                var bytes = Encoding.UTF8.GetBytes(knight.Password);
                var hashBytes = sha256.ComputeHash(bytes);
                knight.Password = Convert.ToBase64String(hashBytes);

                bool addProdcut = await _knightRepository.CreateJediKnight(knight);

                if (addProdcut)
                {
                    _response.IsSuccess = true;
                    _response.Data = knight;
                    _response.DisplayMessage = "Knight created success";
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Data = ex.Message;
            }

            return _response;

        }

        public async Task<ResponseDto> checkKnight(LoginModel jediKnight)
        {
            try
            {
                using var sha256 = SHA256.Create();
                var bytes = Encoding.UTF8.GetBytes(jediKnight.Password);
                var hashBytes = sha256.ComputeHash(bytes);
                jediKnight.Password = Convert.ToBase64String(hashBytes);

                var dt = await _knightRepository.loginJediKnights(jediKnight);
                _response.Data = dt;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Data = ex.Message;
            }

            return _response;

        }
    }
}
