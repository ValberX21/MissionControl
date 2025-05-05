using JediKnightControl;
using MissionControl.Shared.Models;

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
                bool addProdcut = await _knightRepository.CreateJediKnight(knight);

                if (addProdcut)
                {
                    _response.IsSuccess = true;
                    _response.Data = knight;
                    _response.DisplayMessage = "Knight added success";
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Data = ex.Message;
            }

            return _response;

        }

        public async Task<ResponseDto> listJediKnights()
        {
            try
            {               
                await _knightRepository.listJediKnights();
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
