using Domen;

namespace Server.SystemOperation
{ 
    internal class UpdateHotelReviewSO : SystemOperationBase<HotelReview, HotelReview>
    {
        public UpdateHotelReviewSO(HotelReview recenzijaHotela)
        {
            Entity = recenzijaHotela;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.Update<HotelReview>(Entity.SetSQLCondition, Entity.PrimaryKeySQLCondition);
            Result = Entity;
        }
    }
}
