using Domen;

namespace Server.SystemOperation
{
    internal class CreateHotelReviewSO : SystemOperationBase<HotelReview, HotelReview>
    {
        public CreateHotelReviewSO(HotelReview recenzijaHotela)
        {
            Entity = recenzijaHotela;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.Add<HotelReview>(Entity.InsertSQLValues);
            Result = Entity;
        }
    }
}
