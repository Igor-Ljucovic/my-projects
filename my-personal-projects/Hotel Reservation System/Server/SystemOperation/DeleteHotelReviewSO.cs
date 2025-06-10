using Domen;

namespace Server.SystemOperation
{
    internal class DeleteHotelReviewSO : SystemOperationBase<HotelReview, HotelReview>
    {
        public DeleteHotelReviewSO(HotelReview recenzijaHotela)
        {
            Entity = recenzijaHotela;
        }

        protected override void ExecuteConcreteOperation()
        {
            HotelReview soba = (HotelReview)broker.GetOneByConditions<HotelReview>(Entity.SelectSQLCondition, Entity.PrimaryKeySQLCondition);
            broker.Delete<HotelReview>(soba.PrimaryKeySQLCondition);
            Result = Entity;
        }
    }
}
